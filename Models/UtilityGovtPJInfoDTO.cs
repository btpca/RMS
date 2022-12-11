using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UtilityGovtPJInfoDTO
    {
        public int UtilityGovtPJSLNo { get; set; }

        [DisplayName("Posting ID")]
        public string PostingID { get; set; }

        [DisplayName("Posting Date")]
        public string PostingDate { get; set; }

        public int AgreementSLNo { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        public int Year { get; set; }
        public string Month { get; set; }

        [DisplayName("GL Code")]
        public string GLCode { get; set; }

        [DisplayName("GL Name")]
        public string GLName { get; set; }

        [DisplayName("Debit/Credit")]
        public int DrCrID { get; set; }

        [DisplayName("Debit/Credit")]
        public int DrCrName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Amount")]
        public double Amount { get; set; }

        [DisplayName("Utility SL No")]
        public int UtilitySLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Text")]
        public string Remarks { get; set; }

        public int UserSLNo { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; }

    }
}