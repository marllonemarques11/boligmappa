using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Infra.ExternalServices.DummyService.Utils;
using Newtonsoft.Json;

namespace DT.Infra.ExternalServices.DummyService.Models
{
    [Serializable]
    public class UserModel
    {
        [JsonProperty("users")]
        public List<UserDescription> desc { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class UserDescription
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [JsonProperty("bank.cardType")]
        public string cardType { get; set; }
    }
}