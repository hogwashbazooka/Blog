
using System.Collections.Generic;
using Blog.Domain;

namespace Blog.Web.ViewModels
{
  public class HomeViewModel
  {
    public BlogPost BlogPost { get; set; }
    public IEnumerable<BlogPost> RecommendedPosts { get; set; }
  }
}
