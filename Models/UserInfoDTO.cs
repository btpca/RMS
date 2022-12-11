using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UserInfoDTO
    {
        public int UserSLNo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Primary Contact No")]
        public string ContactNo1 { get; set; }

        [DisplayName("Optional Contact No")]
        public string ContactNo2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Designation")]
        public string Designation { get; set; }

        [DisplayName("Edit By")]
        public string EditBy { get; set; }

        [DisplayName("Edit Date")]
        public DateTime? EditDate { get; set; }

        [DisplayName("Create By")]
        public string EntryBy { get; set; }

        [DisplayName("Create Date")]
        public DateTime? EntryDate { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        public bool IsDeleted { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        public bool IsUpdatePassword { get; set; }
        public DateTime PasswordExpiredDate { get; set; }

        public bool IsLogin { get; set; }
        public string BrowserName { get; set; }
        public string IPAddress { get; set; }
        public DateTime? LoginDate { get; set; }

        public bool IsLocked { get; set; }

        public int TotalUser { get; set; }
        public int TotalActiveUser { get; set; }
        public int TotalInActiveUser { get; set; }
        public int TotalCurrentSession { get; set; }

        [DisplayName("Admin Role")]
        public string AdminRole { get; set; }
    }
}