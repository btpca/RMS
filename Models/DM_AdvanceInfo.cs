using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_AdvanceInfo
    {
        [Key]
        public int AdvanceSLNo { get; set; }
        public int AdvanceNo { get; set; }
        public string AgreementCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AdvanceSlotPeriod { get; set; }
        public double AdvanceSlotAmount { get; set; }
        public string AdvanceNote { get; set; }
    }
}