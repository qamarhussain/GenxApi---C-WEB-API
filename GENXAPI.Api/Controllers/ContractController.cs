﻿using GENXAPI.Api.Attributes;
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
                var contract = _unitOfWork.Tenders.Get(model.Id);
                contract.ProceedStatus = (byte)TenderUtility.ContractApprovedState;
                contract.LastModifiedDate = DateTime.Now;
                contract.LastModifiedBy = model.LastModifiedBy;
                _unitOfWork.Tenders.Update(contract);
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
                model.CancelationDate = DateTime.Now;
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

    }
}
