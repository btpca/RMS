using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class LandlordScheduleDTO
    {
        //========Contract Schedule//========
        [DisplayName("SL No")]
        public int SLNO { get; set; }

        [DisplayName("Landlord Schedule SL No")]
        public int LScheduleSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Schedule Date")]
        public DateTime ScheduleDate { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Landlord SL No")]
        public int LandlordSLNo { get; set; }

        [DisplayName("Premise Type")]
        public int PremiseTypeSLNo { get; set; }

        [DisplayName("Premise Type Code")]
        public int PremiseTypeCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Month No")]
        public int MonthNo { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Enhancement No")]
        public int ReviewNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Cost Per Unit")]
        public double ContractCostPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Rent Amount")]
        public double ContractTotalRentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double ContractAdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double ContractTaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double ContractVATAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Net Rent Amount")]
        public double ContractNetRentAmount { get; set; }

        [DisplayName("User ID")]
        public int UserSLNo { get; set; }

        [DisplayName("Create By")]
        public string UserID { get; set; }

        [DisplayName("Create Date")]
        public string EntryDate { get; set; }

        //==AP Posting Info
        public bool IsPosted { get; set; }

        public string PostText { get; set; }

        [DisplayName("AP Posting ID")]
        public string PostingID { get; set; }

        [DisplayName("AP Posting")]
        public DateTime? PostingDate { get; set; }

        [DisplayName("AP Posting User ID")]
        public int? PostingUserSLNo { get; set; }

        //==Payment Posting Info
        public bool IsPJPosted { get; set; }

        public string PJPostText { get; set; }

        [DisplayName("Payment Posting ID")]
        public string PJPostingID { get; set; }

        [DisplayName("Payment Posting")]
        public string PJPostingDate { get; set; }

        [DisplayName("Payment Posting User ID")]
        public int? PJPostingUserSLNo { get; set; }

        public string RowNumber { get; set; }
        public int ftrCount { get; set; }

        //========Agreement Info//========

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayName("Agreement End Date")]
        public string AgreementEndDate { get; set; }

        [DisplayName("Schedule No")]
        public int AgreementPeriod { get; set; }

        [DisplayName("Renewal After")]
        public int RenewalFrequency { get; set; }

        [DisplayName("Enh Frequency")]
        public int ReviewPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Enh Increase %")]
        public double ReviewIncrease { get; set; }

        [DisplayName("Rent Due Day")]
        public int RentDueDay { get; set; }

        [DisplayName("Unit of Measurement")]
        public int UOM { get; set; }

        [DisplayName("Unit of Measurement")]
        public string UOMName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Area")]
        public double TotalArea { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("LL Area")]
        public double LLArea { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Cost Per Unit")]
        public double CostPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Rent Amount")]
        public double TotalRentAmount { get; set; }

        [DisplayName("Security Deposit Amount")]
        public double SecurityDepositAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Amount")]
        public double AdvanceAmount { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public double AdvanceAdjustmentPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment")]
        public double AiAdvanceAdjustmentAmount { get; set; }


        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("LI Adv %")]
        public double LIAdvancePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("LL Advance Amount")]
        public double LIAdvanceamount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Adv Adj %")]
        public double AdvanceAdjustmentPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double AdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double AiTaxPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax")]
        public double AiTaxAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double TaxPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double TaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double AiVATPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT")]
        public double AiVATAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double VATPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double VATAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent %")]
        public double RentPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("LL Rent Amount")]
        public double LLRentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Net Rent Amount")]
        public double NetRentAmount { get; set; }

        [DisplayName("Agreement Status")]
        public int AgreementStatus { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        //==
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }

        public string BlockText { get; set; }

        [DisplayName("Block By")]
        public string BlockUserID { get; set; }

        public List<int> PremiseTypeSLNoCheckList { get; set; }
        public List<int> AgreementSLNoCheckList { get; set; }
        public List<int> VendorSLNoCheckList { get; set; }

        [DisplayName("Log Name")]
        public string LogName { get; set; }

        [DisplayName("From Month")]
        public string FromMonthName { get; set; }

        [DisplayName("To Month")]
        public string ToMonthName { get; set; }

        [DisplayName("CC Code")]
        public string CCCode { get; set; }

        [DisplayName("CC Name")]
        public string CCName { get; set; }

        [DisplayName("SOL Code")]
        public string SOLCode { get; set; }

        [DisplayName("SOL Name")]
        public string SOLName { get; set; }

        [DisplayName("Tax Type")]
        public int TaxType { get; set; }

        [DisplayName("VAT Type")]
        public int VatType { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent Amount")]
        public double RentAmount { get; set; }


        public int ReviewFrequency { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double ReviewPercentage { get; set; }

        [DisplayName("Cash GL Code")]
        public string CashGLCode { get; set; }

        [DisplayName("Bank GL Code")]
        public string BankGLCode { get; set; }

        [DisplayName("Advance GL Code")]
        public string AdvanceGLCode { get; set; }

        [DisplayName("Advance Adjustment GL Code")]
        public string AdvanceAdjustmentGLCode { get; set; }

        [DisplayName("Rent GL Code")]
        public string RentGLCode { get; set; }

        [DisplayName("Utility GL Code")]
        public string ServiceChargeGLCode { get; set; }

        [DisplayName("Tax GL Code")]
        public string TaxGLCode { get; set; }

        [DisplayName("VAT GL Code")]
        public string VATGLCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge")]
        public double ServiceCharge { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower Charge")]
        public double OnlineTower { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space Charge")]
        public double GeneratorSpace { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Car Parking Charge")]
        public double CarParking { get; set; }

        [DisplayName("Mode Of Payment")]
        public int ModeOfPayment { get; set; }

        [DisplayName("Mode Of Payment")]
        public string ModeOfPaymentText { get; set; }

        [DisplayName("Account No")]
        public string ACNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Routing No")]
        public string RoutingNo { get; set; }

        public string ClusterGroup { get; set; }

        public bool IsHoldBlockPayment { get; set; }
        public string CalculationMethod { get; set; }
        public bool Special { get; set; }

        public bool IsIFRSEnable { get; set; }

        [DisplayName("IFRS Effective Date")]
        public string IFRSEffectiveDate { get; set; }
    }
}