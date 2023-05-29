using System;
using System.Collections.Generic;
using System.Text;

namespace DT.Domain.Entities
{
    public class User : BaseEntity
    {
        public int userPosts { get; set; }
        public int userTodos { get; set; }
    }
}