using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.DummyClient.Models
{
    public class TodoModel
    {
        public string userName { get; set; }
        public List<string> todos { get; set; }
    }
}