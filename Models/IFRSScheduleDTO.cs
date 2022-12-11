using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace RMS.Models
{
    public class IFRSScheduleDTO
    {
        //========Contract Schedule//========
        [DisplayName("SL No")]
        public int SLNO { get; set; }

        [DisplayName("IFRS SL No")]
        public int IFRSSLNo { get; set; }

        [DisplayName("Schedule Date")]
        public DateTime ScheduleDate { get; set; }

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

        [DisplayName("From Month")]
        public string FromMonth { get; set; }

        [DisplayName("To Month")]
        public string ToMonth { get; set; }

        [DisplayName("Enhancement No")]
        public int ReviewNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Cost Per Unit")]
        public double CostPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Payment Amount")]
        public double PaymentAmount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N4}")]
        [DisplayName("Discount Factor")]
        public double DiscountFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Present Value")]
        public double PresentValue { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Opening Balance")]
        public double OBLeaseLiability { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Lease Payment")]
        public double LeasePayment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Interest Expense")]
        public double InteresetExpense { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Settlement of Lease Liabilities")]
        public double SettlementofLeaseLiabilities { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Closing Balance")]
        public double CBLeaseLiability { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Opening Balance")]
        public double OBROU { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Depreciation")]
        public double Depreciation { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Closing Balance")]
        public double CBROU { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("OB Advance")]
        public double OBAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Depreciation")]
        public double AdvanceDepreciation { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("CB Advance")]
        public double CBAdvance { get; set; }

        [DisplayName("User ID")]
        public int UserSLNo { get; set; }

        [DisplayName("Create By")]
        public string UserID { get; set; }

        [DisplayName("Create Date")]
        public string EntryDate { get; set; }

        public string RowNumber { get; set; }
        public int ftrCount { get; set; }

        //========Agreement Info//========
        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        public int xModifiedAgreementSLNo { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }
        public string xAliasCode { get; set; }

        public List<int> PremiseTypeSLNoCheckList { get; set; }
        public List<int> AgreementSLNoCheckList { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
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
        [DisplayName("Rent Amount")]
        public double RentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Rent Amount")]
        public double TotalRentAmount { get; set; }

        [DisplayName("Security Deposit Amount")]
        public double SecurityDepositAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance")]
        public double AdvanceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance O/B")]
        public double AdvanceAmountOB { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment")]
        public double AdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance C/B")]
        public double AdvanceAmountCB { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public double AdvanceAdjustmentPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double TaxPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double TaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double VATPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double VATAmount { get; set; }

        [DisplayName("Agreement Status")]
        public int AgreementStatus { get; set; }

        //==
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }

        public string BlockText { get; set; }

        [DisplayName("Block By")]
        public string BlockUserID { get; set; }

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

        public string ClusterGroup { get; set; }

        public bool IsHoldBlockPayment { get; set; }

        public bool IsIFRSEnable { get; set; }

        [DisplayName("IFRS Effective Date")]
        public string IFRSEffectiveDate { get; set; }

        [DisplayName("Borrowing Rate %")]
        public double BorrowingRate { get; set; }

        [DisplayName("CorporateTax Rate %")]
        public double CorporateTaxRate { get; set; }

        //Step 1 Deferred SD
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Deferred SD O/B")]
        public double DeferredSD_OB { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Deferred SD Interest")]
        public double DeferredSD_Interest { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Deferred SD C/B")]
        public double DeferredSD_CB { get; set; }

        //Step 2 ROU Asset SD
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset SD O/B")]
        public double ROUAssetSD_OB { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset SD Dep")]
        public double ROUAssetSD_DEP { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset SD C/B")]
        public double ROUAssetSD_CB { get; set; }

        //Step 3 ROU Asset Total
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset (Total) O/B")]
        public double ROUAssetTotal_OB { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset (Total) Dep")]
        public double ROUAssetTotal_Dep { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("ROU Asset (Total) C/B")]
        public double ROUAssetTotal_CB { get; set; }

        //Step 4 Deferred Tax Impact
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Carring Amount ROU Asset (Total) C/B")]
        public double DTCarringAmountROUAssetTotal_CB { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Carring Amount Lease")]
        public double DTCarringAmount_Lease { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Tax Base Amount Rent Expense")]
        public double DTTaxBaseAmountRent_Expense { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Corporate Tax Rate %")]
        public double DTCoporateTaxRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Impact")]
        public double DTImpact { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("DT Income or Expense")]
        public double DT_IncomeExpense { get; set; }

        public string CalculationMethod { get; set; }
    }
}