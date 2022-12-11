using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class BorrowingRateDetails
    {
        [Key]
        public int SLNo { get; set; }
        public int MonthNo { get; set; }
        public double Rate { get; set; }
        public double PV1 { get; set; }
        public double PV2 { get; set; }
        
        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }
    }
}