using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn2._1
{
    public class Address
    {
	    public Address()
	    {
		    this.Contact = new HashSet<Contact>();
	    }

		[Key]
        public int AddressId { get; set; }
        [Required]
        public string AddressType { get; set; }
        [Required]
        public string Streetname { get; set; }
        [Required]
        public string HousNr { get; set; }
        public virtual PostCode PostCode{ get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
    }
}