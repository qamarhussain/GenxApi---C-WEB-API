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
                var result = db.Tenders.AllIncluding(x=>x.Customer).ToList();
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
        //[HttpGet]
        //public IHttpActionResult GetById(int id)
        //{
        //    try
        //    {
        //        var tender = _tenderRepo.AllIncluding(x=>x.TenderDetails, y=>y.TenderChilds, z=>z.Customer).Where(m=>m.Id == id).FirstOrDefault();
        //        if (tender == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
        //            tenderViewModel.Id = tender.Id;
        //            tenderViewModel.StatusId = (byte)tender.StatusId;
        //            tenderViewModel.CreatedBy = tender.CreatedBy;
        //            tenderViewModel.CreatedOn = tender.CreatedOn;
        //            tenderViewModel.CustomerId = tender.CustomerId;
        //            tenderViewModel.CustomerName = tender.Customer.Name;
        //            tenderViewModel.TenderReference = tender.TenderReference;
        //            tenderViewModel.TenderSource = tender.TenderSource;
        //            tenderViewModel.TenderTerm = tender.TenderTerm;
        //            tenderViewModel.ProvinceId = tender.TenderDetails.First().ProvinceId;
        //            tenderViewModel.TenderNo = tender.TenderDetails.First().ItemCode.Remove(tender.TenderDetails.First().ItemCode.LastIndexOf('-'));
        //            #region Tender details
        //            foreach (var items in tender.TenderDetails)
        //            {
        //                TenderDetail tenderDetail = new TenderDetail();
        //                tenderDetail.Id = items.Id;
        //                tenderDetail.TenderId = items.TenderId;
        //                tenderDetail.CustomerId = items.CustomerId;
        //                tenderDetail.DestinationTo = items.DestinationTo.ToString();
        //                tenderDetail.DestinationFrom = items.DestinationFrom;
        //                tenderDetail.DestinationFromName = _cityRepo.Get(Convert.ToInt32(items.DestinationFrom)).Name;
        //                var cityTo = _cityRepo.Get(Convert.ToInt32(items.DestinationTo));
        //                tenderDetail.DestinationToName = cityTo.Name;
        //                tenderDetail.ProvinceName = cityTo.Province.Name;
        //                tenderDetail.ProvinceId = items.ProvinceId;
        //                tenderDetail.ItemCode = items.ItemCode;
        //                tenderViewModel.TenderDetails.Add(tenderDetail);
        //            }
        //            #endregion End Tender details

        //            #region Tender Child.
        //            foreach (var items in tender.TenderChilds)
        //            {
        //                TenderChild tenderChild = new TenderChild();
        //                tenderChild.Id = items.FleetServiceId;
        //                tenderChild.FleetServiceId = items.FleetServiceId;
        //                var fleetServiceObj = _fleetServiceRepo.Get(items.FleetServiceId);
        //                tenderChild.ServiceName = fleetServiceObj.ServiceName;
        //                tenderChild.ServiceType = fleetServiceObj.ServiceType;
        //                tenderChild.ItemCode = items.ItemCode;
        //                tenderChild.CustomerId = items.CustomerId;
        //                tenderChild.TenderId = items.TenderId;
        //                tenderChild.VehicleType = items.VehicleType;
        //                tenderChild.Amount = items.Amount;
        //                tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
        //                tenderViewModel.TenderChilds.Add(tenderChild);
        //            }

        //            #endregion
        //            return Ok(tenderViewModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

       

        //// PUT: api/Customer/5
        //[HttpPut]
        //public IHttpActionResult UpdateTender(int id, [FromBody]TenderCreateViewModel createViewModel)
        //{
        //    try
        //    {
        //        var tender = _tenderRepo.Get(id);
        //        if (tender == null)
        //        {
        //            return NotFound();
        //        }
        //        tender.StatusId = (byte)createViewModel.StatusId;
        //        tender.CustomerId = createViewModel.CustomerId;
        //        tender.IssuanceDate = createViewModel.IssuanceDate;
        //        tender.TenderReference = createViewModel.TenderReference;
        //        tender.TenderSource = createViewModel.TenderSource;
        //        tender.TenderTerm = createViewModel.TenderTerm;
        //        tender.StatusId = (byte)createViewModel.StatusId;
        //        tender.LastModifiedDate = DateTime.Now;
        //        tender.LastModifiedBy = createViewModel.LastModifiedBy;
        //        tender.CompanyId = createViewModel.CompanyId;
        //        tender.BusinessUnitId = createViewModel.BusinessUnitId;
        //        _tenderDetailRepo.DeleteRange(_tenderDetailRepo.Find(x => x.TenderId == id).ToList());
        //        _tenderChildRepo.DeleteRange(_tenderChildRepo.Find(x => x.TenderId == id).ToList());
        //        tender.TenderDetails = null;
        //        tender.TenderChilds = null;
        //        //foreach (var item in createViewModel.TenderDetails)
        //        //{
        //        //    var tenderDetail = _tenderDetailRepo.Find(x=>x.Id == item.Id).FirstOrDefault();
        //        //    if (tenderDetail != null)
        //        //    {
        //        //        tenderDetail.TenderId = item.TenderId;
        //        //        tenderDetail.CustomerId = item.CustomerId;
        //        //        tenderDetail.DestinationTo = item.DestinationTo;
        //        //        tenderDetail.DestinationFrom = item.DestinationFrom;
        //        //        tenderDetail.ProvinceId = createViewModel.ProvinceId;
        //        //        tenderDetail.ItemCode = item.ItemCode;
        //        //        _tenderDetailRepo.Update(tenderDetail);
        //        //    }
        //        //    else
        //        //    {
        //        //        // New child
        //        //        // Don't insert original object. It will attach whole detached graph
        //        //        tender.TenderDetails.Add(item);
        //        //    }
        //        //}
        //        var lstDetail = new List<TenderDetail>();
        //        foreach (var items in createViewModel.TenderDetails)
        //        {
        //            TenderDetail tenderDetail = new TenderDetail();

        //            tenderDetail.TenderId = id;
        //            tenderDetail.CustomerId = Convert.ToInt32(createViewModel.CustomerId);
        //            tenderDetail.DestinationTo = items.DestinationTo.ToString();
        //            tenderDetail.DestinationFrom = items.DestinationFrom;
        //            tenderDetail.ProvinceId = createViewModel.ProvinceId;
        //            tenderDetail.ItemCode = items.ItemCode;
        //            lstDetail.Add(tenderDetail);
        //        }
        //        _tenderDetailRepo.InsertRange(lstDetail);
        //        //tender.TenderDetails = lstDetail;

        //        //foreach (var item in createViewModel.TenderChilds)
        //        //{
        //        //    var tenderChild = _tenderChildRepo.Find(x => x.FleetServiceId == item.Id).FirstOrDefault();
        //        //    if (tenderChild != null)
        //        //    {
        //        //        tenderChild.FleetServiceId = item.Id;
        //        //        tenderChild.ItemCode = item.ItemCode;
        //        //        tenderChild.CustomerId = createViewModel.CustomerId;
        //        //        tenderChild.TenderId = item.TenderId;
        //        //        tenderChild.VehicleType = item.VehicleType;
        //        //        tenderChild.Amount = item.Amount;
        //        //        tenderChild.UnitOfMeasurement = item.UnitOfMeasurement;
        //        //        _tenderChildRepo.Update(tenderChild);
        //        //    }
        //        //    else
        //        //    {
        //        //        // New child
        //        //        // Don't insert original object. It will attach whole detached graph
        //        //        tender.TenderChilds.Add(item);
        //        //    }
        //        //}

        //        var lstChild = new List<TenderChild>();
        //        foreach (var items in createViewModel.TenderChilds)
        //        {
        //            TenderChild tenderChild = new TenderChild();
        //            tenderChild.FleetServiceId = items.Id;
        //            tenderChild.ItemCode = items.ItemCode;
        //            tenderChild.CustomerId = createViewModel.CustomerId;
        //            tenderChild.TenderId = id;
        //            tenderChild.VehicleType = items.VehicleType;
        //            tenderChild.Amount = items.Amount;
        //            tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
        //            lstChild.Add(tenderChild);
        //        }

        //        _tenderChildRepo.InsertRange(lstChild);
        //        //tender.TenderChilds = lstChild;

        //        //foreach (var child in tender.TenderDetails.ToList())
        //        //{
        //        //    var detachedChild = createViewModel.TenderDetails.Where(x=>x.Id == child.Id).FirstOrDefault();
        //        //    if (detachedChild == null)
        //        //    {
        //        //        tender.TenderDetails.Remove(child);
        //        //        _tenderDetailRepo.Delete(child.Id);
        //        //    }
        //        //}

        //        //foreach (var child in tender.TenderChilds.ToList())
        //        //{
        //        //    var detachedChild = createViewModel.TenderChilds.Where(x => x.Id == child.Id);
        //        //    if (detachedChild == null)
        //        //    {
        //        //        tender.TenderChilds.Remove(child);
        //        //        _tenderChildRepo.Delete(child.Id);
        //        //    }
        //        //}

        //        _tenderRepo.Update(tender);
        //        _tenderRepo.SaveChanges();
        //        _tenderChildRepo.SaveChanges();
        //        _tenderDetailRepo.SaveChanges();
        //        return Ok(tender);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }

        //}

        //// DELETE: api/Customer/5
        //[HttpDelete]
        //public IHttpActionResult DeleteTender(int id)
        //{

        //    try
        //    {
        //        var tenderModel = _tenderRepo.Get(id);
        //        if (tenderModel == null)
        //        {
        //            return NotFound();
        //        }

        //        _tenderRepo.Delete(id);
        //        return Ok(tenderModel);
        //    }

        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        //[HttpPost]
        //public IHttpActionResult TenderCreate([FromBody] TenderCreateViewModel createViewModel)
        //{
        //    Tender tender = new Tender();

        //    tender.CustomerId = createViewModel.CustomerId;
        //    tender.IssuanceDate = createViewModel.IssuanceDate;
        //    tender.TenderReference = createViewModel.TenderReference;
        //    tender.TenderSource = createViewModel.TenderSource;
        //    tender.TenderTerm = createViewModel.TenderTerm;
        //    tender.StatusId = (byte)Status.Active;
        //    tender.CreatedOn = DateTime.Now;
        //    tender.LastModifiedDate = DateTime.Now;
        //    tender.CreatedBy = createViewModel.CreatedBy;
        //    tender.LastModifiedBy = createViewModel.LastModifiedBy;
        //    tender.CompanyId = createViewModel.CompanyId;
        //    tender.BusinessUnitId = createViewModel.BusinessUnitId;

        //    var tenderDetailList = new List<TenderDetail>();

        //    foreach (var items in createViewModel.TenderDetails)
        //    {
        //        TenderDetail tenderDetail = new TenderDetail();

        //        tenderDetail.TenderId = items.TenderId;
        //        tenderDetail.CustomerId = items.CustomerId;
        //        tenderDetail.DestinationTo = items.Id.ToString();
        //        tenderDetail.DestinationFrom = items.DestinationFrom;
        //        tenderDetail.ItemCode = items.ItemCode;
        //        tenderDetail.ProvinceId = items.ProvinceId;
        //        tenderDetail.CustomerId = createViewModel.CustomerId != null? createViewModel.CustomerId.Value : 0;
        //        tenderDetailList.Add(tenderDetail);
        //    }

        //    tender.TenderDetails = tenderDetailList;

        //    var tenderChildList = new List<TenderChild>();

        //    foreach (var items in createViewModel.TenderChilds)
        //    {
        //        TenderChild tenderChild = new TenderChild();
        //        tenderChild.FleetServiceId = items.FleetServiceId;
        //        tenderChild.ItemCode = items.ItemCode;
        //        tenderChild.CustomerId = items.CustomerId;
        //        tenderChild.TenderId = items.TenderId;
        //        tenderChild.VehicleType = items.VehicleType;
        //        tenderChild.Amount = items.Amount;
        //        tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
        //        tenderChild.FleetServiceId = items.Id;
        //        tenderChild.CustomerId = createViewModel.CustomerId;
        //        tenderChildList.Add(tenderChild);
        //    }

        //    tender.TenderChilds = tenderChildList;

        //    _tenderRepo.Create(tender);
        //    return Ok(tender);
        //}

    }
}
