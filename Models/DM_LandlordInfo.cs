using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_LandlordInfo
    {
        [Key]
        public int LandlordSLNo { get; set; }
        public string AgreementCode { get; set; }
        public string VendorCode { get; set; }
        public string LandlordName { get; set; }
        public string ModeOfPayment { get; set; }
        public double AdvancePC { get; set; }
        public double AdvanceAdjustmentPC { get; set; }
        public double RentPC { get; set; }
        public double TaxPC { get; set; }
        public double VATPC { get; set; }
        public string ACNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string RoutingNo { get; set; }
        public string LLAddress { get; set; }
        public string LLContactNo { get; set; }
        public string LLEmail { get; set; }
    }
}