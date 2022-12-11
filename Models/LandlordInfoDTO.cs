using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class LandlordInfoDTO
    {
        [DisplayName("Landlord SL No")]
        public int LandlordSLNo { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Mode Of Payment")]
        public int ModeOfPayment { get; set; }

        [DisplayName("Mode Of Payment")]
        public string ModeOfPaymentText { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance %")]
        public double VendorAdvancePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Amount")]
        public double VendorAdvanceAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment %")]
        public double VendorAdvanceAdjustmentPC { get; set; }

        [DisplayName("Advance Adjustment Amount")]
        public double VendorAdvanceAdjustmentAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent %")]
        public double VendorRentPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent Amount")]
        public double VendorRentAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double VendorTaxPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double VendorTaxAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double VendorVATPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double VendorVATAmount { get; set; }

        [DisplayName("Account No")]
        public string ACNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Routing No")]
        public string RoutingNo { get; set; }

        public string LIRowNumber { get; set; }
        public int LIftrCount { get; set; }

        public bool IsHoldBlockPayment { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Premise Address")]
        public string PremiseAddress { get; set; }


        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayName("Agreement End Date")]
        public string AgreementEndDate { get; set; }

        [DisplayName("Schedule No")]
        public int AgreementPeriod { get; set; }

        [DisplayName("Address")]
        public string LLAddress { get; set; }

        [DisplayName("Contact Number")]
        public string LLContactNo { get; set; }

        [DisplayName("Email")]
        public string LLEmail { get; set; }

        public bool IsOld { get; set; }

        public int AgreementType { get; set; }
    }
}

