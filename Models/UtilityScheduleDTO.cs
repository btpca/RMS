using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UtilityScheduleDTO
    {
        //========Contract Schedule//========
        [DisplayName("SL No")]
        public int SLNO { get; set; }

        [DisplayName("Utility Schedule SL No")]
        public int UScheduleSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Schedule Date")]
        public DateTime ScheduleDate { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Utility SL No")]
        public int UtilitySLNo { get; set; }

        [DisplayName("Premise Type")]
        public int PremiseTypeSLNo { get; set; }

        [DisplayName("Premise Type Code")]
        public int PremiseTypeCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Month No")]
        public int MonthNo { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge %")]
        public double ServiceChargePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge Amount")]
        public double ServiceChargeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower %")]
        public double OnlineTowerPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower Amount")]
        public double OnlineTowerAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space %")]
        public double GeneratorSpacePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space Amount")]
        public double GeneratorSpaceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName(" Car Parking %")]
        public double CarParkingPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Car Parking Amount")]
        public double CarParkingAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double UtilityTaxPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double UtilityTaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double UtilityVATPC { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double UtilityVATAmount { get; set; }


        [DisplayName("User ID")]
        public int UserSLNo { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; }

        [DisplayName("Entry Date")]
        public string EntryDate { get; set; }

        public bool IsLog { get; set; }

        public bool IsPosted { get; set; }

        //==AP Posting Info
        public string PostText { get; set; }

        [DisplayName("AP Posting ID")]
        public string PostingID { get; set; }

        [DisplayName("AP Posting")]
        public DateTime? PostingDate { get; set; }

        [DisplayName("AP Posting User ID")]
        public int? PostingUserSLNo { get; set; }

        //==Payment Posting Info
        public bool IsPJPosted { get; set; }

        public string PJPostText { get; set; }

        [DisplayName("Payment Posting ID")]
        public string PJPostingID { get; set; }

        [DisplayName("Payment Posting")]
        public string PJPostingDate { get; set; }

        [DisplayName("Payment Posting User ID")]
        public int? PJPostingUserSLNo { get; set; }

        public string RowNumber { get; set; }
        public int ftrCount { get; set; }

        //========Agreement Info//========

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayName("Agreement End Date")]
        public string AgreementEndDate { get; set; }

        [DisplayName("Schedule No")]
        public int AgreementPeriod { get; set; }

        [DisplayName("Renewal After")]
        public int RenewalFrequency { get; set; }

        [DisplayName("Enhancement Frequency")]
        public int ReviewPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Enhancement Increase %")]
        public double ReviewIncrease { get; set; }

        [DisplayName("Rent Due Day")]
        public int RentDueDay { get; set; }

        [DisplayName("Unit of Measurement")]
        public int UOM { get; set; }


        [DisplayName("Agreement Status")]
        public int AgreementStatus { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        //==
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }

        public string BlockText { get; set; }

        [DisplayName("Block By")]
        public string BlockUserID { get; set; }

        public List<int> PremiseTypeSLNoCheckList { get; set; }
        public List<int> AgreementSLNoCheckList { get; set; }
        public List<int> VendorSLNoCheckList { get; set; }

        [DisplayName("Log Name")]
        public string LogName { get; set; }

        [DisplayName("From Month")]
        public string FromMonthName { get; set; }

        [DisplayName("To Month")]
        public string ToMonthName { get; set; }

        [DisplayName("CC Code")]
        public string CCCode { get; set; }

        [DisplayName("CC Name")]
        public string CCName { get; set; }

        [DisplayName("SOL Code")]
        public string SOLCode { get; set; }

        [DisplayName("SOL Name")]
        public string SOLName { get; set; }

        [DisplayName("Tax Type")]
        public int TaxType { get; set; }

        [DisplayName("VAT Type")]
        public int VatType { get; set; }

        [DisplayName("Mode Of Payment")]
        public int ModeOfPayment { get; set; }

        [DisplayName("Mode Of Payment")]
        public string ModeOfPaymentText { get; set; }

        [DisplayName("Account No")]
        public string ACNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Routing No")]
        public string UtilityRoutingNo { get; set; }

        public bool IsHoldBlockPayment { get; set; }
    }
}