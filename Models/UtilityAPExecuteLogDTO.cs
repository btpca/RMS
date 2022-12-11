using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UtilityAPExecuteLogDTO
    {
        [DisplayName("Log SL No")]
        public int LogSLNo { get; set; }

        [DisplayName("Log ID")]
        public int LogID { get; set; }

        [DisplayName("Log Name")]
        public string LogName { get; set; }

        [DisplayName("Log Date")]
        public string LogDate { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayName("Premise Type")]
        public int PremiseTypeSLNo { get; set; }

        [DisplayName("Premise Type Code")]
        public int PremiseTypeCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

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

        [DisplayName("Log Status")]
        public string LogStatus { get; set; }
        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("User ID")]
        public string EntryBy { get; set; }

        [DisplayName("Entry Date")]
        public string EntryDate { get; set; }

        [DisplayName("Execute Date")]
        public string ExecuteDate { get; set; }

        [DisplayName("Execute By")]
        public string ExecuteBy { get; set; }
        
        public int RowNumber { get; set; }

        public string LogIDList { get; set; }

    }
}