using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public int id { get; set; }
        public string todo { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}