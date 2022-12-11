using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class ServiceInfoDTO
    {
        [DisplayName("Service")]
        public int ServiceSLNo { get; set; }

        [DisplayName("Service Code")]
        public int ServiceCode { get; set; }

        [DisplayName("Service Name")]
        public string ServiceName { get; set; }

        [DisplayName("Service Cost")]
        public double ServiceCost { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("User ID")]
        public int UserSLNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

