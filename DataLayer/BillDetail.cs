//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillDetail
    {
        public int ID { get; set; }
        public Nullable<int> billID { get; set; }
        public Nullable<int> medID { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal amount { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
