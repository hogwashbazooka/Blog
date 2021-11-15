using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Web.Models;

namespace Blog.Web.Controllers
{
  public class CreatePostController : Controller
  {
    private readonly BlogPostRepository _blogPostRepository;

    public CreatePostController(BlogPostRepository blogPostRepository)
    {
      _blogPostRepository = blogPostRepository;
    }
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public RedirectToActionResult CreatePost(BlogPost post)
    { 
      _blogPostRepository.AddPost(post);
      return RedirectToAction("Index", "Home");
    }
  }
}
