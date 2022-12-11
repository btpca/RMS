using System;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UtilityVendorPJExecuteLog
    {
        [Key]
        public int LogSLNo { get; set; }

        public int LogID { get; set; }

        public string LogName { get; set; }

        public DateTime LogDate { get; set; }

        public int PremiseTypeSLNo { get; set; }

        public int AgreementSLNo { get; set; }

        public int UtilitySLNo { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public string LogStatus { get; set; }

        public int Status { get; set; }

        public string EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExecuteDate { get; set; }

        public string ExecuteBy { get; set; }

    }
}