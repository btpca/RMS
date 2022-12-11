using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class IFRSModSummaryDTO
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

        [DisplayName("Enhancement No")]
        public int ReviewNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Cost Per Unit")]
        public double CostPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double ROULease { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double ROUAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double LeaseLiability { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AdjustmentforModification  { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AdjustmentLease { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AdjustmentAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AdjustmentLeaseLiability { get; set; }

        //========Agreement Info//========
        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }
        public string xAliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
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

        [DisplayName("Security Deposit Amount")]
        public double SecurityDepositAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Amount")]
        public double AdvanceAmount { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public double AdvanceAdjustmentPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double AdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Unadjusted Advance")]
        public double UnadjustedAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Difference")]
        public double Difference { get; set; }

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
    }
}