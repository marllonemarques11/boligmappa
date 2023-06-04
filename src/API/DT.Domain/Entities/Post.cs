using System;
using System.Collections.Generic;
using System.Text;

namespace DT.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string body { get; set; }
        public bool hasFrenchTag { get; set; }
        public bool hasFictionTag { get; set; }
        public bool hasMoreThanTwoReaction { get; set; }
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}