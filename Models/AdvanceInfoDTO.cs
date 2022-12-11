using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class AdvanceInfoDTO
    {
        [DisplayName("SL No")]
        public int SLNo { get; set; }

        [DisplayName("Advance No")]
        public int AdvanceNo { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Start Date")]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        public string EndDate { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public int AdvanceSlotPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double AdvanceSlotAmount { get; set; }

        public string AdvanceRowNumber { get; set; }
        public int AdvanceftrCount { get; set; }

        public string AdvanceNote { get; set; }


        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        public int AgreementType { get; set; }

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

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Amount")]
        public double AdvanceAmount { get; set; }

    }
}

