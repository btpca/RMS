using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class PremiseTypeInfo
    {
        [Key]
        public int PremiseTypeSLNo { get; set; }

        public int PremiseTypeCode { get; set; }

        public string PremiseType { get; set; }

        public int Status { get; set; }

        [DisplayName("Edit By")]
        public string EditBy { get; set; }

        [DisplayName("Edit Date")]
        public DateTime? EditDate { get; set; }

        public int UserSLNo { get; set; }
        [ForeignKey("UserSLNo")]
        public virtual UserInfo UserInfo { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}