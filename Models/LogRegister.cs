using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class LogRegister
    {
        [Key]
        public int LogID { get; set; }
        
        public int UserSLNo { get; set; }
        [ForeignKey("UserSLNo")]
        public virtual UserInfo UserInfo { get; set; }

        public DateTime LoginDate { get; set; }
        public string BrowserName { get; set; }
        public string IPAddress { get; set; }
    }
}