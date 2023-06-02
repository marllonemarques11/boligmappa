using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.ExternalServices.DummyService.Models;


namespace DT.Infra.ExternalServices.DummyService.Utils
{
    public class Converter
    {
        public List<User> UserModelToEntity(List<UserDescription> users, List<PostDescription> posts, List<TodoDescription> todos)
        {
            List<User> entities = new List<User>();

            foreach (var model in users)
            {
                User entity = new User();

                entity.id = model.id;
                entity.userName = model.firstName;
                entity.cardType = model.cardType;
                entity.userPosts = posts.Where(p => p.userId == entity.id).Count();
                entity.userTodos = todos.Where(p => p.userId == entity.id).Count();
                entities.Add(entity);
            }
            return entities;
        }

        public List<Post> PostModelToEntity(List<UserDescription> users, List<PostDescription> posts, List<TodoDescription> todos)
        {
            List<Post> entities = new List<Post>();

            foreach (var model in posts)
            {
                Post entity = new Post();

                entity.id = model.id;
                entity.userId = model.userId;
                entity.hasFrenchTag = model.tags.Contains("french");
                entity.hasFictionTag = model.tags.Contains("fiction");
                entity.hasMoreThanTwoReaction = (model.reactions > 2);
                entity.body = model.body;
                entities.Add(entity);
            }
            return entities;
        }

        public List<Todo> TodoModelToEntity(List<TodoDescription> todos)
        {
            List<Todo> entities = new List<Todo>();

            foreach (var model in todos)
            {
                Todo entity = new Todo();

                entity.id = model.id;
                entity.todo = model.todo;
                entity.userId = model.userId;
                entities.Add(entity);
            }
            return entities;
        }
    }
}