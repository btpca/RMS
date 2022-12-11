using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class EmailAccount
    {
        [Key]
        public int EmailSLNo { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string EmailSMTP { get; set; }
        public int SMTPPortNo { get; set; }
        public string DefaultPassword { get; set; }
        public string EmailHeader { get; set; }
        public bool IsVariantDaysCount { get; set; }
        public bool IsSpaceAllocation { get; set; }
    }
}