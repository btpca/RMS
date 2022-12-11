using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class RentAPExecuteLog
    {
        [Key]
        public int LogSLNo { get; set; }

        public int LogID { get; set; }

        public string LogName { get; set; }

        public DateTime LogDate { get; set; }

        public int PremiseTypeSLNo { get; set; }
        [ForeignKey("PremiseTypeSLNo")]
        public virtual PremiseTypeInfo PremiseTypeInfo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public string LogStatus { get; set; }

        public int Status { get; set; }

        public string EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExecuteDate { get; set; }

        public string ExecuteBy { get; set; }

        public int LogYear { get; set; }

        public string LogMonth { get; set; }

    }
}