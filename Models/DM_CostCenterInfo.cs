using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_CostCenterInfo
    {
        [Key]
        public int CCSLNo { get; set; }
        public string AgreementCode { get; set; }
        public string CCCode { get; set; }
        public string CCName { get; set; }
        public string SOLCode { get; set; }
        public string SOLName { get; set; }
        public double CCShareAllotment { get; set; }
    }
}