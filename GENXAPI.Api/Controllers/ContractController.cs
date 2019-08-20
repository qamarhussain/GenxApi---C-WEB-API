using GENXAPI.Api.Models;
using GENXAPI.Api.Utilities;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    public class ContractController : ApiController
    {
        protected readonly FleetServiceRepo _fleetServiceRepo = new FleetServiceRepo();
        IUnitOfWork db;
        public ContractController()
        {
            db = new UnitOfWork();
        }

        public IHttpActionResult GetAllContracts()
        {
            var result = db.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails, z=>z.TenderChilds).Where(o => o.ProceedStatus != (byte)TenderUtility.TenderState).ToList();
            return Ok(result);
        }

        public IHttpActionResult CreateContract(ContractCreateViewModel model)
        {
            var tender = db.Tenders.Get(model.TenderId);
            var serviceIds = model.contractServices.Select(x => x.Id).ToList();
            var childList = db.TenderChilds.Find(o => serviceIds.Contains(o.Id)).ToList();

            foreach(var item in childList)
            {
                var serviceItem = model.contractServices.Where(x => x.Id == item.Id).FirstOrDefault();
                if (serviceItem != null)
                {
                    item.Amount = serviceItem.Amount;
                    item.ItemCode = serviceItem.ItemCode;
                    db.TenderChilds.Update(item);
                }
            }
            var vehiclesToAdd = new List<TenderChild>();
            foreach (var item in model.contractDetailVehicle)
            {
                var obj = new TenderChild
                {
                    CustomerId = tender.CustomerId,
                    ItemCode=item.ItemCode,
                    TenderId=model.TenderId,
                    VehicleId=item.VehicleId,
                    Amount=item.Amount,
                    TenderDetailId=item.DetailId
                };
                db.TenderChilds.Add(obj);
            }
            tender.ProceedStatus = (byte)TenderUtility.ContractState;
            db.Tenders.Update(tender);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetById(int id)
        {
            var result = db.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails, z => z.TenderChilds.Select(q => q.FleetService), z => z.TenderChilds.Select(s=>s.Vehicle)).Where(o => o.Id == id).FirstOrDefault();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        public IHttpActionResult UpdateContract(ContractCreateViewModel model)
        {
            var tender = db.Tenders.AllIncluding(x=>x.TenderDetails, y=>y.TenderChilds).Where(r=>r.Id == model.TenderId).FirstOrDefault();
            if(tender == null)
            {
                return NotFound();
            }
            db.TenderChilds.RemoveRange(tender.TenderChilds.Where(x=>x.TenderDetailId != null).ToArray());
            var servicesToAdd = new List<TenderChild>();
            foreach(var item in tender.TenderChilds)
            {
                item.Amount = model.contractServices.Where(x => x.Id == item.Id).First().Amount;
                db.TenderChilds.Update(item);
            }
            var vehiclesToAdd = new List<TenderChild>();
            foreach (var item in model.contractDetailVehicle)
            {
                var obj = new TenderChild
                {
                    CustomerId = tender.CustomerId,
                    ItemCode = item.ItemCode,
                    TenderId = model.TenderId,
                    VehicleId = item.VehicleId,
                    Amount = item.Amount,
                    TenderDetailId = item.DetailId
                };
                db.TenderChilds.Add(obj);
            }
            tender.ProceedStatus = (byte)model.ProceedStatus;
            db.Tenders.Update(tender);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = db.Tenders.GetContractKeyPair(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId));
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
