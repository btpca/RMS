using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_UtilityInfo
    {
        [Key]
        public int UtilitySLNo { get; set; }
        public string AgreementCode { get; set; }
        public string UtilityVendorCode { get; set; }
        public string UtilityLandlordName { get; set; }
        public string UtilityModeOfPayment { get; set; }
        public double ServiceChargePC { get; set; }
        public double OnlineTowerPC { get; set; }
        public double GeneratorSpacePC { get; set; }
        public double CarParkingPC { get; set; }
        public double TaxPC { get; set; }
        public double VATPC { get; set; }
        public string UtilityACNo { get; set; }
        public string UtilityBankName { get; set; }
        public string UtilityBranchName { get; set; }
        public string UtilityRoutingNo { get; set; }
        public string UtilityAddress { get; set; }
        public string UtilityContactNo { get; set; }
        public string UtilityEmail { get; set; }
    }
}