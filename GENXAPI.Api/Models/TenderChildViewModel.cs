using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class TenderChildViewModel
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public int TenderId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> FleetServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public string UnitOfMeasurement { get; set; }

        public Nullable<int> TenderDetailId { get; set; }
    }
}