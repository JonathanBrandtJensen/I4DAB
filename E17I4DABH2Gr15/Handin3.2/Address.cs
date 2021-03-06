namespace Handin3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Contacts = new HashSet<Contact>();
        }

        [Key]
        public int Addresses { get; set; }

        [Required]
        public string AddressType { get; set; }

        [Required]
        public string Streetname { get; set; }

        [Required]
        [StringLength(128)]
        public string PostCode_PostCodeId { get; set; }

        [Required]
        public string HousNr { get; set; }

        public virtual PostCode PostCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }
    }

    public partial class AddressDTO
    {

        public int Addresses { get; set; }

        public string AddressType { get; set; }

        public string Streetname { get; set; }

        public string HousNr { get; set; }

        public string PostCodes { get; set; }

        public List<int> ContactIds { get; set; }
    }
}