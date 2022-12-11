using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class LookupDTO
    {
        public int LookupSLNo { get; set; }

        public string GroupName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ParentCode { get; set; }


        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("Edit By")]
        public string EditBy { get; set; }

        [DisplayName("Edit Date")]
        public DateTime? EditDate { get; set; }

        [DisplayName("User SLNo")]
        public int UserSLNo { get; set; }

        [DisplayName("Create By")]
        public string UserID { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Create Date")]
        public DateTime EntryDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

