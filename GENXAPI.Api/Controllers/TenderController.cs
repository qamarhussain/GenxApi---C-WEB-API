using GENXAPI.Api.Models;
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

        IUnitOfWork db;

        public TenderController()
        {
            db = new UnitOfWork();
        }

        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllTenders()
        {
            try
            {
                var viewModel = new List<TenderCreateViewModel>();
                //var result = _tenderRepo.AllIncluding(x => x.Customer, y => y.TenderDetails, z => z.TenderChilds).ToList();
                //var result = db.Tenders.AllIncluding(x=>x.Customer).ToList();
                var result = db.Tenders.AllIncluding(x => x.AML_Customers, y => y.AML_TenderDetail).ToList();
                //foreach(var tender in result)
                //{
                //    TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
                //    tenderViewModel.Id = tender.Id;
                //    tenderViewModel.StatusId = (byte)tender.StatusId;
                //    tenderViewModel.CreatedBy = tender.CreatedBy;
                //    tenderViewModel.CreatedOn = tender.CreatedOn;
                //    tenderViewModel.CustomerId = tender.CustomerId;
                //    tenderViewModel.TenderReference = tender.TenderReference;
                //    tenderViewModel.TenderSource = tender.TenderSource;
                //    tenderViewModel.TenderTerm = tender.TenderTerm;
                //    tenderViewModel.CustomerName = tender.Customer.Name;
                //    tenderViewModel.TenderNo = tender.TenderDetails.First().ItemCode.Remove(tender.TenderDetails.First().ItemCode.LastIndexOf('-'));
                //    #region Tender details
                //    foreach (var items in tender.TenderDetails)
                //    {
                //        TenderDetail tenderDetail = new TenderDetail();
                //        tenderDetail.Id = items.Id;
                //        tenderDetail.TenderId = items.TenderId;
                //        tenderDetail.CustomerId = items.CustomerId;
                //        tenderDetail.DestinationTo = items.Id.ToString();
                //        tenderDetail.DestinationFrom = items.DestinationFrom;
                //        tenderDetail.DestinationFromName = _cityRepo.Get(Convert.ToInt32(items.DestinationFrom)).Name;
                //        var cityTo = _cityRepo.Get(Convert.ToInt32(items.DestinationTo));
                //        tenderDetail.DestinationToName = cityTo.Name;
                //        tenderDetail.ProvinceName = cityTo.Province.Name;
                //        tenderDetail.ProvinceId = items.ProvinceId;
                //        tenderDetail.ItemCode = items.ItemCode;
                //        tenderViewModel.TenderDetails.Add(tenderDetail);
                //    }
                //    #endregion End Tender details

                //    #region Tender Child.
                //    foreach (var items in tender.TenderChilds)
                //    {
                //        TenderChild tenderChild = new TenderChild();
                //        tenderChild.FleetServiceId = items.FleetServiceId;
                //        var fleetServiceObj = _fleetServiceRepo.Get(items.FleetServiceId);
                //        tenderChild.ServiceName = fleetServiceObj.ServiceName;
                //        tenderChild.ServiceType = fleetServiceObj.ServiceType;
                //        tenderChild.ItemCode = items.ItemCode;
                //        tenderChild.CustomerId = items.CustomerId;
                //        tenderChild.TenderId = items.TenderId;
                //        tenderChild.VehicleType = items.VehicleType;
                //        tenderChild.Amount = items.Amount;
                //        tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                //        tenderViewModel.TenderChilds.Add(tenderChild);
                //    }
                //    #endregion
                //    viewModel.Add(tenderViewModel);
                //}
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
                var tender = db.Tenders.AllIncluding(x => x.AML_Customers, y => y.AML_TenderDetail, z=>z.AML_TenderChild).Where(m => m.Id == id).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                else
                {
                    TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
                    tenderViewModel.Id = tender.Id;
                    tenderViewModel.CustomerId = tender.CustomerId;
                    tenderViewModel.CustomerName = tender.AML_Customers.Name;
                    tenderViewModel.IssuanceDate = tender.IssuanceDate;
                    tenderViewModel.TenderReference = tender.TenderReference;
                    tenderViewModel.TenderSource = tender.TenderSource;
                    tenderViewModel.TenderTerm = tender.TenderTerm;
                    tenderViewModel.StatusId = (byte)tender.StatusId;
                    tenderViewModel.TenderNo = tender.TenderNo;
                    tenderViewModel.ProvinceId = tender.AML_TenderDetail.FirstOrDefault() == null ? 0 : tender.AML_TenderDetail.First().ProvinceId;
                    #region Tender details
                    //var tenderDetailList = db.TenderDetails.Find(x => x.TenderId == tender.Id).ToList();
                    //tenderViewModel.TenderDetails = tenderDetailList;
                    foreach (var items in tender.AML_TenderDetail)
                    {
                        AML_TenderDetail tenderDetail = new AML_TenderDetail();
                        tenderDetail.Id = items.Id;
                        tenderDetail.TenderId = items.TenderId;
                        tenderDetail.CustomerId = items.CustomerId;
                        tenderDetail.DestinationToId = items.DestinationToId;
                        tenderDetail.DestinationToName = items.DestinationToName;
                        tenderDetail.DestinationFromId = items.DestinationFromId;
                        tenderDetail.DestinationFromName = items.DestinationFromName;
                        tenderDetail.ProvinceId = items.ProvinceId;
                        tenderDetail.ProvinceName = items.ProvinceName;
                        tenderDetail.ItemCode = items.ItemCode;
                        tenderViewModel.TenderDetails.Add(tenderDetail);
                    }
                    #endregion End Tender details

                    #region Tender Child.
                    tenderViewModel.TenderChilds = tender.AML_TenderChild.ToList();
                    //foreach (var items in tender.TenderChilds)
                    //{
                    //    TenderChildViewModel tenderChild = new TenderChildViewModel();
                    //    tenderChild.Id = items.FleetServiceId;
                    //    tenderChild.FleetServiceId = items.FleetServiceId;
                    //    var fleetServiceObj = _fleetServiceRepo.Get(items.FleetServiceId);
                    //    tenderChild.ServiceName = fleetServiceObj.ServiceName;
                    //    tenderChild.ServiceType = fleetServiceObj.ServiceType;
                    //    tenderChild.ItemCode = items.ItemCode;
                    //    tenderChild.CustomerId = items.CustomerId;
                    //    tenderChild.TenderId = items.TenderId;
                    //    tenderChild.VehicleType = items.VehicleType;
                    //    tenderChild.Amount = items.Amount;
                    //    tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                    //    tenderViewModel.TenderChilds.Add(tenderChild);
                    //}

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
            try
            {
                var tender = db.Tenders.AllIncluding(x => x.AML_Customers, y => y.AML_TenderDetail, z => z.AML_TenderChild).Where(m => m.Id == id).FirstOrDefault();
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
                db.TenderDetails.RemoveRange(tender.AML_TenderDetail.ToArray());
                db.TenderChilds.RemoveRange(tender.AML_TenderChild.ToArray());
                #region Tender Detail.
                var tenderDetailList = new List<AML_TenderDetail>();
                foreach (var items in updateViewModel.TenderDetails)
                {
                    AML_TenderDetail tenderDetail = new AML_TenderDetail();

                    tenderDetail.TenderId = tender.Id;
                    tenderDetail.CustomerId = Convert.ToInt32(tender.CustomerId);
                    tenderDetail.DestinationFromId = items.DestinationFromId;
                    tenderDetail.DestinationFromName = items.DestinationFromName;
                    tenderDetail.DestinationToId = items.DestinationToId;
                    tenderDetail.DestinationToName = items.DestinationToName;
                    tenderDetail.ItemCode = items.ItemCode;
                    tenderDetail.ProvinceId = items.ProvinceId;
                    tenderDetail.ProvinceName = items.ProvinceName;
                    tenderDetailList.Add(tenderDetail);
                }
                tender.AML_TenderDetail = tenderDetailList;
                #endregion

                #region Tender Services.
                var tenderChildList = new List<AML_TenderChild>();
                foreach (var items in updateViewModel.TenderChilds)
                {
                    AML_TenderChild tenderChild = new AML_TenderChild();
                    tenderChild.FleetServiceId = items.FleetServiceId;
                    tenderChild.ItemCode = items.ItemCode;
                    tenderChild.CustomerId = tender.CustomerId;
                    tenderChild.TenderId = tender.Id;
                    tenderChildList.Add(tenderChild);
                }
                tender.AML_TenderChild = tenderChildList;
                //var detailToDelete = db.TenderDetails.Find(x => x.TenderId == id).ToList();
                //foreach(var item in detailToDelete)
                //{
                //    item.Tender = null;
                //    db.TenderDetails.Remove(item);
                //}
                //db.TenderChilds.RemoveRange(db.TenderChilds.Find(x => x.TenderId == id).ToList());
                //db.TenderDetails.RemoveRange(db.TenderDetails.Find(x => x.TenderId == id).ToList());
                db.Tenders.Update(tender);
                db.SaveChanges();
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
            AML_Tender tender = new AML_Tender();
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
                db.Tenders.Add(tender);
                #region Tender Detail.
                var tenderDetailList = new List<AML_TenderDetail>();
                foreach (var items in createViewModel.TenderDetails)
                {
                    AML_TenderDetail tenderDetail = new AML_TenderDetail();

                    tenderDetail.TenderId = tender.Id;
                    tenderDetail.CustomerId = Convert.ToInt32(tender.CustomerId);
                    tenderDetail.DestinationFromId = items.DestinationFromId;
                    tenderDetail.DestinationFromName = items.DestinationFromName;
                    tenderDetail.DestinationToId = items.DestinationToId;
                    tenderDetail.DestinationToName = items.DestinationToName;
                    tenderDetail.ItemCode = items.ItemCode;
                    tenderDetail.ProvinceId = items.ProvinceId;
                    tenderDetail.ProvinceName = items.ProvinceName;
                    tenderDetailList.Add(tenderDetail);
                }
                db.TenderDetails.AddRange(tenderDetailList);
                #endregion

                #region Tender Services.
                var tenderChildList = new List<AML_TenderChild>();
                foreach (var items in createViewModel.TenderChilds)
                {
                    AML_TenderChild tenderChild = new AML_TenderChild();
                    tenderChild.FleetServiceId = items.Id;
                    tenderChild.ItemCode = items.ItemCode;
                    tenderChild.CustomerId = tender.CustomerId;
                    tenderChild.TenderId = tender.Id;
                    tenderChildList.Add(tenderChild);
                }
                db.TenderChilds.AddRange(tenderChildList);
                #endregion

                db.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                return Ok(_tenderRepo.GetKeyPairValue(model.CustomerId));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        

    }
}
