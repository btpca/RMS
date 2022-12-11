using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DraftCostCenterInfo
    {
        [Key]
        public int CCSLNo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual DraftAgreementInfo DraftAgreementInfo { get; set; }

        public string CCCode { get; set; }
        public string CCName { get; set; }
        public string SOLCode { get; set; }
        public string SOLName { get; set; }
        public double CCShareAllotment { get; set; }
        public string CCText { get; set; }
    }
}