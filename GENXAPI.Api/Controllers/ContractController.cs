using GENXAPI.Api.Models;
using GENXAPI.Api.Utilities;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
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
        IUnitOfWork db;
        public ContractController()
        {
            db = new UnitOfWork();
        }

        public IHttpActionResult GetAllContracts()
        {
            var result = db.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails).Where(o => o.ProceedStatus == (byte)TenderUtility.ContractState).ToList();
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

    }
}
