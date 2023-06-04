using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DT.Domain.Entities
{
    public class User : BaseEntity
    {
        private readonly ILazyLoader _lazyLoader;
        public User()
        {
        }
        public User(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private ICollection<Post> _posts;
        private ICollection<Todo> _todos;

        public string userName { get; set; }
        public int userPosts { get; set; }
        public int userTodos { get; set; }
        public string cardType { get; set; }
        public virtual ICollection<Post> Posts
        {
            get => _lazyLoader.Load(this, ref _posts);
            set => _posts = value;
        }
        public virtual ICollection<Todo> Todos
        {
            get => _lazyLoader.Load(this, ref _todos);
            set => _todos = value;
        }
    }
}