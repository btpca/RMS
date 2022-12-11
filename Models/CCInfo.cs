using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class HOCCSOLInfo
    {
        [Key]
        public int HOSLNo { get; set; }
        public string CCID { get; set; }
        public string CCName { get; set; }
        public string SOLID { get; set; }
        public string SOLName { get; set; }
    }
}