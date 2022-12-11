using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Accounting.Controllers.Utility
{
    [ValidateAntiForgeryToken]

    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            string LoginUserID = Session["LoginUserID"].ToString();
            ViewBag.LoginUserID = LoginUserID;
            RMS.DBProcess.ViewPath.ErrorPath ErrorPath = new RMS.DBProcess.ViewPath.ErrorPath();
            return View(ErrorPath.Index);
        }

        public ActionResult NotFound404()
        {
            string LoginUserID = Session["LoginUserID"].ToString();
            ViewBag.LoginUserID = LoginUserID;
            RMS.DBProcess.ViewPath.ErrorPath ErrorPath = new RMS.DBProcess.ViewPath.ErrorPath();
            return View(ErrorPath.Index);
        }
    }
}
