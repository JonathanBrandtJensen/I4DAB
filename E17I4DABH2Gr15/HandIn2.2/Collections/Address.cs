using System.Collections.Generic;

namespace HandIn2._2
{
    public class Address
    {
        public string AddressId { get; set; }

        public string AddressType { get; set; }
		public string Streetname { get; set; }
		public string HousNr { get; set; }
	    public string PostCodeId { get; set; }
	    public int[] ContactIds { get; set; }
    }
}