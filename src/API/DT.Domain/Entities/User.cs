using System;
using System.Collections.Generic;
using System.Text;

namespace DT.Domain.Entities
{
    public class User : BaseEntity
    {
        public string userName { get; set; }
        public int userPosts { get; set; }
        public int userTodos { get; set; }
        public string cardType { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}