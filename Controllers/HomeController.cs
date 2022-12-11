using RMS.Class;
using RMS.DBProcess;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static RMS.DBProcess.ViewPath;

namespace RMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly RMSDBContext db = new RMSDBContext();
        private readonly HomePath HomePath = new HomePath();

        private static int WrongPasswordCount = 0;
        private static string xUserID = string.Empty;

        public ActionResult Index()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
                {
                    //==Check multiple login validation
                    string SessionUserID = Session["LoginUserID"].ToString();
                    string LoginDateTime = Session["LoginDateTime"].ToString();
                    string LoginDate = db.UserInfos.Where(x => x.UserID == SessionUserID).Select(x => x.LoginDate).FirstOrDefault().ToString();
                    if (LoginDateTime != LoginDate)
                    {
                        return RedirectToAction("SignOut", "Home");
                    }
                    //==
                    return View(HomePath.IndexDashboard);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }

        public ActionResult Login()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
                {
                    //==Check multiple login validation
                    string SessionUserID = Session["LoginUserID"].ToString();
                    string LoginDateTime = Session["LoginDateTime"].ToString();
                    string LoginDate = db.UserInfos.Where(x => x.UserID == SessionUserID).Select(x => x.LoginDate).FirstOrDefault().ToString();
                    if (LoginDateTime != LoginDate)
                    {
                        return RedirectToAction("SignOut", "Home");
                    }
                    //==
                    return View(HomePath.IndexDashboard);
                }
                else
                {
                    xUserID = string.Empty;
                    WrongPasswordCount = 0;
                    return View(HomePath.Login);
                }
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }

        [HttpGet]
        public ActionResult PingServer()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception Ex)
                {
                    ErrorPath ErrorPath = new ErrorPath();
                    return View(ErrorPath.Index);
                }
            }
            else
            {
                return View(HomePath.Login);
            }
        }

        public string GetHDDSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] != null)
                    return wmi_HD["SerialNumber"].ToString();
            }
            return string.Empty;
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult SignIn(string UserID, string Password, string BrowserName)
        {
            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                //==Check piracy protected
                var EmailInfo  = db.EmailAccounts.Where(x => x.EmailSLNo == 1).Select(x => new { x.EmailHeader, x.IsVariantDaysCount, x.IsSpaceAllocation }).SingleOrDefault();
                //==Software Piracy Protection
                string EHeader = AesOperation.DecryptString(key, EmailInfo.EmailHeader);
                if (EHeader != GetHDDSerial().Trim())
                {
                    return Json(new { CheckStatus = true, CheckPiracy = "Protected" }, JsonRequestBehavior.AllowGet);
                }
                //==Temp Condition for BBL UAT
                //if (db.AgreementInfos.Count() > 400)
                //{
                //    return Json(new { CheckStatus = true, CheckPiracy = "Protected" }, JsonRequestBehavior.AllowGet);
                //}
                //==Check user wise wrong password count
                if (xUserID == string.Empty)
                {
                    xUserID = UserID;
                }
                else if (xUserID != UserID)
                {
                    xUserID = UserID;
                    WrongPasswordCount = 0;
                }
                DTOBasic DTOBasic = new DTOBasic();
                //==Encrypt UserSLNo
                var encryptedString = AesOperation.EncryptString(key, Password);
                //==
                //==Check User ID and Password match or not
                var UserInfo = db.UserInfos.Where(x => x.UserID == UserID && x.Status == DTOBasic.active && x.IsDeleted == false).SingleOrDefault();
                if (UserInfo == null)
                {
                    return Json(new { CheckStatus = false, CheckType = "LoginFailed" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (UserInfo.Password != encryptedString)
                    {
                        //=======Check if account already locked
                        if (UserInfo.IsLocked == true)
                        {
                            DateTime LockedDate = DateTime.ParseExact(UserInfo.LockedDate?.ToString("MM/dd/yyyy hh:mm tt"), "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                            DateTime endTime = DateTime.Now;
                            TimeSpan span = endTime.Subtract(LockedDate);
                            if (span.Minutes <= 5)
                            {
                                return Json(new { CheckStatus = true, IsLocked = true }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        //=======Check 3 times wrong password and locked the account
                        WrongPasswordCount++;
                        if (WrongPasswordCount == 3)
                        {
                            WrongPasswordCount = 0;
                            //=======Update User Table and locked the account
                            UserInfo.IsLocked = true;
                            UserInfo.LockedDate = DateTime.Now;
                            db.Entry(UserInfo).State = EntityState.Modified;
                            db.SaveChanges();
                            return Json(new { CheckStatus = true, IsLocked = true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { CheckStatus = false, CheckType = "LoginFailed" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["LoginUserSLNo"] = UserInfo.UserSLNo;
                        System.Web.HttpContext.Current.Session["IsSpaceAllocation"] = EmailInfo.IsSpaceAllocation;
                        //==Check IsUpdatePassword true or false
                        if (UserInfo.IsUpdatePassword == false)
                        {
                            return Json(new { CheckStatus = true, IsUpdatePassword = false }, JsonRequestBehavior.AllowGet);
                        }
                        //==Password Expired Check, if expired then show Reset Password
                        else if (UserInfo.PasswordExpiredDate < System.DateTime.Now)
                        {
                            return Json(new { CheckStatus = true, IsUpdatePassword = false }, JsonRequestBehavior.AllowGet);
                        }
                        //==Check the lockout time interval 10 mnts
                        if (UserInfo.IsLocked == true)
                        {
                            DateTime LockedDate = DateTime.ParseExact(UserInfo.LockedDate?.ToString("MM/dd/yyyy hh:mm tt"), "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                            DateTime endTime = DateTime.Now;
                            TimeSpan span = endTime.Subtract(LockedDate);
                            if (span.Minutes <= 5)
                            {
                                return Json(new { CheckStatus = true, IsLocked = true }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                //=======Update User Table and unlocked the account
                                UserInfo.IsLocked = false;
                                db.Entry(UserInfo).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        //==Get Local IP Address
                        string ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ipAddress))
                        {
                            ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        }
                        //==Check the user account not used last 30 days
                        if (UserInfo.LoginDate != null)
                        {
                            DateTime LoginDate = DateTime.ParseExact(UserInfo.LoginDate?.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            if ((DateTime.Now.Date - LoginDate.Date).Days > 30)
                            {
                                //=======Update User Table
                                UserInfo.Status = DTOBasic.InActive;
                                UserInfo.LoginDate = null;
                                db.Entry(UserInfo).State = EntityState.Modified;
                                db.SaveChanges();
                                return Json(new { CheckStatus = true, IsInActive = true }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            if ((DateTime.Now.Date - UserInfo.EntryDate.Date).Days > 30)
                            {
                                //=======Update User Table
                                UserInfo.Status = DTOBasic.InActive;
                                UserInfo.LoginDate = null;
                                db.Entry(UserInfo).State = EntityState.Modified;
                                db.SaveChanges();
                                return Json(new { CheckStatus = true, IsInActive = true }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        //==Check unique login session, ask to logout the previous session
                        if (UserInfo.IsLogin == true)
                        {
                            return Json(new { CheckStatus = true, UserLogin = true, UserID = UserID, BrowserName = BrowserName, ipAddress = ipAddress }, JsonRequestBehavior.AllowGet);
                        }
                        //==Logged In
                        //==Log Register
                        RMS.Models.LogRegister LR = new RMS.Models.LogRegister();
                        LR.UserSLNo = UserInfo.UserSLNo;
                        LR.LoginDate = DateTime.Now;
                        LR.BrowserName = BrowserName;
                        LR.IPAddress = ipAddress;
                        db.LogRegisters.Add(LR);
                        db.SaveChanges();
                        //=======Update User Table
                        UserInfo.IsLogin = true;
                        UserInfo.BrowserName = BrowserName;
                        UserInfo.IPAddress = ipAddress;
                        UserInfo.LoginDate = LR.LoginDate;
                        db.Entry(UserInfo).State = EntityState.Modified;
                        db.SaveChanges();
                        //==Session Variable
                        System.Web.HttpContext.Current.Session["LoginUserID"] = UserID;
                        System.Web.HttpContext.Current.Session["LoginDateTime"] = LR.LoginDate;
                        return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception Ex)
            {
                return Json(new { CheckStatus = false, CheckType = "Error", CheckInfo = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult SignInByForce(string UserID, string BrowserName, string ipAddress)
        {
            try
            {
                DTOBasic DTOBasic = new DTOBasic();
                //==Check User ID and Password match or not
                var UserInfo = db.UserInfos.Where(x => x.UserID == UserID && x.Status == DTOBasic.active && x.IsDeleted == false).SingleOrDefault();
                if (UserInfo == null)
                {
                    return Json(new { CheckStatus = false, CheckType = "LoginFailed" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //==Logged In
                    //TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    //System.Web.HttpContext.Current.Session["LoginUserID"] = textInfo.ToTitleCase(UserID);
                    //==Log Register
                    RMS.Models.LogRegister LR = new RMS.Models.LogRegister();
                    LR.UserSLNo = UserInfo.UserSLNo;
                    LR.LoginDate = DateTime.Now;
                    LR.BrowserName = BrowserName;
                    LR.IPAddress = ipAddress;
                    db.LogRegisters.Add(LR);
                    db.SaveChanges();
                    //=======Update User Table
                    UserInfo.IsLogin = true;
                    UserInfo.BrowserName = BrowserName;
                    UserInfo.IPAddress = ipAddress;
                    UserInfo.LoginDate = LR.LoginDate;
                    db.Entry(UserInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    //==Session Variable
                    System.Web.HttpContext.Current.Session["LoginUserSLNo"] = UserInfo.UserSLNo;
                    System.Web.HttpContext.Current.Session["LoginUserID"] = UserID;
                    System.Web.HttpContext.Current.Session["LoginDateTime"] = LR.LoginDate;
                    return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                return Json(new { CheckStatus = false, CheckType = "Error", CheckInfo = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            try
            {
                UriLocations UriLocations = new UriLocations();
                ViewBag.SingIn = "Home/Index";
                return View(HomePath.ForgotPassword);
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(RMS.Models.ForgotPasswordViewModelDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.UserInfos.Where(x => x.Email == model.Email).SingleOrDefault();
                    if (user == null)
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        return View("ForgotPassword");
                    }
                    //==Encrypt UserSLNo
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var encryptedString = AesOperation.EncryptString(key, user.UserSLNo.ToString());
                    //==
                    var EmailAccount = db.EmailAccounts.Where(x => x.EmailSLNo == 1).SingleOrDefault();
                    UriLocations UriLocations = new UriLocations();
                    var body = new StringBuilder();
                    body.AppendFormat("Hello {0}\n", user.FirstName + " " + user.LastName + ",\n");
                    body.AppendLine(@"please click the link to reset your password");
                    body.AppendLine("<a href=" + model.baseUri + "Home/RedirectToResetPassword?encrypted=" + encryptedString + ">Reset Password</a>");
                    var client = new SmtpClient(EmailAccount.EmailSMTP, EmailAccount.SMTPPortNo)
                    {
                        //Credentials = new NetworkCredential(EmailAccount.EmailAddress, EmailAccount.EmailPassword),
                        EnableSsl = false
                    };
                    MailMessage mail = new MailMessage();
                    mail.To.Add(new MailAddress(user.Email));
                    mail.From = new MailAddress("noreply@thecitybank.com", "RMS");
                    mail.Subject = "Reset Password";
                    mail.IsBodyHtml = true;
                    mail.Body = body.ToString();
                    client.Send(mail);

                    TempData.Remove("UserEmail");
                    TempData.Add("UserEmail", model.Email);
                    return RedirectToAction("ForgotPasswordConfirmation", "Home");
                }
                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception Ex)
            {
                return RedirectToAction("Login", "Home");
                //ViewBag.Message = Ex.ToString();
                //return View(HomePath.DisplayMessage);
            }
        }

        [HttpGet]
        public ActionResult ForgotPasswordConfirmation()
        {
            try
            {
                var UserEmail = TempData["UserEmail"];
                if (UserEmail == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                ViewBag.UserEmail = UserEmail;
                return View("ForgotPasswordConfirmation");
            }
            catch (Exception Ex)
            {
                return RedirectToAction("Login", "Home");
                //ViewBag.Message = Ex.ToString();
                //return View(HomePath.DisplayMessage);
            }
        }

        [HttpGet]
        public ActionResult RedirectToResetPassword(string encrypted)
        {
            try
            {
                //==Fix invalid length for a Base-64 string
                encrypted = HttpUtility.UrlDecode(encrypted);
                encrypted = encrypted.Replace(" ", "+");//to remove any empty spaces
                encrypted = encrypted.Replace('-', '+').Replace('_', '/');//replace special char
                while (encrypted.Length % 4 != 0) encrypted += '='; //it should be divisible by 4 or append = 
                //==
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                TempData.Remove("UserSLNo");
                TempData.Add("UserSLNo", AesOperation.DecryptString(key, encrypted));
                return RedirectToAction("ResetPassword");
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }


        [HttpGet]
        public ActionResult ResetPassword()
        {
            try
            {
                int UserSLNo = 0;
                if (Session["LoginUserSLNo"] == null)
                {
                    var strUserSLNo = TempData["UserSLNo"];
                    if (strUserSLNo == null)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    UserSLNo = Convert.ToInt32(strUserSLNo);
                }
                else
                {
                    UserSLNo = (int)Session["LoginUserSLNo"];
                }
                AgreementInfoPath AgreementInfoPath = new AgreementInfoPath();
                DTOBasic DTOBasic = new DTOBasic();
                UserInfoLocation UserInfoLocation = new UserInfoLocation();
                RMS.Models.UserInfoDTO DTO = new RMS.Models.UserInfoDTO();
                var UserInfo = db.UserInfos.Where(x => x.UserSLNo == UserSLNo).SingleOrDefault();
                DTO.UserSLNo = UserInfo.UserSLNo;
                DTO.Email = UserInfo.Email;
                DTO.UserID = UserInfo.UserID;
                DTO.FirstName = UserInfo.FirstName;
                DTO.LastName = UserInfo.LastName;
                return View("ResetPassword", DTO);
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult ResetPassword(int UserSLNo, string Password)
        {
            try
            {
                //==Encrypt UserSLNo
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var encryptedString = AesOperation.EncryptString(key, Password);
                //==
                RMS.Models.UserInfo UI = db.UserInfos.Where(x => x.UserSLNo == UserSLNo).SingleOrDefault();
                UI.Password = encryptedString;
                UI.IsUpdatePassword = true;
                UI.PasswordExpiredDate = DateTime.Now.AddDays(30);
                db.Entry(UI).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ErrorPath ErrorPath = new ErrorPath();
                return View(ErrorPath.Index);
            }
        }

        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public sealed class ValidateHeaderAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                var httpContext = filterContext.HttpContext;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
            }
        }

        public ActionResult IndexDashboard()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    return View(HomePath.IndexDashboard);
                }
                catch (Exception Ex)
                {
                    ErrorPath ErrorPath = new ErrorPath();
                    return View(ErrorPath.Index);
                }
            }
            else
            {
                return View(HomePath.Login);
            }
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            //Session.Clear();
            //System.Web.HttpContext.Current.Session.Clear();
            //Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

    }
}