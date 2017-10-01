using System.ComponentModel.DataAnnotations;

namespace HandIn2._1
{
    public class Email
    {
		[Key]
        public string EmailId { get; set; }
        [Required]
        public  string EmailType { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
    }
}