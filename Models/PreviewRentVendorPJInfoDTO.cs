using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class PreviewRentVendorPJInfoDTO
    {
        public int RentVendorPJSLNo { get; set; }

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

        [DisplayName("Calculation Method")]
        public string CalculationMethod { get; set; }

        public string AgreementText { get; set; }
        public int RentDueDay { get; set; }
        public string ACNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }

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

        [DisplayName("Landlord SL No")]
        public int LandlordSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Text")]
        public string Remarks { get; set; }

        public int UserSLNo { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; }

        [DisplayName("CC Code")]
        public string CCCode { get; set; }

        [DisplayName("CC Name")]
        public string CCName { get; set; }

        [DisplayName("SOL Code")]
        public string SOLCode { get; set; }

        [DisplayName("SOL Name")]
        public string SOLName { get; set; }

        [DisplayName("Mode Of Payment")]
        public int ModeOfPayment { get; set; }

        [DisplayName("Mode Of Payment")]
        public string ModeOfPaymentText { get; set; }

    }
}