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
    
    public partial class Styles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Styles()
        {
            this.CartLines = new HashSet<CartLines>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal B2BPrice { get; set; }
        public string Picture { get; set; }
        public int AmountOfPictures { get; set; }
        public bool Published { get; set; }
        public System.DateTime Created { get; set; }
        public int SortOrder { get; set; }
        public bool NoFollow { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoTitle { get; set; }
        public string SeName { get; set; }
        public bool HasText { get; set; }
        public string Poster { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartLines> CartLines { get; set; }
    }
}
