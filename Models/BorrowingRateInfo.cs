using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class BorrowingRateInfo
    {
        [Key]
        public int SLNo { get; set; }

        [DisplayName("Incremental Borrowing Rate")]
        public double BorrowingRate { get; set; }

        public int UserSLNo { get; set; }
        public DateTime EntryDate { get; set; }
    }
}