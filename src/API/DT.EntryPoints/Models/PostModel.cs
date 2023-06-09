using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.EntryPoints.Models
{
    public class PostModel
    {
        public string userName { get; set; }
        public IEnumerable<string> posts { get; set; }
    }
}