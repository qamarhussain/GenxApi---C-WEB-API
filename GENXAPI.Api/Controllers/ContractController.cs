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
    public class ContractController : ApiController
    {
        protected readonly FleetServiceRepo _fleetServiceRepo = new FleetServiceRepo();
        IUnitOfWork _unitOfWork;
        public ContractController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IHttpActionResult GetAllContracts()
        {
            var result = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(o => o.ProceedStatus != (byte)TenderUtility.TenderState).ToList();
            return Ok(result);
        }

        public IHttpActionResult CreateContract(ContractCreateViewModel model)
        {
            var tender = _unitOfWork.Tenders.Get(model.TenderId);
            var serviceIds = model.contractServices.Select(x => x.Id).ToList();
            var childList = _unitOfWork.TenderChilds.Find(o => serviceIds.Contains(o.Id)).ToList();

            foreach(var item in childList)
            {
                var serviceItem = model.contractServices.Where(x => x.Id == item.Id).FirstOrDefault();
                if (serviceItem != null)
                {
                    item.Amount = serviceItem.Amount;
                    item.ItemCode = serviceItem.ItemCode;
                    _unitOfWork.TenderChilds.Update(item);
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
                    TenderDetailId=item.DetailId,
                    IsDeleted=(byte)TenderChildStatus.Active
                };
                _unitOfWork.TenderChilds.Add(obj);
            }
            tender.ProceedStatus = (byte)TenderUtility.ContractState;
            _unitOfWork.Tenders.Update(tender);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetById(int id)
        {
            var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == id).FirstOrDefault();

            if (tender == null)
            {
                return NotFound();
            }
            var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
            var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, a => a.FleetService.Unit, v=>v.Vehicle, z=>z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == tender.Id).ToList();
            tender.TenderDetails = tenderDetails;
            tender.TenderChilds = tenderChilds;
            return Ok(tender);
        }

        public IHttpActionResult UpdateContract(ContractCreateViewModel model)
        {
            try
            {
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.TenderDetails, y => y.TenderChilds).Where(r => r.Id == model.TenderId).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                //_unitOfWork.TenderChilds.RemoveRange(tender.TenderChilds.Where(x => x.TenderDetailId != null).ToArray());
                //foreach (var child in tender.TenderChilds.Where(x => x.TenderDetailId != null).ToList())
                //{
                //    child.IsDeleted = (byte)TenderChildStatus.Deleted;
                //    _unitOfWork.TenderChilds.Update(child);
                //}
                    
                var servicesToAdd = new List<TenderChild>();
                foreach (var item in tender.TenderChilds.Where(x=>x.TenderDetailId == null).ToList())
                {
                    var modelService = model.contractServices.Where(x => x.Id == item.Id).FirstOrDefault();
                    if(modelService != null)
                    {
                        item.ItemCode = modelService.ItemCode;
                        item.Amount = modelService.Amount;
                        _unitOfWork.TenderChilds.Update(item);
                    }
                    else
                    {
                        item.Amount = 0;
                        _unitOfWork.TenderChilds.Update(item);
                    }
             
                }
                var vehiclesToAdd = new List<TenderChild>();
                foreach (var item in model.contractDetailVehicle)
                {
                    var childVehicleModel = tender.TenderChilds.Where(x => x.Id == item.Id).FirstOrDefault();
                    if(childVehicleModel == null)
                    {
                        var obj = new TenderChild
                        {
                            CustomerId = tender.CustomerId,
                            ItemCode = item.ItemCode,
                            TenderId = model.TenderId,
                            VehicleId = item.VehicleId,
                            Amount = item.Amount,
                            TenderDetailId = item.DetailId,
                            IsDeleted = (byte)TenderChildStatus.Active
                        };
                        _unitOfWork.TenderChilds.Add(obj);
                    }else
                    {
                        childVehicleModel.ItemCode = item.ItemCode;
                        childVehicleModel.Amount = item.Amount;
                        _unitOfWork.TenderChilds.Update(childVehicleModel);
                    }
                 
                }
                _unitOfWork.Tenders.Update(tender);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
       
        }

        public IHttpActionResult UpdateTenderVehicle(ContractCreateViewModel model)
        {
            try
            {
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.TenderDetails, y => y.TenderChilds).Where(r => r.Id == model.TenderId).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                foreach (var item in model.contractDetailVehicle)
                {
                    var childVehicleModel = tender.TenderChilds.Where(x => x.TenderDetailId == item.DetailId && x.VehicleId == item.VehicleId).FirstOrDefault();
                    if (childVehicleModel == null)
                    {
                        string itemcode = null;
                        if (tender.ProceedStatus >= (byte)TenderUtility.ContractState)
                        {
                            itemcode = tender.TenderNo + "-" + (tender.TenderChilds.Count + 1);
                        }
                        var obj = new TenderChild
                        {
                            CustomerId = tender.CustomerId,
                            ItemCode = itemcode,
                            TenderId = model.TenderId,
                            VehicleId = item.VehicleId,
                            Amount = item.Amount,
                            TenderDetailId = item.DetailId,
                            IsDeleted = (byte)TenderChildStatus.Active
                        };
                        _unitOfWork.TenderChilds.Add(obj);
                    }
                }
                foreach(var item in tender.TenderChilds.Where(x=>x.IsDeleted != (byte)TenderChildStatus.Deleted && x.VehicleId!=null && x.TenderDetailId != null).ToList())
                {
                    var childVehicleModel = model.contractDetailVehicle.Where(x => x.DetailId == item.TenderDetailId && x.VehicleId == item.VehicleId).FirstOrDefault();
                    if (childVehicleModel == null)
                    {
                        item.IsDeleted = (byte)TenderChildStatus.Deleted;
                        _unitOfWork.TenderChilds.Update(item);
                    }
                }

                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetKeyPairByCustomer(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.Tenders.GetContractKeyPair(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId), Convert.ToInt32(model.CustomerId));
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult ApproveContract(TenderCreateViewModel model)
        {
            try
            {
                //var contract = _unitOfWork.Tenders.Get(model.Id);
                //contract.ProceedStatus = (byte)TenderUtility.ContractApprovedState;
                //contract.LastModifiedDate = DateTime.Now;
                //contract.LastModifiedBy = model.LastModifiedBy;
                //_unitOfWork.Tenders.Update(contract);
                var tender = _unitOfWork.Tenders.Get(model.Id);
                if (tender == null)
                {
                    return NotFound();
                }
                tender.ProceedStatus = (byte)TenderUtility.ContractApprovedState;
                tender.LastModifiedDate = DateTime.Now;
                tender.LastModifiedBy = model.LastModifiedBy;
                var tenderChilds = _unitOfWork.TenderChilds.Find(a => a.TenderId == tender.Id && a.IsDeleted == (byte)TenderChildStatus.Active).ToList();
                // Update services and assigning item code to each.
                int countItemCode = 1;
                foreach (var item in tenderChilds.Where(x=>x.FleetServiceId != null && x.TenderDetailId == null).ToList())
                {
                    item.ItemCode = tender.TenderNo + "-" + countItemCode;
                    _unitOfWork.TenderChilds.Update(item);
                    countItemCode++;
                }
                // Updating vehicle and assigning item code to each.
                foreach (var item in tenderChilds.Where(x => x.TenderDetailId != null && x.FleetServiceId == null).ToList())
                {
                    item.ItemCode = tender.TenderNo + "-" + countItemCode;
                    _unitOfWork.TenderChilds.Update(item);
                    countItemCode++;
                }
                _unitOfWork.Tenders.Update(tender);
                _unitOfWork.SaveChanges();
                return Ok();
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult CancelContract(ContractCancelation model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                _unitOfWork.ContractCancelation.Add(model);
                var contract = _unitOfWork.Tenders.Get(model.ContractId);
                contract.ProceedStatus = (byte)TenderUtility.ContractCancelState;
                contract.LastModifiedDate = DateTime.Now;
                contract.LastModifiedBy = model.CancelationBy.ToString();
                _unitOfWork.Tenders.Update(contract);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }



        [HttpGet]
        public IHttpActionResult GetVendorForContractId(int id)
        {
            try
            {
                var data = _unitOfWork.VendorQuotationChild.AllIncluding(x => x.VendorQuotation, y => y.VendorQuotation.Vendor, z => z.FleetService, u =>u.FleetService.Unit).Where(e => e.VendorQuotation.TenderId == id).ToList();
                var results = (from ssi in data
                                   // here I choose each field I want to group by
                               group ssi by new { ssi.DestinationFromId, ssi.DestinationToId, ssi.VehicleId, ssi.ServiceId } into g
                               select new { DestinationFrom = g.Key.DestinationFromId, DestinationTo = g.Key.DestinationToId, VehicleId = g.Key.VehicleId, FleetServiceId = g.Key.ServiceId, vendorInfo = g.ToList() }).ToList();
                var viewModelList = new List<VendorQuotationsViewModel>();
                foreach (var item in results)
                {
                    var obj = new VendorQuotationsViewModel();
                    var itemCodeDetail = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, a => a.FleetService.Unit, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.VehicleId == item.VehicleId && a.TenderDetail.DestinationFromId == item.DestinationFrom && a.TenderDetail.DestinationToId == item.DestinationTo && a.FleetServiceId == item.FleetServiceId && a.IsDeleted == (byte)TenderChildStatus.Active).FirstOrDefault();
                    if (itemCodeDetail != null)
                    {
                        obj.TenderId = item.vendorInfo.First().VendorQuotation.TenderId;
                        //obj.TendorNo = item.vendorInfo.First().VendorQuotation.Tender.TenderNo;
                        obj.VendorQuotationId = item.vendorInfo.First().VendorQuotationId;
                        obj.VendorQUotationChildId = item.vendorInfo.First().VendorQuotationChildId;

                        if (itemCodeDetail.FleetServiceId != null)
                        {
                            obj.Particulars = itemCodeDetail.FleetService.ServiceName + " " + "-" + " " + itemCodeDetail.FleetService.Unit.Title;

                        }

                        //    obj.Particulars = itemCodeDetail.FleetService.ServiceName + " " + "-" + " " + itemCodeDetail.FleetService.Unit.Title;
                        else
                        obj.Particulars = itemCodeDetail.TenderDetail.City.Name + " To " + itemCodeDetail.TenderDetail.City1.Name + " " + "-" + " " + itemCodeDetail.Vehicle.Title + " " + "-" + " " + itemCodeDetail.Vehicle.Weight;

                        foreach (var p in item.vendorInfo)
                        {
                            obj.vendorInfo.Add(new VendorQuotationApprovalViewModelVendors()
                            {
                                VendorId = p.VendorQuotation.VendorId,
                                VendorName = p.VendorQuotation.Vendor.VendorName,
                                Amount = p.Amount
                            });
                        }

                    }
                    viewModelList.Add(obj);
                }

                //var result = GetGroupedJobQuotations(viewModelList);



                return Ok(viewModelList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
