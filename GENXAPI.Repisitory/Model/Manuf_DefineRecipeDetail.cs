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
    
    public partial class Manuf_DefineRecipeDetail
    {
        public int CompanyId { get; set; }
        public string InvItemId { get; set; }
        public int WarehoueId { get; set; }
        public int GadownId { get; set; }
        public int BinCardId { get; set; }
        public string RecipeId { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedby { get; set; }
        public int Id { get; set; }
        public int BusinessUnitId { get; set; }
    
        public virtual Manuf_DefineRecipeMaster Manuf_DefineRecipeMaster { get; set; }
    }
}
