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
    
    public partial class CartLines
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CartLines()
        {
            this.Picture = new HashSet<Picture>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public string Comments { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.Guid> StyleId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public int Quantity { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Styles Styles { get; set; }
        public virtual Sizes Sizes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Picture { get; set; }
    }
}
