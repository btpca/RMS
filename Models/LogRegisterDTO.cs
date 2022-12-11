using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class LogRegisterDTO
    {
        public int LogID { get; set; }
        public int UserSLNo { get; set; }
        public string UserID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public DateTime LoginDate { get; set; }
        public string BrowserName { get; set; }
        public string IPAddress { get; set; }
    }
}