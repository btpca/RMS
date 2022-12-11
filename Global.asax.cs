using Accounting.Controllers.Utility;
using RMS.DBProcess;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            if (Session["LoginUserSLNo"] != null)
            {
                RMSDBContext db = new RMSDBContext();
                //==Check multiple login validation
                string UserID = Session["LoginUserID"].ToString();
                string LoginDateTime = Session["LoginDateTime"].ToString();
                string LoginDate = db.UserInfos.Where(x => x.UserID == UserID).Select(x => x.LoginDate).FirstOrDefault().ToString();
                if (LoginDateTime == LoginDate)
                {
                    //=======Update User Table
                    int UserSLNo = (int)Session["LoginUserSLNo"];
                    var UserInfo = db.UserInfos.Where(x => x.UserSLNo == UserSLNo).SingleOrDefault();
                    UserInfo.IsLogin = false;
                    UserInfo.BrowserName = null;
                    UserInfo.IPAddress = null;
                    db.Entry(UserInfo).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values["controller"] = "\\Controllers\\Utility\\ErrorController";

            if ((Context.Server.GetLastError() is HttpException) && ((Context.Server.GetLastError() as HttpException).GetHttpCode() != 404))
            {
                routeData.Values["action"] = "Index";
            }
            else
            {
                //Handle 404 error and response code
                Response.StatusCode = 404;
                routeData.Values["action"] = "NotFound404";
            }
            Response.TrySkipIisCustomErrors = true; // If you are using IIS7, have this line
            IController errorsController = new ErrorController();
            HttpContextWrapper wrapper = new HttpContextWrapper(Context);
            var rc = new System.Web.Routing.RequestContext(wrapper, routeData);
            errorsController.Execute(rc);

            Response.End();
        }
        //==
    }
}
