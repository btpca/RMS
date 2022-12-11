using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class RentAPJournalInfo
    {
        [Key]
        public int RentAPJournalSLNo { get; set; }
        public string PostingID { get; set; }
        public DateTime PostingDate { get; set; }
        
        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public int Year { get; set; }
        public string Month { get; set; }
        public string GLCode { get; set; }
        public string GLName { get; set; }
        public int DrCrID { get; set; }
        public double Amount { get; set; }
        public int CCSLNo { get; set; }
        public int LandlordSLNo { get; set; }
        public string Remarks { get; set; }

        public int UserSLNo { get; set; }
        [ForeignKey("UserSLNo")]
        public virtual UserInfo UserInfo { get; set; }

        public int LogYear { get; set; }
        public string LogMonth { get; set; }
    }
}