using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class UtilityInfoDTO
    {
        [DisplayName("Utility SL No")]
        public int UtilitySLNo { get; set; }

        [DisplayName("Agreement SL No")]
        public int AgreementSLNo { get; set; }

        [DisplayName("Vendor Code")]
        public string UtilityVendorCode { get; set; }

        [DisplayName("Landlord Name")]
        public string UtilityLandlordName { get; set; }

        [DisplayName("Mode Of Payment")]
        public int UtilityModeOfPayment { get; set; }

        [DisplayName("Mode Of Payment")]
        public string UtilityModeOfPaymentText { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge %")]
        public double ServiceChargePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Service Charge Amount")]
        public double ServiceChargeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower Charge %")]
        public double OnlineTowerPC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Online Tower Amount")]
        public double OnlineTowerAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space Charge %")]
        public double GeneratorSpacePC { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Generator Space Amount")]
        public double GeneratorSpaceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Car Parking Charge %")]
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

        [DisplayName("Account No")]
        public string UtilityACNo { get; set; }

        [DisplayName("Bank Name")]
        public string UtilityBankName { get; set; }

        [DisplayName("Branch Name")]
        public string UtilityBranchName { get; set; }

        [DisplayName("Routing No")]
        public string UtilityRoutingNo { get; set; }

        public string UtilityRowNumber { get; set; }
        public int UtilityftrCount { get; set; }

        public bool IsHoldBlockPayment { get; set; }

        [DisplayName("Agreement Code")]
        public int AgreementCode { get; set; }

        [DisplayName("Agreement Name")]
        public string AgreementName { get; set; }

        public string AliasCode { get; set; }

        [DisplayName("Premise Type")]
        public string PremiseType { get; set; }

        [DisplayName("Premise Name")]
        public string PremiseName { get; set; }

        [DisplayName("Premise Address")]
        public string PremiseAddress { get; set; }


        [DisplayName("Agreement Start Date")]
        public string AgreementStartDate { get; set; }

        [DisplayName("Agreement End Date")]
        public string AgreementEndDate { get; set; }

        [DisplayName("Schedule No")]
        public int AgreementPeriod { get; set; }

        [DisplayName("Address")]
        public string UtilityAddress { get; set; }

        [DisplayName("Contact No")]
        public string UtilityContactNo { get; set; }

        [DisplayName("Email")]
        public string UtilityEmail { get; set; }

        public bool IsOld { get; set; }

        public int AgreementType { get; set; }
    }
}

