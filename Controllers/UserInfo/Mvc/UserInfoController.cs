using RMS.Class;
using RMS.DBProcess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using static RMS.DBProcess.ViewPath;

namespace RMS.Controllers.UserInfo.Mvc
{
    public class UserInfoController : Controller
    {
        private readonly RMSDBContext db = new RMSDBContext();
        private readonly UserInfoLocation UserInfoLocation = new UserInfoLocation();
        private readonly HomePath HomePath = new HomePath();
        private readonly UserInfoPath UserInfoPath = new UserInfoPath();
        private readonly UriLocations UriLocations = new UriLocations();
        static string AlertMsg = null;

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

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult ResetDefaultPassword(string UserID)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    var EmailAccount = db.EmailAccounts.Where(x => x.EmailSLNo == 1).SingleOrDefault();
                    //==Encrypt UserSLNo
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var encryptedString = AesOperation.EncryptString(key, EmailAccount.DefaultPassword);
                    //==
                    var UserInfo = db.UserInfos.Where(x => x.UserID == UserID).SingleOrDefault();
                    UserInfo.IsUpdatePassword = false;
                    UserInfo.Password = encryptedString;
                    db.Entry(UserInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception Ex)
                {
                    return Json(new { CheckStatus = false, CheckType = "Error", CheckInfo = Ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return View(HomePath.Login);
            }
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult UnlockUser(string UserID)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    var UserInfo = db.UserInfos.Where(x => x.UserID == UserID).SingleOrDefault();
                    UserInfo.IsLocked = false;
                    db.Entry(UserInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception Ex)
                {
                    return Json(new { CheckStatus = false, CheckType = "Error", CheckInfo = Ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return View(HomePath.Login);
            }
        }

        public ActionResult LogRegister()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    int LoginUserSLNo = Convert.ToInt32(Session["LoginUserSLNo"].ToString());
                    ViewBag.URLPath = "UserInfo/LogRegister";
                    //==Check for Permission
                    bool Check = false;
                    Check = db.UserPermissions.Where(x => x.ChildID == 91 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    if (Check == false)
                    {
                        UserPermissionMessage msg = new UserPermissionMessage();
                        ViewBag.Message = msg.AccessDenied;
                        return View(HomePath.DisplayMessage);
                    }
                    string LoginUserID = Session["LoginUserID"].ToString();
                    ViewBag.LoginUserID = LoginUserID;
                    IList<RMS.Models.LogRegisterDTO> lst = new List<RMS.Models.LogRegisterDTO>();
                    var query = from L in db.LogRegisters
                                join U in db.UserInfos on L.UserSLNo equals U.UserSLNo
                                orderby L.LogID descending
                                select new
                                {
                                    L.LogID,
                                    L.UserSLNo,
                                    U.UserID,
                                    U.FirstName,
                                    U.LastName,
                                    L.LoginDate,
                                    L.BrowserName,
                                    L.IPAddress,
                                };
                    lst = query.AsEnumerable().Select(x => new RMS.Models.LogRegisterDTO
                    {
                        LogID = x.LogID,
                        UserSLNo = x.UserSLNo,
                        UserID = x.UserID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        LoginDate = x.LoginDate,
                        BrowserName = x.BrowserName,
                        IPAddress = x.IPAddress,
                    }).ToList();
                    UserInfoPath UserInfoPath = new UserInfoPath();
                    return View(UserInfoPath.LogRegister, lst);
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

        public ActionResult UserSummary()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    int LoginUserSLNo = Convert.ToInt32(Session["LoginUserSLNo"].ToString());
                    ViewBag.URLPath = "UserInfo/UserSummary";
                    //==Check for Permission
                    bool Check = false;
                    Check = db.UserPermissions.Where(x => x.ChildID == 90 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    if (Check == false)
                    {
                        UserPermissionMessage msg = new UserPermissionMessage();
                        ViewBag.Message = msg.AccessDenied;
                        return View(HomePath.DisplayMessage);
                    }
                    string LoginUserID = Session["LoginUserID"].ToString();
                    ViewBag.LoginUserID = LoginUserID;
                    DTOBasic dtoBasic = new DTOBasic();
                    //IList<RMS.Models.UserInfoDTO> lst1 = new List<RMS.Models.UserInfoDTO>();

                    IList<RMS.Models.UserInfoDTO> lst = new List<RMS.Models.UserInfoDTO>
                        {
                            new RMS.Models.UserInfoDTO {
                                TotalUser = db.UserInfos.Count(),
                                TotalActiveUser = db.UserInfos.Where(x=> x.Status == dtoBasic.active).Count(),
                                TotalInActiveUser = db.UserInfos.Where(x => x.Status == dtoBasic.InActive).Count(),
                                TotalCurrentSession = db.UserInfos.Where(x => x.IsLogin == true).Count()},
                        };

                    //lst[0].TotalUser = db.UserInfos.Count();
                    //lst[0].TotalActiveUser = db.UserInfos.Where(x => x.Status == dtoBasic.active).Count();
                    //lst[0].TotalInActiveUser = db.UserInfos.Where(x => x.Status == dtoBasic.InActive).Count();
                    //lst[0].TotalCurrentSession = db.UserInfos.Where(x => x.IsLogin == true).Count();
                    UserInfoPath UserInfoPath = new UserInfoPath();
                    return View(UserInfoPath.UserSummary, lst);
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

        public ActionResult RedirectToWeb()
        {
            return View("Login", "Home");
        }

        [HttpGet]
        public ActionResult RedirectUserIndex(int ViewID)
        {
            TempData.Remove("ViewID");
            TempData.Add("ViewID", ViewID);
            return RedirectToAction("UserIndex");
        }

        [HttpGet]
        public ActionResult UserIndex()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    //==Check multiple login validation
                    string UserID = Session["LoginUserID"].ToString();
                    string LoginDateTime = Session["LoginDateTime"].ToString();
                    string LoginDate = db.UserInfos.Where(x => x.UserID == UserID).Select(x => x.LoginDate).FirstOrDefault().ToString();
                    if (LoginDateTime != LoginDate)
                    {
                        return RedirectToAction("SignOut", "Home");
                    }
                    //==
                    var strViewID = TempData["ViewID"];
                    if (strViewID == null)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    int ViewID = Convert.ToInt32(strViewID);
                    string LoginUserID = Session["LoginUserID"].ToString();
                    int LoginUserSLNo = Convert.ToInt32(Session["LoginUserSLNo"].ToString());
                    ViewBag.LoginUserID = LoginUserID;
                    ViewBag.URLPath = "UserInfo/RedirectUserIndex?ViewID=" + ViewID;
                    //==Check for Permission
                    bool Check = false;
                    if (ViewID == 1)
                    {
                        Check = db.UserPermissions.Where(x => x.ChildID == 2 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    }
                    else if (ViewID == 2)
                    {
                        Check = db.UserPermissions.Where(x => x.ChildID == 3 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    }
                    else if (ViewID == 3)
                    {
                        Check = db.UserPermissions.Where(x => x.ChildID == 5 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    }
                    else if (ViewID == 4)
                    {
                        Check = db.UserPermissions.Where(x => x.ChildID == 7 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    }
                    else if (ViewID == 5)
                    {
                        Check = db.UserPermissions.Where(x => x.ChildID == 8 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    }
                    if (Check == false)
                    {
                        UserPermissionMessage msg = new UserPermissionMessage();
                        ViewBag.Message = msg.AccessDenied;
                        return View(HomePath.DisplayMessage);
                    }
                    //==
                    List<RMS.Models.UserInfoDTO> lst = new List<RMS.Models.UserInfoDTO>();
                    var query = from U in db.UserInfos
                                join S in db.StatusInfos on U.Status equals S.StatusValue
                                where U.IsDeleted == false
                                orderby U.UserSLNo ascending
                                select new
                                {
                                    U.UserSLNo,
                                    U.Email,
                                    U.UserID,
                                    U.FirstName,
                                    U.LastName,
                                    U.ContactNo1,
                                    U.ContactNo2,
                                    U.Address,
                                    U.Designation,
                                    U.EditBy,
                                    U.EditDate,
                                    U.EntryBy,
                                    U.EntryDate,
                                    U.Status,
                                    U.IsDeleted,
                                    S.StatusName,
                                    U.IsUpdatePassword,
                                    U.PasswordExpiredDate,
                                    U.IsLogin,
                                    U.BrowserName,
                                    U.IPAddress,
                                    U.LoginDate,
                                    U.IsLocked,
                                };
                    lst = query.AsEnumerable().Select(x => new RMS.Models.UserInfoDTO
                    {
                        UserSLNo = x.UserSLNo,
                        Email = x.Email,
                        UserID = x.UserID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ContactNo1 = x.ContactNo1,
                        ContactNo2 = x.ContactNo2,
                        Address = x.Address,
                        Designation = x.Designation,
                        EditBy = x.EditBy,
                        EditDate = x.EditDate,
                        EntryBy = x.EntryBy,
                        EntryDate = x.EntryDate,
                        Status = x.Status,
                        IsDeleted = x.IsDeleted,
                        StatusName = x.StatusName,
                        IsUpdatePassword = x.IsUpdatePassword,
                        PasswordExpiredDate = x.PasswordExpiredDate,
                        IsLogin = x.IsLogin,
                        BrowserName = x.BrowserName,
                        IPAddress = x.IPAddress,
                        LoginDate = x.LoginDate,
                        IsLocked = x.IsLocked,
                    }).ToList();
                    ViewBag.AlertMsg = AlertMsg;
                    AlertMsg = null;
                    if (ViewID == 1)
                    {
                        return View(UserInfoPath.CreateIndex, lst);
                    }
                    else if (ViewID == 2)
                    {
                        return View(UserInfoPath.EditIndex, lst);
                    }
                    else if (ViewID == 3)
                    {
                        return View(UserInfoPath.DeleteIndex, lst);
                    }
                    else if (ViewID == 4)
                    {
                        return View(UserInfoPath.ListOfUsers, lst);
                    }
                    else if (ViewID == 5)
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            int CheckUserSLNo = lst[i].UserSLNo;
                            if (db.UserPermissions.Where(x => (x.ParentID == 1 || x.ParentID == 6) && x.UserSLNo == CheckUserSLNo && x.Checked == true).Any() == true)
                            {
                                lst[i].AdminRole = "yes";
                            }
                            else
                            {
                                lst[i].AdminRole = "No";
                            }
                        }
                        return View(UserInfoPath.ListOfUserDetails, lst);
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
            else
            {
                return View(HomePath.Login);
            }
        }

        [HttpGet]
        public ActionResult RedirectUserDetails(int UserSLNo)
        {
            TempData.Remove("UserSLNo");
            TempData.Add("UserSLNo", UserSLNo);
            return RedirectToAction("UserDetails");
        }

        [HttpGet]
        public ActionResult UserDetails()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    var strUserSLNo = TempData["UserSLNo"];
                    if (strUserSLNo == null)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    int UserSLNo = Convert.ToInt32(strUserSLNo);
                    string LoginUserID = Session["LoginUserID"].ToString();
                    int LoginUserSLNo = Convert.ToInt32(Session["LoginUserSLNo"].ToString());
                    ViewBag.LoginUserID = LoginUserID;
                    ViewBag.URLPath = "UserInfo/RedirectUserIndex?ViewID=5";
                    List<RMS.Models.UserDetailsDTO> lst = new List<RMS.Models.UserDetailsDTO>();
                    var query = from UP in db.UserPermissions
                                join U in db.UserInfos on UP.UserSLNo equals U.UserSLNo
                                join S in db.StatusInfos on U.Status equals S.StatusValue
                                where U.UserSLNo == UserSLNo && U.IsDeleted == false
                                orderby UP.ChildID ascending
                                select new
                                {
                                    U.UserSLNo,
                                    U.Email,
                                    U.UserID,
                                    U.FirstName,
                                    U.LastName,
                                    UP.ChildID,
                                    UP.ParentID,
                                    UP.Name,
                                    UP.Checked,
                                };
                    lst = query.AsEnumerable().Select(x => new RMS.Models.UserDetailsDTO
                    {
                        UserSLNo = x.UserSLNo,
                        Email = x.Email,
                        UserID = x.UserID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ChildID = x.ChildID,
                        ParentID = x.ParentID,
                        Name = x.Name,
                        Checked = x.Checked,
                    }).ToList();
                    if (lst.Count > 0)
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            if (lst[i].ParentID == null)
                            {
                                lst[i].Parent = lst[i].Name;
                            }
                            else
                            {
                                lst[i].Child = lst[i].Name;
                            }
                            if (lst[i].Checked == true)
                            {
                                if (lst[i].ParentID != null)
                                {
                                    lst[i].Enable = "Yes";
                                }
                            }
                            else
                            {
                                if (lst[i].ParentID != null)
                                {
                                    lst[i].Enable = "No";
                                }
                            }
                        }
                    }
                    ViewBag.AlertMsg = AlertMsg;
                    AlertMsg = null;
                    return View(UserInfoPath.UserDetails, lst);
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

        [HttpGet]
        public ActionResult ResetPassword()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    AgreementInfoPath AgreementInfoPath = new AgreementInfoPath();
                    DTOBasic DTOBasic = new DTOBasic();
                    ViewBag.LoginUserID = Session["LoginUserID"].ToString();
                    int LoginUserSLNo = Convert.ToInt32(Session["LoginUserSLNo"].ToString());
                    ViewBag.URLPath = "UserInfo/ResetPassword";
                    //==Check for Permission
                    bool Check = false;
                    Check = db.UserPermissions.Where(x => x.ChildID == 4 && x.UserSLNo == LoginUserSLNo).Select(x => x.Checked).FirstOrDefault();
                    if (Check == false)
                    {
                        UserPermissionMessage msg = new UserPermissionMessage();
                        ViewBag.Message = msg.AccessDenied;
                        return View(HomePath.DisplayMessage);
                    }
                    //==
                    UserInfoLocation UserInfoLocation = new UserInfoLocation();
                    RMS.Models.UserInfoDTO DTO = new RMS.Models.UserInfoDTO();
                    var UserInfo = db.UserInfos.Where(x => x.UserSLNo == LoginUserSLNo).SingleOrDefault();
                    DTO.UserSLNo = UserInfo.UserSLNo;
                    DTO.Email = UserInfo.Email;
                    DTO.UserID = UserInfo.UserID;
                    DTO.FirstName = UserInfo.FirstName;
                    DTO.LastName = UserInfo.LastName;
                    return View(UserInfoPath.ResetPassword, DTO);
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

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult ResetPassword(int UserSLNo, string Password)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    //==Check multiple login validation
                    string SessionUserID = Session["LoginUserID"].ToString();
                    string LoginDateTime = Session["LoginDateTime"].ToString();
                    string LoginDate = db.UserInfos.Where(x => x.UserID == SessionUserID).Select(x => x.LoginDate).FirstOrDefault().ToString();
                    if (LoginDateTime != LoginDate)
                    {
                        return RedirectToAction("SignOut", "Home");
                    }
                    //==Encrypt UserSLNo
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var encryptedString = AesOperation.EncryptString(key, Password);
                    //==
                    RMS.Models.UserInfo UI = db.UserInfos.Where(x => x.UserSLNo == UserSLNo).SingleOrDefault();
                    UI.Password = encryptedString;
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
            else
            {
                return View(HomePath.Login);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    DTOBasic DTOBasic = new DTOBasic();
                    ViewBag.LoginUserID = Session["LoginUserID"].ToString();
                    ViewBag.URLPath = "UserInfo/RedirectUserIndex?ViewID=1";
                    RMS.Models.UserInfoDTO DTO = new RMS.Models.UserInfoDTO();
                    return View(UserInfoPath.Create, DTO);
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

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Create(List<int> checkedIds, string email, string userid, string password, string firstname, string lastname, string contactno1, string contactno2, string address, string designation)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    RMS.Models.UserInfo UI = new RMS.Models.UserInfo();
                    DTOBasic dtoBasic = new DTOBasic();
                    //==Encrypt UserSLNo
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var encryptedString = AesOperation.EncryptString(key, password);
                    //==
                    //==Save to UserInfo table
                    UI.Email = email;
                    UI.UserID = userid;
                    UI.Password = encryptedString;
                    UI.FirstName = firstname;
                    UI.LastName = lastname;
                    UI.ContactNo1 = contactno1;
                    UI.ContactNo2 = contactno2;
                    UI.Address = address;
                    UI.Status = dtoBasic.active;
                    UI.EntryBy = (string)Session["LoginUserID"];
                    UI.EntryDate = DateTime.Now;
                    UI.IsDeleted = false;
                    UI.Designation = designation;
                    UI.IsUpdatePassword = false;
                    UI.PasswordExpiredDate = DateTime.Now.AddDays(30);
                    db.UserInfos.Add(UI);
                    db.SaveChanges();
                    //==Save to UserPermission table
                    List<RMS.Models.UserPermission> lstPermission = db.UserPermissions.Where(x => x.UserSLNo == null).ToList();
                    lstPermission.ToList().ForEach(x => { x.Checked = false; x.UserSLNo = UI.UserSLNo; });
                    //==Edit checked to UserPermission New list
                    if (checkedIds != null)
                    {
                        foreach (int i in checkedIds)
                        {
                            lstPermission.Where(x => x.ChildID == i).ToList().ForEach(x => { x.Checked = true; });
                        }
                    }
                    db.UserPermissions.AddRange(lstPermission);
                    db.SaveChanges();
                    AlertMsg = "The user account " + userid + " has been created.";
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

        [HttpGet]
        public ActionResult RedirectCopyProfile(int UserSLNo)
        {
            TempData.Remove("UserSLNo");
            TempData.Add("UserSLNo", UserSLNo);
            return RedirectToAction("CreateCopyProfile");
        }

        [HttpGet]
        public ActionResult CreateCopyProfile()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    ViewBag.LoginUserID = Session["LoginUserID"].ToString();
                    ViewBag.URLPath = "UserInfo/RedirectUserIndex?ViewID=1";
                    var strUserSLNo = TempData["UserSLNo"];
                    if (strUserSLNo == null)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    //int UserSLNo = Convert.ToInt32(strUserSLNo);
                    Session["CreateProfileUserSLNo"] = strUserSLNo;
                    RMS.Models.UserInfoDTO DTO = new RMS.Models.UserInfoDTO();
                    return View(UserInfoPath.CreateCopyProfile, DTO);
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

        [HttpGet]
        public ActionResult Edit(int UserSLNo)
        {
            TempData.Remove("UserSLNo");
            TempData.Add("UserSLNo", UserSLNo);
            return RedirectToAction("EditUser");
        }

        [HttpGet]
        public ActionResult EditUser()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    ViewBag.LoginUserID = Session["LoginUserID"].ToString();
                    ViewBag.URLPath = "UserInfo/RedirectUserIndex?ViewID=2";
                    ViewBag.Status = (List<RMS.Models.StatusInfo>)db.StatusInfos.ToList();
                    var strUserSLNo = TempData["UserSLNo"];
                    if (strUserSLNo == null)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    int UserSLNo = Convert.ToInt32(strUserSLNo);
                    UserInfoLocation UserInfoLocation = new UserInfoLocation();
                    List<RMS.Models.UserInfoDTO> lst = new List<RMS.Models.UserInfoDTO>();
                    var query = from U in db.UserInfos
                                join S in db.StatusInfos on U.Status equals S.StatusValue
                                where U.UserSLNo == UserSLNo
                                select new
                                {
                                    U.UserSLNo,
                                    U.Email,
                                    U.UserID,
                                    U.Password,
                                    U.FirstName,
                                    U.LastName,
                                    U.ContactNo1,
                                    U.ContactNo2,
                                    U.Address,
                                    U.Designation,
                                    U.EntryBy,
                                    U.EntryDate,
                                    U.Status,
                                    U.IsDeleted,
                                    S.StatusName,
                                    U.IsLocked,
                                };
                    lst = query.AsEnumerable().Select(x => new RMS.Models.UserInfoDTO
                    {
                        UserSLNo = x.UserSLNo,
                        Email = x.Email,
                        UserID = x.UserID,
                        Password = x.Password,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ContactNo1 = x.ContactNo1,
                        ContactNo2 = x.ContactNo2,
                        Address = x.Address,
                        Designation = x.Designation,
                        EntryBy = x.EntryBy,
                        EntryDate = x.EntryDate,
                        Status = x.Status,
                        IsDeleted = x.IsDeleted,
                        StatusName = x.StatusName,
                        IsLocked = x.IsLocked,
                    }).ToList();
                    return View(UserInfoPath.Edit, lst);
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

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Edit(List<int> checkedIds, int userslno, string email, string userid, string password, string firstname, string lastname, string contactno1, string contactno2, string address, string designation, int status)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    DTOBasic dtoBasic = new DTOBasic();
                    RMS.Models.UserInfo UI = new RMS.Models.UserInfo();
                    UI = db.UserInfos.Where(x => x.UserSLNo == userslno).SingleOrDefault();
                    //Update UserInfo table
                    UI.Email = email;
                    UI.UserID = userid;
                    UI.FirstName = firstname;
                    UI.LastName = lastname;
                    UI.ContactNo1 = contactno1;
                    UI.ContactNo2 = contactno2;
                    UI.Address = address;
                    UI.EditBy = (string)Session["LoginUserID"];
                    UI.EditDate = DateTime.Now;
                    UI.IsDeleted = false;
                    UI.Designation = designation;
                    UI.Status = status;
                    db.Entry(UI).State = EntityState.Modified;
                    db.SaveChanges();
                    //===Delete Existing User Permission for the user
                    db.UserPermissions.RemoveRange(db.UserPermissions.Where(x => x.UserSLNo == userslno));
                    db.SaveChanges();
                    //==Save to new User Permission for the user
                    List<RMS.Models.UserPermission> lstUserPermission = db.UserPermissions.Where(x => x.UserSLNo == null).ToList();
                    lstUserPermission.ToList().ForEach(x => { x.Checked = false; x.UserSLNo = userslno; });
                    //Edit checked to User Permission for the list
                    if (checkedIds != null)
                    {
                        foreach (int i in checkedIds)
                        {
                            lstUserPermission.Where(x => x.ChildID == i).ToList().ForEach(x => { x.Checked = true; });
                        }
                    }
                    db.UserPermissions.AddRange(lstUserPermission);
                    db.SaveChanges();
                    AlertMsg = "The user account " + userid + " has been updated.";
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


        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Delete(int UserSLNo)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    RMS.Models.UserInfo UI = db.UserInfos.Where(x => x.UserSLNo == UserSLNo).SingleOrDefault();
                    string LoginUserID = (string)Session["LoginUserID"];
                    UI.EntryBy = db.UserInfos.Where(x => x.UserID == LoginUserID).Select(x => x.UserID).SingleOrDefault();
                    UI.EntryDate = DateTime.Now;
                    UI.IsDeleted = true;
                    db.Entry(UI).State = EntityState.Modified;
                    db.SaveChanges();
                    AlertMsg = "The user: " + UI.UserID + " has been deleted.";
                    return Json(new { CheckStatus = true, UserID = UI.UserID }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPermissionList()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    List<Models.UserPermission> UserPermissions;
                    List<Models.UserPermissionDTO> records;
                    using (RMSDBContext context = new RMSDBContext())
                    {
                        UserPermissions = context.UserPermissions.Where(x => x.UserSLNo == null).ToList();
                        records = UserPermissions.Where(x => x.ParentID == null).OrderBy(x => x.OrderNumber)
                            .Select(x => new Models.UserPermissionDTO
                            {
                                Childid = x.ChildID,
                                text = x.Name,
                                @checked = x.Checked,
                                children = GetChildren(UserPermissions, x.ChildID)
                            }).ToList();
                    }
                    return this.Json(records, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPermissionList_CopyProfile()
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    List<Models.UserPermission> UserPermissions;
                    List<Models.UserPermissionDTO> records;
                    using (RMSDBContext context = new RMSDBContext())
                    {
                        //UserPermissions = context.UserPermissions.Where(x => x.UserSLNo == null).ToList();
                        int CreateProfileUserSLNo = (int)Session["CreateProfileUserSLNo"];
                        UserPermissions = context.UserPermissions.Where(x => x.UserSLNo == CreateProfileUserSLNo).ToList();
                        foreach (Models.UserPermission item in UserPermissions)
                        {
                            bool Checked = context.UserPermissions.Where(x => x.ChildID == item.ChildID && x.UserSLNo == CreateProfileUserSLNo).Select(x => x.Checked).FirstOrDefault();
                            if (Checked == true) { item.Checked = true; }
                            else { item.Checked = false; }
                        }

                        records = UserPermissions.Where(x => x.ParentID == null).OrderBy(x => x.OrderNumber)
                            .Select(x => new Models.UserPermissionDTO
                            {
                                Childid = x.ChildID,
                                text = x.Name,
                                @checked = x.Checked,
                                children = GetChildren(UserPermissions, x.ChildID)
                            }).ToList();
                    }
                    return this.Json(records, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetUserPermissionList(int UserSLNo)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
                {
                    List<Models.UserPermission> UserPermissions;
                    List<Models.UserPermissionDTO> records;
                    using (RMSDBContext context = new RMSDBContext())
                    {
                        UserPermissions = context.UserPermissions.Where(x => x.UserSLNo == null).ToList();
                        foreach (RMS.Models.UserPermission item in UserPermissions)
                        {
                            bool Checked = context.UserPermissions.Where(x => x.ChildID == item.ChildID && x.UserSLNo == UserSLNo).Select(x => x.Checked).FirstOrDefault();
                            if (Checked == true) { item.Checked = true; }
                            else { item.Checked = false; }
                        }
                        records = UserPermissions.Where(x => x.ParentID == null).OrderBy(x => x.OrderNumber)
                            .Select(x => new Models.UserPermissionDTO
                            {
                                Childid = x.ChildID,
                                text = x.Name,
                                @checked = x.Checked,
                                children = GetChildren(UserPermissions, x.ChildID)
                            }).ToList();
                    }
                    return this.Json(records, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        private List<Models.UserPermissionDTO> GetChildren(List<Models.UserPermission> UserPermissions, int parentId)
        {
            return UserPermissions.Where(x => x.ParentID == parentId).OrderBy(x => x.OrderNumber)
                .Select(x => new Models.UserPermissionDTO
                {
                    Childid = x.ChildID,
                    text = x.Name,
                    @checked = x.Checked,
                    children = GetChildren(UserPermissions, x.ChildID)
                }).ToList();
        }

        [HttpGet]
        public ActionResult CheckUserExist(string CheckFor, string OldUserID, string NewUserID, string OldEmail, string NewEmail)
        {
            if (System.Web.HttpContext.Current.Session != null && Session["LoginUserID"] != null)
            {
                try
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
                    if (CheckFor == "Create")
                    {
                        if (db.UserInfos.Any(x => x.UserID == NewUserID) == true)
                        {
                            return Json(new { UserExist = true, CheckType = "Exist" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (db.UserInfos.Any(x => x.Email == NewEmail) == true)
                        {
                            return Json(new { EmailExist = true, CheckType = "Exist" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        if (OldUserID != NewUserID)
                        {
                            if (db.UserInfos.Any(x => x.UserID == NewUserID) == true)
                            {
                                return Json(new { UserExist = true, CheckType = "Exist" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else if (OldEmail != NewEmail)
                        {
                            if (db.UserInfos.Any(x => x.Email == NewEmail) == true)
                            {
                                return Json(new { EmailExist = true, CheckType = "Exist" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    return Json(new { UserExist = false, CheckType = "NotExist" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception Ex)
                {
                    return Json(new { UserExist = true, CheckType = "Error", CheckInfo = Ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return View(HomePath.Login);
            }
        }
    }
}
