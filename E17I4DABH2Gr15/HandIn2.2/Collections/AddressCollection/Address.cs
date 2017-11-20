using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HandIn2._2.Collections.AddressCollection
{
    public class Address : IHasIdentifier
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string AddressType { get; set; }
		public string Streetname { get; set; }
		public string HousNr { get; set; }
	    public PostCode PostCode { get; set; }
	    public ICollection<Guid> ContactIds { get; set; }
    }
}