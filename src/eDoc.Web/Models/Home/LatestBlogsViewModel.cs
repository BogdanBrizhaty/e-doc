using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models.Home
{
    public class LatestBlogsViewModel
    {
        public IEnumerable<ShortBlogPostViewModel> Blogs { get; set; }
    }
    public class ShortBlogPostViewModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}