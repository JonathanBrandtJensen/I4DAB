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

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public ICollection<Guid> AddressIds { get; set; } = new List<Guid>();
		public ICollection<Telephone> Telephones { get; set; } = new List<Telephone>();
		public ICollection<Email> Emails { get; set; } = new List<Email>();

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}


	}
}