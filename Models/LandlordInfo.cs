using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class LandlordInfo
    {
        [Key]
        public int LandlordSLNo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public string VendorCode { get; set; }
        public string LandlordName { get; set; }
        public int ModeOfPayment { get; set; }
        public double AdvancePC { get; set; }
        public double AdvanceAmount { get; set; }
        public double AdvanceAdjustmentPC { get; set; }
        public double AdvanceAdjustmentAmount { get; set; }

        public double RentPC { get; set; }
        public double RentAmount { get; set; }
        public double TaxPC { get; set; }
        public double TaxAmount { get; set; }
        public double VATPC { get; set; }
        public double VATAmount { get; set; }
        public string ACNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string RoutingNo { get; set; }

        public bool IsHoldBlockPayment { get; set; }

        public string LLAddress { get; set; }
        public string LLContactNo { get; set; }
        public string LLEmail { get; set; }

        public bool IsOld { get; set; }
    }
}