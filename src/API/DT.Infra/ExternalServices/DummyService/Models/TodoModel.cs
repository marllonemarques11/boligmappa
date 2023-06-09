using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DT.Infra.ExternalServices.DummyService.Models
{
    [Serializable]
    public class TodoModel
    {
        [JsonProperty("todos")]
        public List<TodoDescription> desc { get; set; }
        
    }
    [Serializable]
    public class TodoDescription
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("todo")]
        public string todo { get; set; }
        [JsonProperty("completed")]
        public bool completed { get; set; }
        [JsonProperty("userId")]
        public int userId { get; set; }
    }
}