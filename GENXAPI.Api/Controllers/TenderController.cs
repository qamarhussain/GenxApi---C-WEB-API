using GENXAPI.Api.Attributes;
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
    [Authorize]
    [CustomExceptionFilter]
    public class TenderController : ApiController
    {
        protected readonly TenderRepo _tenderRepo = new TenderRepo();
        protected readonly CityRepo _cityRepo = new CityRepo();
        protected readonly FleetServiceRepo _fleetServiceRepo = new FleetServiceRepo();
        protected readonly TenderDetailRepo _tenderDetailRepo = new TenderDetailRepo();
        protected readonly TenderChildRepo _tenderChildRepo = new TenderChildRepo();

        IUnitOfWork _unitOfWork;

        public TenderController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllTenders()
        {
            try
            {
                var result = _unitOfWork.Tenders.AllIncluding(x => x.Customer).ToList();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                //var tender = _tenderRepo.AllIncluding(z => z.Customer).Where(m => m.Id == id).FirstOrDefault();
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == id).FirstOrDefault();
              
                if (tender == null)
                {
                    return NotFound();
                }
                var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
                var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, y => y.Vehicle).Where(a => a.TenderId == tender.Id).ToList();
                tender.TenderDetails = tenderDetails;
                tender.TenderChilds = tenderChilds;
                return Ok(tender);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



        //// PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateTender(int id, [FromBody]TenderCreateViewModel updateViewModel)
        {
           
            try
            {
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails, z => z.TenderChilds).Where(m => m.Id == id).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                tender.CustomerId = updateViewModel.CustomerId;
                tender.IssuanceDate = updateViewModel.IssuanceDate;
                tender.TenderReference = updateViewModel.TenderReference;
                tender.TenderSource = updateViewModel.TenderSource;
                tender.TenderTerm = updateViewModel.TenderTerm;
                tender.StatusId = (byte)updateViewModel.StatusId;
                tender.LastModifiedDate = DateTime.Now;
                tender.LastModifiedBy = updateViewModel.LastModifiedBy;
                tender.CompanyId = updateViewModel.CompanyId;
                tender.BusinessUnitId = updateViewModel.BusinessUnitId;
                tender.TenderNo = updateViewModel.TenderNo;
                //_unitOfWork.TenderDetails.RemoveRange(tender.TenderDetails.ToArray());
                //_unitOfWork.TenderChilds.RemoveRange(tender.TenderChilds.ToArray());
                foreach (var child in tender.TenderDetails.ToList())
                    _unitOfWork.TenderDetails.Remove(child);
                foreach (var child in tender.TenderChilds.ToList())
                    _unitOfWork.TenderChilds.Remove(child);
                #region Tender Detail.
                var tenderDetailList = new List<TenderDetail>();
                foreach (var items in updateViewModel.TenderDetails)
                {

                    TenderDetail tenderDetail = new TenderDetail();
                    tenderDetail.TenderId = tender.Id;
                    tenderDetail.CustomerId = Convert.ToInt32(tender.CustomerId);
                    tenderDetail.DestinationFromId = items.DestinationFromId;
                    tenderDetail.DestinationToId = items.DestinationToId;
                    tenderDetail.ItemCode = items.ItemCode;
                    tenderDetail.ProvinceId = items.ProvinceId;
                    tenderDetail.RegionId = items.RegionId;
                    tenderDetailList.Add(tenderDetail);
                }
                tender.TenderDetails = tenderDetailList;
                #endregion

                #region Tender Services.
                var tenderChildList = new List<TenderChild>();
                foreach (var items in updateViewModel.TenderChilds)
                {
                    TenderChild tenderChild = new TenderChild();
                    tenderChild.FleetServiceId = items.FleetServiceId;
                    tenderChild.ItemCode = items.ItemCode;
                    tenderChild.CustomerId = tender.CustomerId;
                    tenderChild.TenderId = tender.Id;
                    //tenderChild.TenderDetailId = tenderDetail.Id;
                    tenderChildList.Add(tenderChild);
                }
                tender.TenderChilds = tenderChildList;
                _unitOfWork.Tenders.Update(tender);
                _unitOfWork.SaveChanges();
                return Ok(tender);
                #endregion
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

       

        [HttpPost]
        public IHttpActionResult TenderCreate([FromBody] TenderCreateViewModel createViewModel)
        {
            Tender tender = new Tender();
   
            try
            {
                tender.CustomerId = createViewModel.CustomerId;
                tender.IssuanceDate = createViewModel.IssuanceDate;
                tender.TenderReference = createViewModel.TenderReference;
                tender.TenderSource = createViewModel.TenderSource;
                tender.TenderTerm = createViewModel.TenderTerm;
                tender.StatusId = (byte)Status.Active;
                tender.CreatedOn = DateTime.Now;
                tender.LastModifiedDate = DateTime.Now;
                tender.CreatedBy = createViewModel.CreatedBy;
                tender.LastModifiedBy = createViewModel.LastModifiedBy;
                tender.CompanyId = createViewModel.CompanyId;
                tender.BusinessUnitId = createViewModel.BusinessUnitId;
                tender.TenderNo = createViewModel.TenderNo;
                tender.ProceedStatus = (byte)TenderUtility.TenderState;
                _unitOfWork.Tenders.Add(tender);
                #region Tender Detail.
                var tenderDetailList = new List<TenderDetail>();
                
                foreach (var items in createViewModel.TenderDetails)
                {
                    TenderDetail tenderDetail = new TenderDetail();
                    tenderDetail.TenderId = tender.Id;
                    tenderDetail.CustomerId = Convert.ToInt32(tender.CustomerId);
                    tenderDetail.DestinationFromId = items.DestinationFromId;
                    tenderDetail.DestinationToId = items.DestinationToId;
                    tenderDetail.ItemCode = items.ItemCode;
                    tenderDetail.ProvinceId = items.ProvinceId;
                    tenderDetail.RegionId = items.RegionId;
                    tenderDetailList.Add(tenderDetail);
                }
                _unitOfWork.TenderDetails.AddRange(tenderDetailList);
                #endregion

                #region Tender Services.
                var tenderChildList = new List<TenderChild>();
                foreach (var items in createViewModel.TenderChilds)
                {
                    TenderChild tenderChild = new TenderChild();
                    tenderChild.FleetServiceId = items.Id;
                    tenderChild.ItemCode = items.ItemCode;
                    tenderChild.CustomerId = tender.CustomerId;
                    tenderChild.TenderId = tender.Id;
                    //tenderChild.TenderDetailId = tenderDetail.Id;
                    tenderChildList.Add(tenderChild);
                }
                _unitOfWork.TenderChilds.AddRange(tenderChildList);
                #endregion

                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        [HttpPost]
        public IHttpActionResult GetKeyPairForContract(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                return Ok(_tenderRepo.GetKeyPairValue(model.CustomerId,(int)TenderUtility.TenderState));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        

    }
}
