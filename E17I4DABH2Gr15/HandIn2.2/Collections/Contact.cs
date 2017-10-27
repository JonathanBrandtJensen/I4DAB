using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HandIn2._2
{
	public class Contact
	{
	    [JsonProperty(PropertyName = "id")]
        public Guid ContactId { get; set; }

	    private string _contactId;

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