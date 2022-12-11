using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class SpaceInfoDTO
    {
        public int SpaceSLNo { get; set; }
        public int AgreementSLNo { get; set; }
        public string SpaceType { get; set; }
        public double SpaceArea { get; set; }
        public double SpaceRate { get; set; }
        public double SpaceRent { get; set; }
        public double SpaceTotalAdvance { get; set; }
        public double SpaceTotalAdjustment { get; set; }
        public string SpaceRemarks { get; set; }

        public string SpaceRowNumber { get; set; }
        public int SpaceftrCount { get; set; }

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

