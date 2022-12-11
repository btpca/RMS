using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UserInfo
    {
        [Key]
        public int UserSLNo { get; set; }

        public string Email { get; set; }

        public string UserID { get; set; }

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

        public string Designation { get; set; }

        [DisplayName("Edit By")]
        public string EditBy { get; set; }

        [DisplayName("Edit Date")]
        public DateTime? EditDate { get; set; }

        [DisplayName("Create By")]
        public string EntryBy { get; set; }

        [DisplayName("Create Date")]
        public DateTime EntryDate { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsUpdatePassword { get; set; }
        public DateTime PasswordExpiredDate { get; set; }

        public bool IsLogin { get; set; }
        public string BrowserName { get; set; }
        public string IPAddress { get; set; }
        public DateTime? LoginDate { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedDate { get; set; }
    }
}