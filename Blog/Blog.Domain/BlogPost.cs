using System;

namespace Blog.Domain
{
  public class BlogPost
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PostDate { get; set; }
    public int Rating { get; set; }
  }
}
