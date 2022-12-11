using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class Lookup
    {
        [Key]
        public int LookupSLNo { get; set; }

        public string GroupName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ParentCode { get; set; }

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