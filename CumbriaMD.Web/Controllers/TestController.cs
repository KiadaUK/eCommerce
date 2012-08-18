using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumbriaMD.Infrastructure.ViewModels.ImageViewModels;
using CumbriaMD.Infrastructure.ViewModels.TestViewModels;

namespace CumbriaMD.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        [HttpGet]
        public ActionResult Index()
        {

            var model = new MultiImageUploader();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MultiImageUploader multiImageUploader)
        {

            if(!ModelState.IsValid)
            {
                return View(multiImageUploader); 
            }


            return RedirectToAction("Blah");
        }

    }
}
