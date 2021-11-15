using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Domain;

namespace Blog.Web.Models
{
  public class BlogPostRepository
  {
    private readonly BlogContext _blogContext;

    public BlogPostRepository(BlogContext context)
    {
      _blogContext = context;
    }

    public void AddPost(BlogPost post)
    {
      post.PostDate = DateTime.Now;
      _blogContext.BlogPosts.Add(post);
      _blogContext.SaveChanges();
    }

    public void RemovePost(int id)
    {
      var post = _blogContext.BlogPosts.Find(id);
      
      if (post != null)
      {
        _blogContext.BlogPosts.Remove(post);
        _blogContext.SaveChanges();
      }
    }

    public BlogPost PostWithHighestRating()
    {
      var post = _blogContext.BlogPosts
        .OrderByDescending(p => p.Rating)
        .FirstOrDefault();
      return post;
    }

    public List<BlogPost> GetAllPosts()
    {
      return _blogContext.BlogPosts
        .OrderByDescending(p => p.Rating)
        .ToList();
    }

    public List<BlogPost> GetRelatedPosts(int id)
    {
      return _blogContext.BlogPosts
        .OrderByDescending(p => p.Rating)
        .Where(p => p.Id != id)
        .ToList();
    }

    public BlogPost GetPostById(int id)
    {
      return _blogContext.BlogPosts.Find(id);
    }

    public void ChangeRating(int id, int increment)
    {
      var post = _blogContext.BlogPosts.Find(id);
      post.Rating += increment;
      _blogContext.BlogPosts.Update(post);
      _blogContext.SaveChanges();
    }
  }
}
