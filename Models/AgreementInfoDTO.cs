using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RMS.Models
{
    public class AgreementInfoDTO
    {
        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        //========Basic Info//========
        [DisplayName("Premise Type")]
        public int PremiseTypeSLNo { get; set; }

        [DisplayName("Premise Type Code")]
        public int PremiseTypeCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Premise Address")]
        public string PremiseAddress { get; set; }

        [DisplayName("Concern Branch")]
        public string ConcernBranch { get; set; }

        [DisplayName("Inspector Name")]
        public string InspectorName { get; set; }

        [DisplayName("Inspector Contact")]
        public string InspectorContactNo { get; set; }

        [DisplayName("Cluster Group")]
        public string ClusterGroup { get; set; }

        //========Agreement Info//========
        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

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

        [DisplayName("Rent Due Days")]
        public int RentDueDay { get; set; }

        [DisplayName("Unit of Measurement")]
        public int UOM { get; set; }

        [DisplayName("Unit of Measurement")]
        public string UOMName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Area")]
        public double TotalArea { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Cost Per Unit")]
        public double CostPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rent Amount")]
        public double RentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Rent Amount")]
        public double TotalRentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Security Deposit Amount")]
        public double SecurityDepositAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Amount")]
        public double AdvanceAmount { get; set; }

        public double AdditionalAdvanceAmount { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public double AdvanceAdjustmentPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double AdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax %")]
        public double TaxPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Tax Amount")]
        public double TaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT %")]
        public double VATPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("VAT Amount")]
        public double VATAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge")]
        public double ServiceCharge { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower Charge")]
        public double OnlineTower { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space Charge")]
        public double GeneratorSpace { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Car Parking Charge")]
        public double CarParking { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Net Rent Amount")]
        public double NetRentAmount { get; set; }

        [DisplayName("Agreement Status")]
        public int AgreementStatus { get; set; }

        [DisplayName("Agreement Text")]
        public string AgreementText { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("User ID")]
        public int UserSLNo { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; }

        [DisplayName("Terminated By")]
        public string TerminatedBy { get; set; }

        [DisplayName("Entry Date")]
        public string EntryDate { get; set; }

        [DisplayName("Edit By")]
        public string EditBy { get; set; }

        [DisplayName("Edit Date")]
        public DateTime? EditDate { get; set; }
        public string strEditDate { get; set; }

        [DisplayName("Activate By")]
        public string ActivateBy { get; set; }

        [DisplayName("Activate Date")]
        public DateTime? ActivateDate { get; set; }
        public string strActivateDate { get; set; }

        public bool IsDeleted { get; set; }
        public string RowNumber { get; set; }
        public int ftrCount { get; set; }
        public int SpaceftrCount { get; set; }
        public int AdvanceftrCount { get; set; }
        public int RIftrCount { get; set; }
        public int LIftrCount { get; set; }
        public int CCftrCount { get; set; }
        public int UIftrCount { get; set; }


        //========Space Info//========

        public int SpaceSLNo { get; set; }

        [DisplayName("Sub Premises Type")]
        public string SpaceType { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Area")]
        public double SpaceArea { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Rate")]
        public double SpaceRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Monthly Rent")]
        public double SpaceRent { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Total Advance")]
        public double SpaceTotalAdvance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Monthly Advance Adjustment")]
        public double SpaceTotalAdjustment { get; set; }

        [DisplayName("Remarks")]
        public string SpaceRemarks { get; set; }

        public string SpaceTypeList { get; set; }
        public string SpaceAreaList { get; set; }
        public string SpaceRateList { get; set; }
        public string SpaceRentList { get; set; }
        public string SpaceTotalAdvanceList { get; set; }
        public string SpaceTotalAdjustmentList { get; set; }
        public string SpaceRemarksList { get; set; }

        //========Advance Info//========

        [DisplayName("Advance SL No")]
        public int AdvanceSLNo { get; set; }

        [DisplayName("Advance No")]
        public int AdvanceNo { get; set; }

        [DisplayName("Start Date")]
        public string AdvanceStartDate { get; set; }

        [DisplayName("End Date")]
        public string AdvanceEndDate { get; set; }

        [DisplayName("Advance Adjustment Period")]
        public int AdvanceSlotPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Advance Adjustment Amount")]
        public double AdvanceSlotAmount { get; set; }

        public string AdvanceNote { get; set; }

        public string AdvanceNoList { get; set; }
        public string AdvanceStartDateList { get; set; }
        public string AdvanceEndDateList { get; set; }
        public string AdvanceSlotPeriodList { get; set; }
        public string AdvanceSlotAmountList { get; set; }
        public string AdvanceNoteList { get; set; }

        //========Review Info//========
        [DisplayName("Review SL No")]
        public int ReviewSLNo { get; set; }

        [DisplayName("Enhancement No")]
        public int ReviewNo { get; set; }

        [DisplayName("Start Date")]
        public string ReviewStartDate { get; set; }

        [DisplayName("End Date")]
        public string ReviewEndDate { get; set; }

        [DisplayName("Enhancement Period")]
        public int ReviewPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Increase Amount")]
        public double ReviewIncreaseAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Increase Percentage")]
        public double ReviewIncreasePercentage { get; set; }

        public string ReviewNote { get; set; }

        public string ReviewNoList { get; set; }
        public string ReviewStartDateList { get; set; }
        public string ReviewEndDateList { get; set; }
        public string ReviewPeriodList { get; set; }
        public string ReviewIncreaseAmountList { get; set; }
        public string ReviewIncreasePercentageList { get; set; }
        public string ReviewNoteList { get; set; }

        //========Landlord Info//========
        [DisplayName("Landlord SL No")]
        public int LandlordSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string LandlordName { get; set; }

        [DisplayName("Mode Of Payment")]
        public int ModeOfPayment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Advance %")]
        public double VendorAdvancePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Advance Amount")]
        public double VendorAdvanceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Advance Adjustment %")]
        public double VendorAdvanceAdjustmentPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Advance Adjustment Amount")]
        public double VendorAdvanceAdjustmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Rent %")]
        public double VendorRentPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Rent Amount")]
        public double VendorRentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Tax %")]
        public double VendorTaxPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Tax Amount")]
        public double VendorTaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing VAT %")]
        public double VendorVATPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing VAT Amount")]
        public double VendorVATAmount { get; set; }

        [DisplayName("Address")]
        public string LLAddress { get; set; }

        [DisplayName("ContactNo")]
        public string LLContactNo { get; set; }

        [DisplayName("Email")]
        public string LLEmail { get; set; }

        [DisplayName("Bank A/C No")]
        public string ACNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Routing No")]
        public string RoutingNo { get; set; }

        public string VendorCodeList { get; set; }
        public string LandlordNameList { get; set; }
        public string ModeOfPaymentList { get; set; }
        public string VendorAdvancePCList { get; set; }
        public string VendorAdvanceAmountList { get; set; }
        public string VendorAdvanceAdjustmentPCList { get; set; }
        public string VendorAdvanceAdjustmentAmountList { get; set; }
        public string VendorTaxPCList { get; set; }
        public string VendorTaxAmountList { get; set; }
        public string VendorVATPCList { get; set; }
        public string VendorVATAmountList { get; set; }
        public string VendorRentPCList { get; set; }
        public string VendorRentAmountList { get; set; }
        public string LLAddressList { get; set; }
        public string LLContactNoList { get; set; }
        public string LLEmailList { get; set; }
        public string ACNoList { get; set; }
        public string BankNameList { get; set; }
        public string BranchNameList { get; set; }
        public string RoutingNoList { get; set; }

        //========Cost Center Info//========
        [DisplayName("CC SLNo")]
        public int CCSLNo { get; set; }

        [DisplayName("Cost Center Code")]
        public string CCCode { get; set; }

        [DisplayName("Cost Center Name")]
        public string CCName { get; set; }

        [DisplayName("SOL SLNo")]
        public int SOLSLNo { get; set; }

        [DisplayName("SOL Code")]
        public string SOLCode { get; set; }

        [DisplayName("SOL Name")]
        public string SOLName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Share Allotment %")]
        public double CCShareAllotment { get; set; }

        [DisplayName("Text")]
        public string CCText { get; set; }

        public string CCCodeList { get; set; }
        public string CCNameList { get; set; }
        public string SOLCodeList { get; set; }
        public string SOLNameList { get; set; }
        public string CCShareAllotmentList { get; set; }
        public string CCTextList { get; set; }

        //========Utility Info//========
        [DisplayName("Landlord SL No")]
        public int UtilityLandlordSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string UtilityVendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string UtilityLandlordName { get; set; }

        [DisplayName("Mode Of Payment")]
        public int UtilityModeOfPayment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Service Charge %")]
        public double ServiceChargePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Service Charge Amount")]
        public double ServiceChargeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Online Tower Charge %")]
        public double OnlineTowerPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Online Tower Amount")]
        public double OnlineTowerAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Generator Space Charge %")]
        public double GeneratorSpacePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Generator Space Amount")]
        public double GeneratorSpaceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Car Parking Charge %")]
        public double CarParkingPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Car Parking Amount")]
        public double CarParkingAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Tax %")]
        public double UtilityTaxPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing Tax Amount")]
        public double UtilityTaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing VAT %")]
        public double UtilityVATPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Sharing VAT Amount")]
        public double UtilityVATAmount { get; set; }

        [DisplayName("Address")]
        public string UtilityAddress { get; set; }

        [DisplayName("ContactNo")]
        public string UtilityContactNo { get; set; }

        [DisplayName("Email")]
        public string UtilityEmail { get; set; }

        [DisplayName("Bank A/C No")]
        public string UtilityACNo { get; set; }

        [DisplayName("Bank Name")]
        public string UtilityBankName { get; set; }

        [DisplayName("Branch Name")]
        public string UtilityBranchName { get; set; }

        [DisplayName("Routing No")]
        public string UtilityRoutingNo { get; set; }

        public string UtilityVendorCodeList { get; set; }
        public string UtilityLandlordNameList { get; set; }
        public string UtilityModeOfPaymentList { get; set; }
        public string ServiceChargePCList { get; set; }
        public string ServiceChargeAmountList { get; set; }
        public string OnlineTowerPCList { get; set; }
        public string OnlineTowerAmountList { get; set; }
        public string GeneratorSpacePCList { get; set; }
        public string GeneratorSpaceAmountList { get; set; }
        public string CarParkingPCList { get; set; }
        public string CarParkingAmountList { get; set; }
        public string UtilityTaxPCList { get; set; }
        public string UtilityTaxAmountList { get; set; }
        public string UtilityVATPCList { get; set; }
        public string UtilityVATAmountList { get; set; }
        public string UtilityAddressList { get; set; }
        public string UtilityContactNoList { get; set; }
        public string UtilityEmailList { get; set; }
        public string UtilityACNoList { get; set; }
        public string UtilityBankNameList { get; set; }
        public string UtilityBranchNameList { get; set; }
        public string UtilityRoutingNoList { get; set; }

        //========Attached Documents//========
        public string FUFileNameList { get; set; }
        //========Control Data//========
        
        [DisplayName("Cash GL Code")]
        public string CashGLCode { get; set; }

        [DisplayName("Bank GL Code")]
        public string BankGLCode { get; set; }

        [DisplayName("Advance GL Code")]
        public string AdvanceGLCode { get; set; }

        [DisplayName("Advance Adjustment GL Code")]
        public string AdvanceAdjustmentGLCode { get; set; }

        [DisplayName("Rent GL Code")]
        public string RentGLCode { get; set; }

        [DisplayName("Utility GL Code")]
        public string ServiceChargeGLCode { get; set; }

        [DisplayName("Tax GL Code")]
        public string TaxGLCode { get; set; }

        [DisplayName("VAT GL Code")]
        public string VATGLCode { get; set; }

        //==
        [DisplayName("Provision Tax GL Code")]
        public string ProvisionGLTax { get; set; }
        [DisplayName("Provision AP GL Code")]
        public string ProvisionGLAP { get; set; }
        [DisplayName("RTGS GL Code")]
        public string RTGSGL { get; set; }
        [DisplayName("EFTN GL Code")]
        public string EFTNGL { get; set; }
        [DisplayName("Pay Order GL Code")]
        public string PayOrderGL { get; set; }
        [DisplayName("IBB Payment GL Code")]
        public string IBBPaymentGL { get; set; }
        [DisplayName("City Brokerage GL Code")]
        public string CityBrokerageGL { get; set; }
        [DisplayName("City Capital GL Code")]
        public string CityCapitalGL { get; set; }
        [DisplayName("Others GL Code")]
        public string OthersGL { get; set; }
        //==

        //========Attach Documents//========

        //==
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }
       
        public string BlockText { get; set; }

        [DisplayName("Block By")]
        public string BlockUserID { get; set; }

        public int AgreementType { get; set; }
        public int AgreementVersion { get; set; }
        public string AliasCode { get; set; }
        public string xAliasCode { get; set; }
        public bool IsRenewal { get; set; }
        public int xRenewalAgreementSLNo { get; set; }
        public int yRenewalAgreementSLNo { get; set; }
        public bool IsModified { get; set; }
        public int xModifiedAgreementSLNo { get; set; }
        public int yModifiedAgreementSLNo { get; set; }

        public int ReviewFrequency { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double ReviewPercentage { get; set; }

        [DisplayName("Tax Type")]
        public int TaxType { get; set; }

        public int xTaxType { get; set; }

        [DisplayName("VAT Type")]
        public int VatType { get; set; }

        [DisplayName("Landlord/Utility")]
        public string LandlordUtility { get; set; }

        public bool IsHoldBlockPayment { get; set; }

        public bool Special { get; set; }

        public string PremiseAddressBangla { get; set; }

        [DisplayName("Area Status")]
        public string AreaStatus { get; set; }

        [DisplayName("Regional Office")]
        public string RegionalOffice { get; set; }

        [DisplayName("Primary SOL")]
        public string PrimarySOL { get; set; }

        [DisplayName("Attached Control")]
        public string AttachedControl { get; set; }

        [DisplayName("Controller Office Distance")]
        public string ControllerOfficeDistance { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

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

        [DisplayName("Premises Type for Accounts")]
        public string PremisesTypeforAccounts { get; set; }

        [DisplayName("Parent Agreement Code")]
        public string ParentAgreementCode { get; set; }

        [DisplayName("Electricity Load (KW)")]
        public string ElectricityLoad { get; set; }

        [DisplayName("Electricity Provided By")]
        public string ElectricityProvidedBy { get; set; }

        [DisplayName("AIT Bourne By")]
        public string AITBourneBy { get; set; }

        [DisplayName("Commercial Permission")]
        public string CommercialPermission { get; set; }

        [DisplayName("Building Plan")]
        public string BuildingPlan { get; set; }

        [DisplayName("Premises Situated Floor")]
        public string PremisesSituatedFloor { get; set; }

        [DisplayName("Bangladesh Bank Approval")]
        public string BangladeshBankApproval { get; set; }

        [DisplayName("Bangladesh Bank Reference")]
        public string BangladeshBankReference { get; set; }

        [DisplayName("IT Tower Rent Clause")]
        public string ITTowerRentClause { get; set; }

        [DisplayName("Termination Clause")]
        public string TerminationClause { get; set; }

        [DisplayName("Termination Notice Period")]
        public int TerminationNoticePeriod { get; set; }

        [DisplayName("Premises Opening Date")]
        public string PremisesOpeningDate { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Remarks")]
        public string AgreementRemarks { get; set; }

        [DisplayName("Remarks")]
        public string AdvanceRemarks { get; set; }

        [DisplayName("Remarks")]
        public string ReviewRemarks { get; set; }

        [DisplayName("Remarks")]
        public string LLRemarks { get; set; }

        [DisplayName("Remarks")]
        public string CCRemarks { get; set; }
        
        [DisplayName("Remarks")]
        public string UtilityRemarks { get; set; }

        [DisplayName("Remarks")]
        public string ControlDataRemarks { get; set; }

        [DisplayName("Document Date")]
        public string DocumentDate { get; set; }

        [DisplayName("Payment Method")]
        public string PaymentMethod { get; set; }

        [DisplayName("IFRS16 Reporting")]
        public bool IsIFRSEnable { get; set; }

        [DisplayName("Calculation Method")]
        public string CalculationMethod { get; set; }

        [DisplayName("WithHolding Code")]
        public string WithHoldingCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Borrowing Rate %")]
        public double BorrowingRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("CorporateTax Rate %")]
        public double CorporateTaxRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Additional Expense")]
        public double AdditionalExpense { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Initial Direct Cost")]
        public double InitialDirectCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Dismantling Cost")]
        public double DismantlingCost { get; set; }

        [DisplayName("Car Parking No")]
        public string CarParkingNo { get; set; }

        public bool IsClosed { get; set; }

        [DisplayName("Water Bill Type")]
        public string WaterBillType { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Water Bill Amount")]
        public double WaterBillAmount { get; set; }

        [DisplayName("IFRS 16 Effective Date")]
        public string IFRSEffectiveDate { get; set; }
    }
}