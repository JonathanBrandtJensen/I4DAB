using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandIn2._1
{
    public class PostCode
    {
	    public PostCode()
	    {
		    this.Address = new HashSet<Address>();
	    }

	    [Key]
		public string PostCodeId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public virtual ICollection<Address> Address { get; set; }
    }
}