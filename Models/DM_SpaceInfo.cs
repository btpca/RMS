using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_SpaceInfo
    {
        [Key]
        public int SpaceSLNo { get; set; }
        public string AgreementCode { get; set; }
        public string SpaceType { get; set; }
        public double SpaceArea { get; set; }
        public double SpaceRate { get; set; }
        public double SpaceRent { get; set; }
        public double SpaceTotalAdvance { get; set; }
        public double SpaceTotalAdjustment { get; set; }
        public string SpaceRemarks { get; set; }
    }
}