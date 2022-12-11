using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class StatusInfo
    {
        [Key]
        public int StatusID { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }
        public int StatusValue { get; set; }
    }
}