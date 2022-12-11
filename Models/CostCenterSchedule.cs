using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class CostCenterSchedule
    {
        [Key]
        public int CCScheduleSLNo { get; set; }
        public DateTime ScheduleDate { get; set; }
        
        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public int CCSLNo { get; set; }
        public int MonthNo { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int ReviewNo { get; set; }
        public double CostPerUnit { get; set; }
        public double TotalRentAmount { get; set; }
        public double AdvanceAdjustmentAmount { get; set; }
        public double TaxAmount { get; set; }
        public double VATAmount { get; set; }
        public double NetRentAmount { get; set; }
        public int UserSLNo { get; set; }
        public DateTime EntryDate { get; set; }

        //==AP Posting Info
        public bool IsPosted { get; set; }
        public string PostingID { get; set; }
        public DateTime? PostingDate { get; set; }
        public int? PostingUserSLNo { get; set; }

        //==Payment Posting Info
        public bool IsPJPosted { get; set; }
        public string PJPostingID { get; set; }
        public DateTime? PJPostingDate { get; set; }
        public int? PJPostingUserSLNo { get; set; }

        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }
        public bool IsHoldBlockPayment { get; set; }
    }
}