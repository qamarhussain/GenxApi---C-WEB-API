using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class ContractCreateViewModel
    {
        public int TenderId { get; set;}
        public int ProceedStatus { get; set; }
        public List<ContractService> contractServices { get; set; }
        public List<ContractDetailVehicle> contractDetailVehicle { get; set; }
        public ContractCreateViewModel()
        {
            contractServices = new List<ContractService>();
            contractDetailVehicle = new List<ContractDetailVehicle>();
        }
    }
    
    public class ContractService
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string ItemCode { get; set; }
    }

    public class ContractDetailVehicle
    {
        public int DetailId { get; set; }
        public int VehicleId { get; set; }
        public string ItemCode { get; set; }
        public decimal Amount { get; set; }
    }
}