using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class IFRSControlDataInfo
    {
        [Key]
        public int SLNo { get; set; }

        [DisplayName("Right of Use Assets GL Code")]
        public string RightofUseAssetsGLCode { get; set; }

        [DisplayName("Lease Liability GL Code")]
        public string LeaseLiabilityGLCode { get; set; }

        [DisplayName("Advance Office Rent GL Code")]
        public string AdvanceOfficeRentGLCode { get; set; }

        [DisplayName("Depreciation Expense GL Code")]
        public string DepreciationExpenseGLCode { get; set; }

        [DisplayName("Interest Expense GL Code")]
        public string InterestExpenseGLCode { get; set; }

        [DisplayName("Office Rent Expense GL Code")]
        public string OfficeRentExpenseGLCode { get; set; }

        public int UserSLNo { get; set; }
        public DateTime EntryDate { get; set; }
    }
}