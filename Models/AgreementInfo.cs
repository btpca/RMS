using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Models
{
    public class AgreementInfo
    {
        [Key]
        public int AgreementSLNo { get; set; }
        //==Basic Info
        public int PremiseTypeSLNo { get; set; }
        [ForeignKey("PremiseTypeSLNo")]
        public virtual PremiseTypeInfo PremiseTypeInfo { get; set; }

        public string PremiseName { get; set; }
        public string PremiseAddress { get; set; }
        public string ConcernBranch { get; set; }
        public string InspectorName { get; set; }
        public string InspectorContactNo { get; set; }
        public string ClusterGroup { get; set; }
        //==Agreement Info
        public int AgreementCode { get; set; }
        public string AgreementName { get; set; }
        public DateTime AgreementStartDate { get; set; }
        public DateTime AgreementEndDate { get; set; }
        public int AgreementPeriod { get; set; }
        public int RenewalFrequency { get; set; }
        public int RentDueDay { get; set; }
        public int UOM { get; set; }
        public double TotalArea { get; set; }
        public double CostPerUnit { get; set; }
        public double TotalRentAmount { get; set; }
        public double SecurityDepositAmount { get; set; }
        public double AdvanceAmount { get; set; }
        public double AdditionalAdvanceAmount { get; set; }
        public double AdvanceAdjustmentPeriod { get; set; }
        public double AdvanceAdjustmentAmount { get; set; }
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double VATPercentage { get; set; }
        public double VATAmount { get; set; }
        public double ServiceCharge { get; set; }
        public double OnlineTower { get; set; }
        public double GeneratorSpace { get; set; }
        public double CarParking { get; set; }
        public double NetRentAmount { get; set; }
        public int AgreementStatus { get; set; }
        public string AgreementText { get; set; }
        public int Status { get; set; }

        public int UserSLNo { get; set; }
        [ForeignKey("UserSLNo")]
        public virtual UserInfo UserInfo { get; set; }

        public DateTime EntryDate { get; set; }
        
        public string EditBy { get; set; }

        public DateTime? EditDate { get; set; }

        public string ActivateBy { get; set; }

        public DateTime? ActivateDate { get; set; }

        public bool IsDeleted { get; set; }
        //==Control Data
        public string CashGLCode { get; set; }
        public string BankGLCode { get; set; }
        public string AdvanceGLCode { get; set; }
        public string AdvanceAdjustmentGLCode { get; set; }
        public string RentGLCode { get; set; }
        public string ServiceChargeGLCode { get; set; }
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
        public bool IsBlock { get; set; }
        public DateTime? BlockDate { get; set; }
        public int? BlockUserSLNo { get; set; }

        public int AgreementType { get; set; }
        public int AgreementVersion { get; set; }
        public string AliasCode { get; set; }
        public bool IsRenewal { get; set; }
        public int xRenewalAgreementSLNo { get; set; }
        public int yRenewalAgreementSLNo { get; set; }
        public bool IsModified { get; set; }
        public int xModifiedAgreementSLNo { get; set; }
        public int yModifiedAgreementSLNo { get; set; }

        public int ReviewFrequency { get; set; }
        public double ReviewPercentage { get; set; }

        public int TaxType { get; set; }
        public int VatType { get; set; }

        public bool IsHoldBlockPayment { get; set; }
        public bool Special { get; set; }

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
        public string Remarks { get; set; }
        public string AgreementRemarks { get; set; }
        public string AdvanceRemarks { get; set; }
        public string ReviewRemarks { get; set; }
        public string LLRemarks { get; set; }
        public string CCRemarks { get; set; }
        public string UtilityRemarks { get; set; }
        public string ControlDataRemarks { get; set; }
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
        public bool IsClosed { get; set; }
        public string WaterBillType { get; set; }
        public double WaterBillAmount { get; set; }
        public DateTime? IFRSEffectiveDate { get; set; }
    }
}