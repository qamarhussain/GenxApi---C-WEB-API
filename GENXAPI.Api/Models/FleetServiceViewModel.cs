using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class FleetServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public Nullable<int> UnitOfMeasurement { get; set; }
        public Unit unit { get; set; }
    }
}