namespace Handin3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Telephone
    {
        [Key]
        public string TelephoneNr { get; set; }

        [Required]
        public string TelephoneType { get; set; }

        [Required]
        public string PhoneCompany { get; set; }

        public int Contact_PersonId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
