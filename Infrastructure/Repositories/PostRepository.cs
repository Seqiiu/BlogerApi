using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerContxt _context;

        public PostRepository(BloggerContxt context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }
        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }
        public Post Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
