//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KendoUIDynamicKeyColumn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductShipper
    {
        public int ProductShipper1 { get; set; }
        public int ProductID { get; set; }
        public int ShipperID { get; set; }
    
        public virtual ProductShipper ProductShipper11 { get; set; }
        public virtual ProductShipper ProductShipper2 { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
