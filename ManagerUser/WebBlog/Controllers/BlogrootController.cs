using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBlog.Controllers
{
    public class BlogrootController : Controller
    {
        // GET: Blogroot
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}