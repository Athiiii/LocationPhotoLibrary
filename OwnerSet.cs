//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocationPhotoLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class OwnerSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OwnerSet()
        {
            this.AdressSet = new HashSet<AdressSet>();
        }
    
        public int Id { get; set; }
        public bool Company { get; set; }
        public string AssignedPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdressSet> AdressSet { get; set; }
    }
}
