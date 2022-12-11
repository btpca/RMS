using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class ReviewInfoDTO
    {
        [DisplayName("SL No")]
        public int SLNo { get; set; }

        [DisplayName("Enhancement No")]
        public int ReviewNo { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Start Date")]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        public string EndDate { get; set; }

        [DisplayName("Period")]
        public int Period { get; set; }

        [DisplayName("Increase Amount")]
        public double IncreaseAmount { get; set; }

        [DisplayName("Increase Percentage")]
        public double IncreasePercentage { get; set; }

        public string ReviewRowNumber { get; set; }
        public int ReviewftrCount { get; set; }

        public string ReviewNote { get; set; }

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
    }
}

