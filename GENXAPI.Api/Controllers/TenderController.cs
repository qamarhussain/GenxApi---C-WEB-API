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
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllTenders()
        {
            try
            {
                var viewModel = new List<TenderCreateViewModel>();
                var result = _tenderRepo.AllIncluding(x => x.Customer, y => y.TenderDetails, z => z.TenderChilds).ToList();
                foreach(var tender in result)
                {
                    TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
                    tenderViewModel.Id = tender.Id;
                    tenderViewModel.CreatedBy = tender.CreatedBy;
                    tenderViewModel.CreatedOn = tender.CreatedOn;
                    tenderViewModel.CustomerId = tender.CustomerId;
                    tenderViewModel.TenderReference = tender.TenderReference;
                    tenderViewModel.TenderSource = tender.TenderSource;
                    tenderViewModel.TenderTerm = tender.TenderTerm;
                    tenderViewModel.CustomerName = tender.Customer.Name;
                    tenderViewModel.TenderNo = tender.TenderDetails.First().ItemCode.Remove(tender.TenderDetails.First().ItemCode.LastIndexOf('-'));
                    #region Tender details
                    foreach (var items in tender.TenderDetails)
                    {
                        TenderDetail tenderDetail = new TenderDetail();
                        tenderDetail.Id = items.Id;
                        tenderDetail.TenderId = items.TenderId;
                        tenderDetail.CustomerId = items.CustomerId;
                        tenderDetail.DestinationTo = items.Id.ToString();
                        tenderDetail.DestinationFrom = items.DestinationFrom;
                        tenderDetail.DestinationFromName = _cityRepo.Get(Convert.ToInt32(items.DestinationFrom)).Name;
                        var cityTo = _cityRepo.Get(Convert.ToInt32(items.DestinationTo));
                        tenderDetail.DestinationToName = cityTo.Name;
                        tenderDetail.ProvinceName = cityTo.Province.Name;
                        tenderDetail.ProvinceId = items.ProvinceId;
                        tenderDetail.ItemCode = items.ItemCode;
                        tenderViewModel.TenderDetails.Add(tenderDetail);
                    }
                    #endregion End Tender details

                    #region Tender Child.
                    foreach (var items in tender.TenderChilds)
                    {
                        TenderChild tenderChild = new TenderChild();
                        tenderChild.FleetServiceId = items.FleetServiceId;
                        var fleetServiceObj = _fleetServiceRepo.Get(items.FleetServiceId);
                        tenderChild.ServiceName = fleetServiceObj.ServiceName;
                        tenderChild.ServiceType = fleetServiceObj.ServiceType;
                        tenderChild.ItemCode = items.ItemCode;
                        tenderChild.CustomerId = items.CustomerId;
                        tenderChild.TenderId = items.TenderId;
                        tenderChild.VehicleType = items.VehicleType;
                        tenderChild.Amount = items.Amount;
                        tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                        tenderViewModel.TenderChilds.Add(tenderChild);
                    }
                    #endregion
                    viewModel.Add(tenderViewModel);
                }
                return Ok(viewModel);

            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var tender = _tenderRepo.AllIncluding(x=>x.TenderDetails, y=>y.TenderChilds, z=>z.Customer).Where(m=>m.Id == id).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                else
                {
                    TenderCreateViewModel tenderViewModel = new TenderCreateViewModel();
                    tenderViewModel.Id = tender.Id;
                    tenderViewModel.CreatedBy = tender.CreatedBy;
                    tenderViewModel.CreatedOn = tender.CreatedOn;
                    tenderViewModel.CustomerId = tender.CustomerId;
                    tenderViewModel.TenderReference = tender.TenderReference;
                    tenderViewModel.TenderSource = tender.TenderSource;
                    tenderViewModel.TenderTerm = tender.TenderTerm;
                    #region Tender details
                    foreach (var items in tender.TenderDetails)
                    {
                        TenderDetail tenderDetail = new TenderDetail();
                        tenderDetail.Id = items.Id;
                        tenderDetail.TenderId = items.TenderId;
                        tenderDetail.CustomerId = items.CustomerId;
                        tenderDetail.DestinationTo = items.Id.ToString();
                        tenderDetail.DestinationFrom = items.DestinationFrom;
                        tenderDetail.DestinationFromName = _cityRepo.Get(Convert.ToInt32(items.DestinationFrom)).Name;
                        var cityTo = _cityRepo.Get(Convert.ToInt32(items.DestinationTo));
                        tenderDetail.DestinationToName = cityTo.Name;
                        tenderDetail.ProvinceName = cityTo.Province.Name;
                        tenderDetail.ProvinceId = items.ProvinceId;
                        tenderDetail.ItemCode = items.ItemCode;
                        tenderViewModel.TenderDetails.Add(tenderDetail);
                    }
                    #endregion End Tender details

                    #region Tender Child.
                    foreach (var items in tender.TenderChilds)
                    {
                        TenderChild tenderChild = new TenderChild();
                        tenderChild.FleetServiceId = items.FleetServiceId;
                        var fleetServiceObj = _fleetServiceRepo.Get(items.FleetServiceId);
                        tenderChild.ServiceName = fleetServiceObj.ServiceName;
                        tenderChild.ServiceType = fleetServiceObj.ServiceType;
                        tenderChild.ItemCode = items.ItemCode;
                        tenderChild.CustomerId = items.CustomerId;
                        tenderChild.TenderId = items.TenderId;
                        tenderChild.VehicleType = items.VehicleType;
                        tenderChild.Amount = items.Amount;
                        tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                        tenderViewModel.TenderChilds.Add(tenderChild);
                    }

                    #endregion
                    return Ok(tenderViewModel);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateTender([FromBody]Tender tender)
        {
            try
            {
                tender.StatusId = (byte)Status.Active;
                tender.IssuanceDate = DateTime.Now;
                tender.LastModifiedDate = DateTime.Now;

                _tenderRepo.Create(tender);
                return Ok(tender);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateTender(int id, [FromBody]TenderCreateViewModel createViewModel)
        {
            try
            {
                var tender = _tenderRepo.Get(id);
                if (tender == null)
                {
                    return NotFound();
                }
                tender.CustomerId = createViewModel.CustomerId;
                tender.IssuanceDate = createViewModel.IssuanceDate;
                tender.TenderReference = createViewModel.TenderReference;
                tender.TenderSource = createViewModel.TenderSource;
                tender.TenderTerm = createViewModel.TenderTerm;
                tender.StatusId = (byte)createViewModel.StatusId;
                tender.LastModifiedDate = DateTime.Now;
                tender.LastModifiedBy = createViewModel.LastModifiedBy;
                tender.CompanyId = createViewModel.CompanyId;
                tender.BusinessUnitId = createViewModel.BusinessUnitId;
                foreach (var items in createViewModel.TenderDetails)
                {
                    TenderDetail tenderDetail = new TenderDetail();

                    tenderDetail.TenderId = items.TenderId;
                    tenderDetail.CustomerId = items.CustomerId;
                    tenderDetail.DestinationTo = items.DestinationTo;
                    tenderDetail.DestinationFrom = items.DestinationFrom;
                    tenderDetail.ItemCode = items.ItemCode;
                    tender.TenderDetails.Add(tenderDetail);
                }
                foreach (var items in createViewModel.TenderChilds)
                {
                    TenderChild tenderChild = new TenderChild();
                    tenderChild.FleetServiceId = items.FleetServiceId;
                    tenderChild.ItemCode = items.ItemCode;
                    tenderChild.CustomerId = items.CustomerId;
                    tenderChild.TenderId = items.TenderId;
                    tenderChild.VehicleType = items.VehicleType;
                    tenderChild.Amount = items.Amount;
                    tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                    tender.TenderChilds.Add(tenderChild);
                }
                _tenderRepo.Update(tender);
                return Ok(tender);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult DeleteTender(int id)
        {

            try
            {
                var tenderModel = _tenderRepo.Get(id);
                if (tenderModel == null)
                {
                    return NotFound();
                }

                _tenderRepo.Delete(id);
                return Ok(tenderModel);
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

            var tenderDetailList = new List<TenderDetail>();

            foreach (var items in createViewModel.TenderDetails)
            {
                TenderDetail tenderDetail = new TenderDetail();

                tenderDetail.TenderId = items.TenderId;
                tenderDetail.CustomerId = items.CustomerId;
                tenderDetail.DestinationTo = items.Id.ToString();
                tenderDetail.DestinationFrom = items.DestinationFrom;
                tenderDetail.ItemCode = items.ItemCode;
                tenderDetail.ProvinceId = items.ProvinceId;
                tenderDetail.CustomerId = createViewModel.CustomerId != null? createViewModel.CustomerId.Value : 0;
                tenderDetailList.Add(tenderDetail);
            }

            tender.TenderDetails = tenderDetailList;

            var tenderChildList = new List<TenderChild>();

            foreach (var items in createViewModel.TenderChilds)
            {
                TenderChild tenderChild = new TenderChild();
                tenderChild.FleetServiceId = items.FleetServiceId;
                tenderChild.ItemCode = items.ItemCode;
                tenderChild.CustomerId = items.CustomerId;
                tenderChild.TenderId = items.TenderId;
                tenderChild.VehicleType = items.VehicleType;
                tenderChild.Amount = items.Amount;
                tenderChild.UnitOfMeasurement = items.UnitOfMeasurement;
                tenderChild.FleetServiceId = items.Id;
                tenderChild.CustomerId = createViewModel.CustomerId;
                tenderChildList.Add(tenderChild);
            }

            tender.TenderChilds = tenderChildList;

            _tenderRepo.Create(tender);
            return Ok(tender);
        }

    }
}
