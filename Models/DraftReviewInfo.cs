using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DraftReviewInfo
    {
        [Key]
        public int ReviewSLNo { get; set; }
        public int ReviewNo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual DraftAgreementInfo DraftAgreementInfo { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Period { get; set; }
        public double IncreaseAmount { get; set; }
        public double IncreasePercentage { get; set; }
        public string ReviewNote { get; set; }
    }
}