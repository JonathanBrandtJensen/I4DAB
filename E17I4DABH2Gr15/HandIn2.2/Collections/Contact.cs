using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HandIn2._2
{
	public class Contact
	{
		[JsonProperty(PropertyName = "id")]
		public string ContactId { get; set; }

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public int[] AddressIds { get; set; }
		public ICollection<Telephone> Telephones { get; set; }
		public ICollection<Email> Emails { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}