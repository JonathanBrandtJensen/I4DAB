using System;
using System.Collections.Generic;
using HandIn2._2.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HandIn2._2.Collections.ContactCollection
{
	public class Contact : IHasIdentifier
	{
	    [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public ICollection<Guid> AddressIds { get; set; }
		public ICollection<Telephone> Telephones { get; set; }
		public ICollection<Email> Emails { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}