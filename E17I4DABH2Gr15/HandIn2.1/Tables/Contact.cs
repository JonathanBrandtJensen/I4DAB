using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HandIn2._1
{
	public class Contact
    {
	    public Contact()
	    {
		    this.Addresses = new HashSet<Address>();
			this.Telephones = new HashSet<Telephone>();
			this.Emails = new HashSet<Email>();
	    }

		[Key]
		public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonType { get; set; }
		public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}