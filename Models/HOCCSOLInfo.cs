using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class CCInfo
    {
        [Key]
        public int CCSLNo { get; set; }
        public string CCID { get; set; }
        public string CCName { get; set; }
    }
}