using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class FileUploadInfoDTO
    {
        public int SLNo { get; set; }
        public int AgreementSLNo { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FURowNumber { get; set; }
        public int FUftrCount { get; set; }
    }
}