using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DraftSpaceInfo
    {
        [Key]
        public int SpaceSLNo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual DraftAgreementInfo DraftAgreementInfo { get; set; }

        public string SpaceType { get; set; }
        public double SpaceArea { get; set; }
        public double SpaceRate { get; set; }
        public double SpaceRent { get; set; }
        public double SpaceTotalAdvance { get; set; }
        public double SpaceTotalAdjustment { get; set; }
        public string SpaceRemarks { get; set; }
    }
}