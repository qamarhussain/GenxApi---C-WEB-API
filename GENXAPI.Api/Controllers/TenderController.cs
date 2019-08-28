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
                var result = _unitOfWork.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails).Where(o=>o.ProceedStatus == (byte)TenderUtility.TenderState).ToList();
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
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails, z=>z.TenderChilds.Select(q => q.FleetService)).Where(m => m.Id == id).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                else
                {
                    TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
                    tenderViewModel.Id = tender.Id;
                    tenderViewModel.CustomerId = tender.CustomerId;
                    tenderViewModel.CustomerName = tender.Customer.Name;
                    tenderViewModel.IssuanceDate = tender.IssuanceDate;
                    tenderViewModel.TenderReference = tender.TenderReference;
                    tenderViewModel.TenderSource = tender.TenderSource;
                    tenderViewModel.TenderTerm = tender.TenderTerm;
                    tenderViewModel.StatusId = (byte)tender.StatusId;
                    tenderViewModel.TenderNo = tender.TenderNo;
                    tenderViewModel.ProvinceId = tender.TenderDetails.FirstOrDefault() == null ? 0 : tender.TenderDetails.First().ProvinceId;
                    tenderViewModel.RegionId = tender.TenderDetails.FirstOrDefault() == null ? 0 : tender.TenderDetails.First().RegionId;
                    #region Tender details
                    //var tenderDetailList = db.TenderDetails.Find(x => x.TenderId == tender.Id).ToList();
                    //tenderViewModel.TenderDetails = tenderDetailList;
                    foreach (var items in tender.TenderDetails)
                    {
                        TenderDetail tenderDetail = new TenderDetail();
                        tenderDetail.Id = items.Id;
                        tenderDetail.TenderId = items.TenderId;
                        tenderDetail.CustomerId = items.CustomerId;
                        tenderDetail.DestinationToId = items.DestinationToId;
                        tenderDetail.DestinationFromId = items.DestinationFromId;
                        tenderDetail.ProvinceId = items.ProvinceId;
                        tenderDetail.RegionId = items.RegionId;
                        tenderDetail.ItemCode = items.ItemCode;
                        tenderViewModel.TenderDetails.Add(tenderDetail);
                    }
                    #endregion End Tender details

                    #region Tender Child.
                    
                    tenderViewModel.TenderChilds = tender.TenderChilds.ToList();

                    #endregion
                    return Ok(tender);
                }
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
            TenderDetail tenderDetail = new TenderDetail();
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
                _unitOfWork.TenderDetails.RemoveRange(tender.TenderDetails.ToArray());
                _unitOfWork.TenderChilds.RemoveRange(tender.TenderChilds.ToArray());
                #region Tender Detail.
                var tenderDetailList = new List<TenderDetail>();
                foreach (var items in updateViewModel.TenderDetails)
                {
                    

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
                    tenderChild.TenderDetailId = tenderDetail.Id;
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
            TenderDetail tenderDetail = new TenderDetail();
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
                    tenderChild.TenderDetailId = tenderDetail.Id;
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
