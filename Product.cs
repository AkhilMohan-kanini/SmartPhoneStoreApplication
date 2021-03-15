//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartPhoneStoreApplication
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Orders = new HashSet<Order>();
            this.Carts = new HashSet<Cart>();
        }
    
        public int ProductID { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string Display { get; set; }
        public string Battery { get; set; }
        public string PrimaryCamera { get; set; }
        public string SecondaryCamera { get; set; }
        public string Processor { get; set; }
        public string Color { get; set; }
        public string SimType { get; set; }
        public string OsName { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> Price { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
