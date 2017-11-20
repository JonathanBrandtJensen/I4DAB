namespace Handin3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Email
    {
        [Key]
        public string Emails { get; set; }

        [Required]
        public string EmailType { get; set; }

        public int Contact_PersonId { get; set; }

        public virtual Contact Contact { get; set; }
    }
    public partial class EmailDTO
    {
        public string Emails { get; set; }
        public string EmailType { get; set; }
        public int ContactId { get; set; }
    }
}
