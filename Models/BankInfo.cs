using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class BankInfo
    {
        [Key]
        public int BankSLNo { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
    }
}