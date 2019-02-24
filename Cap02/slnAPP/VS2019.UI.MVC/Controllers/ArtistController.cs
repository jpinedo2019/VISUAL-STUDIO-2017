using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VS2019.Data;

namespace VS2019.UI.MVC.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        //el controlador tiene una vista
        public ActionResult Index()
        {
            var da = new ArtistDA();

            var model = da.Gets();

            return View(model);
        }
    }
}