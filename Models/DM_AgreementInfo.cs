using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class DM_AgreementInfo
    {
        [Key]
        public int AgreementSLNo { get; set; }
        //==Basic Info
        public string PremiseType { get; set; }
        public string PremiseName { get; set; }
        public string PremiseAddress { get; set; }
        //==Agreement Info
        public string AgreementCode { get; set; }
        public string AgreementName { get; set; }
        public DateTime AgreementStartDate { get; set; }
        public DateTime AgreementEndDate { get; set; }
        public int AgreementPeriod { get; set; }
        public int PostedMonths { get; set; }
        public string UOM { get; set; }
        public double TotalArea { get; set; }
        public double CostPerUnit { get; set; }
        public double TotalRentAmount { get; set; }
        public int RentDueDay { get; set; }
        public double SecurityDepositAmount { get; set; }
        public double AdvanceAmount { get; set; }
        public double TaxPC { get; set; }
        public double VATPC { get; set; }
        public string TaxType { get; set; }
        public string VATType { get; set; }
        public int ReviewFrequency { get; set; }
        public double ReviewPC { get; set; }
        //==Control Data
        public string AdvanceGLCode { get; set; }
        public string AdvanceAdjustmentGLCode { get; set; }
        public string CashGLCode { get; set; }
        public string BankGLCode { get; set; }
        public string RentGLCode { get; set; }
        public string UtilityGLCode { get; set; }
        public string TaxGLCode { get; set; }
        public string VATGLCode { get; set; }
        //==
        public string ProvisionGLTax { get; set; }
        public string ProvisionGLAP { get; set; }
        public string RTGSGL { get; set; }
        public string EFTNGL { get; set; }
        public string PayOrderGL { get; set; }
        public string IBBPaymentGL { get; set; }
        public string CityBrokerageGL { get; set; }
        public string CityCapitalGL { get; set; }
        public string OthersGL { get; set; }
        //==
        //==Utility
        public double ServiceCharge { get; set; }
        public double OnlineTower { get; set; }
        public double GeneratorSpace { get; set; }
        public double CarParking { get; set; }
        //==Additional
        public string PremiseAddressBangla { get; set; }
        public string AreaStatus { get; set; }
        public string RegionalOffice { get; set; }
        public string PrimarySOL { get; set; }
        public string AttachedControl { get; set; }
        public string ControllerOfficeDistance { get; set; }
        public string RoutingNumber { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string Upazila { get; set; }
        public string Thana { get; set; }
        public string ThanaCode { get; set; }
        public string Pourasabha { get; set; }
        public string PourasabhaType { get; set; }
        public string UnionName { get; set; }
        public string WardNo { get; set; }
        public string PremisesTypeforAccounts { get; set; }
        public string ParentAgreementCode { get; set; }
        public string ElectricityLoad { get; set; }
        public string ElectricityProvidedBy { get; set; }
        public string AITBourneBy { get; set; }
        public string CommercialPermission { get; set; }
        public string BuildingPlan { get; set; }
        public string PremisesSituatedFloor { get; set; }
        public string BangladeshBankApproval { get; set; }
        public string BangladeshBankReference { get; set; }
        public string ITTowerRentClause { get; set; }
        public string TerminationClause { get; set; }
        public int TerminationNoticePeriod { get; set; }
        public DateTime? PremisesOpeningDate { get; set; }
        public string AgreementRemarks { get; set; }
        public DateTime? DocumentDate { get; set; }
        public double BorrowingRate { get; set; }
        public double CorporateTaxRate { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsIFRSEnable { get; set; }
        public string CalculationMethod { get; set; }
        public string WithHoldingCode { get; set; }
        public double AdditionalExpense { get; set; }
        public double InitialDirectCost { get; set; }
        public double DismantlingCost { get; set; }
        public string CarParkingNo { get; set; }
        public string WaterBillType { get; set; }
        public double WaterBillAmount { get; set; }
        public DateTime? IFRSEffectiveDate { get; set; }
    }
}