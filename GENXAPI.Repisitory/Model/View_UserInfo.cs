//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GENXAPI.Repisitory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_UserInfo
    {
        public System.Guid Login { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Emp_CompanyId { get; set; }
        public string Emp_Id { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public System.DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
