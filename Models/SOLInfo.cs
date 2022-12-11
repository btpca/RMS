using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class SOLInfo
    {
        [Key]
        public int SOLSLNo { get; set; }
        public string SOLID{ get; set; }
        public string SOLName { get; set; }
    }
}