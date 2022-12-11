using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class FileUploadInfo
    {
        [Key]
        public int SLNo { get; set; }

        public int AgreementSLNo { get; set; }
        [ForeignKey("AgreementSLNo")]
        public virtual AgreementInfo AgreementInfo { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}