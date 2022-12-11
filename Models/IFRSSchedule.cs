using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class IFRSSchedule
    {
        [Key]
        public int IFRSSLNo { get; set; }
        public DateTime ScheduleDate { get; set; }
        
        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public int MonthNo { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int ReviewNo { get; set; }
        public double CostPerUnit { get; set; }
        public double AdvanceAdjustmentAmount { get; set; }
        public double PaymentAmount { get; set; }
        public double DiscountFactor { get; set; }
        public double PresentValue { get; set; }
        public double OBLeaseLiability { get; set; }
        public double LeasePayment { get; set; }
        public double InteresetExpense { get; set; }
        public double SettlementofLeaseLiabilities { get; set; }
        public double CBLeaseLiability { get; set; }
        public double OBROU { get; set; }
        public double Depreciation { get; set; }
        public double CBROU { get; set; }
        public double OBAdvance { get; set; }
        public double AdvanceDepreciation { get; set; }
        public double CBAdvance { get; set; }
        public int UserSLNo { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }
    }
}