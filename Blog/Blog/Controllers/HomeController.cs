using System;
using Blog.Domain;
using Blog.Web.Models;
using Blog.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly BlogPostRepository _postRepo;

    public HomeController(ILogger<HomeController> logger, BlogPostRepository postRepo)
    {
      _logger = logger;
      _postRepo = postRepo;
    }
   
    public IActionResult Index(int? id)
    {
      var post = id == null 
        ? _postRepo.PostWithHighestRating()
        : _postRepo.GetPostById((int) id);

      if (post == null)
      {
        return View("NoPosts");
      }

      var homeViewModel = new HomeViewModel()
      {
        BlogPost = post,
        RecommendedPosts = _postRepo.GetRelatedPosts(post.Id)
      };

      return View(homeViewModel);
    }

    public RedirectToActionResult UpVote(int id)
    {
      _postRepo.ChangeRating(id, 1);
      return RedirectToAction("Index", new { id });
    }

    public RedirectToActionResult DownVote(int id)
    {
      _postRepo.ChangeRating(id, -1);
      throw new Exception();

      return RedirectToAction("Index", new { id });
    }

    public RedirectToActionResult DeletePost(int id)
    {
      _postRepo.RemovePost(id);
      return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
