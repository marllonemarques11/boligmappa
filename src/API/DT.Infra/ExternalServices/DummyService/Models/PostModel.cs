using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DT.Infra.ExternalServices.DummyService.Models
{
    [Serializable]
    public class PostModel
    {
        [JsonProperty("total")]
        public int total { get; set; }
        [JsonProperty("skip")]
        public int skip { get; set; }
        [JsonProperty("limit")]
        public int limit { get; set; }
        [JsonProperty("posts")]
        public List<PostDescription> desc { get; set; }
    }

    [Serializable]
    public class PostDescription
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("userId")]
        public int userId { get; set; }
        [JsonProperty("reactions")]
        public int reactions { get; set; }
        [JsonProperty("body")]
        public string body { get; set; }
        [JsonProperty("tags")]
        public List<string> tags { get; set; }
    }
}