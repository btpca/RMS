using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class LeaseInfoDTO
    {
        [DisplayName("SL No")]
        public int SLNO { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        [DisplayName("Agreement Code")]
        public string AliasCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Primary SOL")]
        public string PrimarySOL { get; set; }

        [DisplayName("Premises Sub Type")]
        public string SpaceType { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Landlord Address")]
        public string LandlordAddress { get; set; }

        [DisplayName("Premise Address (English)")]
        public string PremiseAddressEnglish { get; set; }

        [DisplayName("Premise Address (Bangla)")]
        public string PremiseAddressBangla { get; set; }

        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayName("Agreement End Date")]
        public string AgreementEndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Security Deposit")]
        public double SecurityDeposit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Paid")]
        public double SpaceTotalAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Monthly Rent")]
        public double SpaceRent { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Monthly Adjustment")]
        public double SpaceMonthlyAdjustment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Payable After Adjustment")]
        public double SpacePayableAfterAdjustment { get; set; }

        [DisplayName("Water Bill")]
        public string WaterBill { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge")]
        public double ServiceChargeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total")]
        public double TotalCalculation { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Monthly Total Payable")]
        public double MonthlyTotalPayable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Spaces (sft)")]
        public double SpaceArea { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent Per Sft")]
        public double RentPerSft { get; set; }

        [DisplayName("Payment Date")]
        public string PaymentDate { get; set; }

        [DisplayName("Enhancement Remarks")]
        public string EnhancementRemarks { get; set; }

        [DisplayName("1st Enhancement Effective")]
        public string First_EnhancementEffectiveDate { get; set; }

        [DisplayName("2nd Enhancement Effective")]
        public string Second_EnhancementEffectiveDate { get; set; }

        [DisplayName("3rd Enhancement Effective")]
        public string Third_EnhancementEffectiveDate { get; set; }

        [DisplayName("4th Enhancement Effective")]
        public string Fourth_EnhancementEffectiveDate { get; set; }

        [DisplayName("5th Enhancement Effective")]
        public string Fifth_EnhancementEffectiveDate { get; set; }

        [DisplayName("More Enhancement")]
        public string MoreEnhancement { get; set; }

        [DisplayName("Electricity Load (KW)")]
        public string ElectricityLoad { get; set; }

        [DisplayName("Electricity Provided By")]
        public string ElectricityProvidedBy { get; set; }

        [DisplayName("AIT Bourne By")]
        public string AITBourneBy { get; set; }

        [DisplayName("IT Tower Rent Clause")]
        public string ITTowerRentClause { get; set; }

        [DisplayName("Commercial Permission")]
        public string CommercialPermission { get; set; }

        [DisplayName("Termination Clause")]
        public string TerminationClause { get; set; }

        [DisplayName("Termination Notice Period")]
        public int TerminationNoticePeriod { get; set; }

        [DisplayName("Premises Opening Date")]
        public string PremisesOpeningDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Period")]
        public double AdvanceAdjustmentPeriod { get; set; }

        [DisplayName("Advance Adjustment End Date)")]
        public string SpaceRemarks { get; set; }

        [DisplayName("Regional Office")]
        public string RegionalOffice { get; set; }

        [DisplayName("Area Status")]
        public string AreaStatus { get; set; }

        [DisplayName("Attached Control")]
        public string AttachedControl { get; set; }

        [DisplayName("Controller Office Distance")]
        public string ControllerOfficeDistance { get; set; }

        [DisplayName("Bangladesh Bank Approval")]
        public string BangladeshBankApproval { get; set; }

        [DisplayName("Bangladesh Bank Reference")]
        public string BangladeshBankReference { get; set; }

        [DisplayName("Basic Remarks")]
        public string BasicRemarks { get; set; }

        [DisplayName("Agreement Remarks")]
        public string AgreementRemarks { get; set; }

        [DisplayName("Advance Rent Adjustment Clause")]
        public string AdvanceSlotNote { get; set; }

        [DisplayName("Security Deposit Clause")]
        public string AdvanceRemarks { get; set; }

        [DisplayName("Building Plan")]
        public string BuildingPlan { get; set; }

        [DisplayName("Premises Situated Floor")]
        public string PremisesSituatedFloor { get; set; }

        [DisplayName("Routing No")]
        public string RoutingNo { get; set; }

        [DisplayName("Division")]
        public string Division { get; set; }

        [DisplayName("District")]
        public string District { get; set; }

        [DisplayName("Upazila")]
        public string Upazila { get; set; }

        [DisplayName("Thana")]
        public string Thana { get; set; }

        [DisplayName("Thana Code")]
        public string ThanaCode { get; set; }

        [DisplayName("Pourashava")]
        public string Pourasabha { get; set; }

        [DisplayName("Pourashava Type")]
        public string PourasabhaType { get; set; }

        [DisplayName("Union")]
        public string UnionName { get; set; }

        [DisplayName("Ward Number")]
        public string WardNo { get; set; }

    }
}

