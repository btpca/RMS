using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class UtilitySchedule
    {
        [Key]
        public int UScheduleSLNo { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int AgreementSLNo { get; set; }
        public int UtilitySLNo { get; set; }
        public int MonthNo { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public double ServiceChargeAmount { get; set; }
        public double OnlineTowerAmount { get; set; }
        public double GeneratorSpaceAmount { get; set; }
        public double CarParkingAmount { get; set; }
        public double TaxAmount { get; set; }
        public double VATAmount { get; set; }
        public int UserSLNo { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsLog { get; set; }

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
    }
}