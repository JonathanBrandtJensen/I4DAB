using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn2._1
{
    public class Telephone
    {
		[Key]
        public string TelephoneNr { get; set; }
        [Required]
        public string TelephoneType { get; set; }
        [Required]
        public string PhoneCompany { get; set; }
		public virtual Contact Contact { get; set; }
    }
}