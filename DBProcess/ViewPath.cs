using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.DBProcess
{
    public class ViewPath
    {
        public class HomePath
        {
            public string Login = "~/Views/Home/Login.cshtml";
            public string IndexDashboard = "~/Views/Home/IndexDashboard.cshtml";
            public string BranchIndex = "~/Views/Home/BranchIndex.cshtml";
            public string DisplayMessage = "~/Views/Home/DisplayMessage.cshtml";
            public string registration = "~/Views/Security/HomeMvc/Registration.cshtml";
            public string registrationSuccessful = "~/Views/Security/HomeMvc/RegistrationSuccesful.cshtml";
            public string ForgotPassword = "~/Views/Home/ForgotPassword.cshtml";
        }

        public class ErrorPath
        {
            public string Index = "~/Views/Error/Index.cshtml";
        }
        
        public class UserInfoPath
        {
            public string Create = "~/Views/UserInfo/Create.cshtml";
            public string CreateCopyProfile = "~/Views/UserInfo/CreateCopyProfile.cshtml";
            public string CreateIndex = "~/Views/UserInfo/CreateIndex.cshtml";
            public string UserDetails = "~/Views/UserInfo/UserDetails.cshtml";
            public string Edit = "~/Views/UserInfo/Edit.cshtml";
            public string EditIndex = "~/Views/UserInfo/EditIndex.cshtml";
            public string ResetPassword = "~/Views/UserInfo/ResetPassword.cshtml";
            public string DeleteIndex = "~/Views/UserInfo/DeleteIndex.cshtml";
            public string ListOfUsers = "~/Views/UserInfo/ListOfUsers.cshtml";
            public string ListOfUserDetails = "~/Views/UserInfo/ListOfUserDetails.cshtml";
            public string LogRegister = "~/Views/UserInfo/LogRegister.cshtml";
            public string UserSummary = "~/Views/UserInfo/UserSummary.cshtml";
        }

        public class DMInfoPath
        {
            public string UploadDMInfo = "~/Views/DMInfo/UploadDMInfo.cshtml";
        }

            public class AgreementInfoPath
        {
            public string LookupIndex = "~/Views/AgreementInfo/LookupIndex.cshtml";
            public string LookupCreate = "~/Views/AgreementInfo/LookupCreate.cshtml";
            public string LookupEdit = "~/Views/AgreementInfo/LookupEdit.cshtml";

            public string PremiseTypeIndex = "~/Views/AgreementInfo/PremiseTypeIndex.cshtml";
            public string PremiseTypeCreate = "~/Views/AgreementInfo/PremiseTypeCreate.cshtml";
            public string PremiseTypeEdit = "~/Views/AgreementInfo/PremiseTypeEdit.cshtml";

            public string Create = "~/Views/AgreementInfo/Create.cshtml";
            public string ReCreate = "~/Views/AgreementInfo/ReCreate.cshtml";
            public string ModCreate = "~/Views/AgreementInfo/ModCreate.cshtml";

            public string CreateIndex = "~/Views/AgreementInfo/CreateIndex.cshtml";
            public string ReCreateIndex = "~/Views/AgreementInfo/ReCreateIndex.cshtml";
            public string ModCreateIndex = "~/Views/AgreementInfo/ModCreateIndex.cshtml";

            public string BlockedAgreementReport = "~/Views/AgreementInfo/BlockedAgreementReport.cshtml";
            public string BlockedVendorReport = "~/Views/AgreementInfo/BlockedVendorReport.cshtml";

            public string CreateCopyProfile = "~/Views/AgreementInfo/CreateCopyProfile.cshtml";
            public string Edit = "~/Views/AgreementInfo/Edit.cshtml";
            public string DraftIndex = "~/Views/AgreementInfo/DraftIndex.cshtml";
            public string DraftEdit = "~/Views/AgreementInfo/DraftEdit.cshtml";
            public string ReEdit = "~/Views/AgreementInfo/ReEdit.cshtml";
            public string RenewalCreate = "~/Views/AgreementInfo/RenewalCreate.cshtml";
            public string ReDraftEdit = "~/Views/AgreementInfo/ReDraftEdit.cshtml";
            public string ModEdit = "~/Views/AgreementInfo/ModEdit.cshtml";
            public string ModifiedCreate = "~/Views/AgreementInfo/ModifiedCreate.cshtml";
            public string ModDraftEdit = "~/Views/AgreementInfo/ModDraftEdit.cshtml";

            public string AgreementDetailsCreate = "~/Views/AgreementInfo/AgreementDetailsCreate.cshtml";
            public string ReAgreementDetailsCreate = "~/Views/AgreementInfo/ReAgreementDetailsCreate.cshtml";
            public string ModAgreementDetailsCreate = "~/Views/AgreementInfo/ModAgreementDetailsCreate.cshtml";

            public string AgreementDetailsDelete = "~/Views/AgreementInfo/AgreementDetailsDelete.cshtml";
            public string ReAgreementDetailsDelete = "~/Views/AgreementInfo/ReAgreementDetailsDelete.cshtml";
            public string ModAgreementDetailsDelete = "~/Views/AgreementInfo/ModAgreementDetailsDelete.cshtml";

            public string AgreementDetailsActivate = "~/Views/AgreementInfo/AgreementDetailsActivate.cshtml";
            public string ReAgreementDetailsActivate = "~/Views/AgreementInfo/ReAgreementDetailsActivate.cshtml";
            public string ModAgreementDetailsActivate = "~/Views/AgreementInfo/ModAgreementDetailsActivate.cshtml";

            public string AgreementDetailsBlock = "~/Views/AgreementInfo/AgreementDetailsBlock.cshtml";
            public string ReAgreementDetailsBlock = "~/Views/AgreementInfo/ReAgreementDetailsBlock.cshtml";
            public string ModAgreementDetailsBlock = "~/Views/AgreementInfo/ModAgreementDetailsBlock.cshtml";

            public string AgreementDetailsUnblock = "~/Views/AgreementInfo/AgreementDetailsUnblock.cshtml";
            public string ReAgreementDetailsUnblock = "~/Views/AgreementInfo/ReAgreementDetailsUnblock.cshtml";
            public string ModAgreementDetailsUnblock = "~/Views/AgreementInfo/ModAgreementDetailsUnblock.cshtml";

            public string AgreementDetails = "~/Views/AgreementInfo/AgreementDetails.cshtml";
            public string ReAgreementDetails = "~/Views/AgreementInfo/ReAgreementDetails.cshtml";
            public string ModAgreementDetails = "~/Views/AgreementInfo/ModAgreementDetails.cshtml";

            public string EditIndex = "~/Views/AgreementInfo/EditIndex.cshtml";
            public string ReEditIndex = "~/Views/AgreementInfo/ReEditIndex.cshtml";
            public string ModEditIndex = "~/Views/AgreementInfo/ModEditIndex.cshtml";

            public string DeleteIndex = "~/Views/AgreementInfo/DeleteIndex.cshtml";
            public string ReDeleteIndex = "~/Views/AgreementInfo/ReDeleteIndex.cshtml";
            public string ModDeleteIndex = "~/Views/AgreementInfo/ModDeleteIndex.cshtml";

            public string ActivateIndex = "~/Views/AgreementInfo/ActivateIndex.cshtml";
            public string ReActivateIndex = "~/Views/AgreementInfo/ReActivateIndex.cshtml";
            public string ModActivateIndex = "~/Views/AgreementInfo/ModActivateIndex.cshtml";

            public string Block = "~/Views/AgreementInfo/Block.cshtml";
            public string ReBlock = "~/Views/AgreementInfo/ReBlock.cshtml";
            public string ModBlock = "~/Views/AgreementInfo/ModBlock.cshtml";

            public string BlockIndex = "~/Views/AgreementInfo/BlockIndex.cshtml";
            public string ReBlockIndex = "~/Views/AgreementInfo/ReBlockIndex.cshtml";
            public string ModBlockIndex = "~/Views/AgreementInfo/ModBlockIndex.cshtml";

            public string UnblockIndex = "~/Views/AgreementInfo/UnblockIndex.cshtml";
            public string ReUnblockIndex = "~/Views/AgreementInfo/ReUnblockIndex.cshtml";
            public string ModUnblockIndex = "~/Views/AgreementInfo/ModUnblockIndex.cshtml";

            public string Unblock = "~/Views/AgreementInfo/Unblock.cshtml";
            public string ReUnblock = "~/Views/AgreementInfo/ReUnblock.cshtml";
            public string ModUnblock = "~/Views/AgreementInfo/ModUnblock.cshtml";

            public string ListOfAgreements = "~/Views/AgreementInfo/ListOfAgreements.cshtml";
            public string ReListOfAgreements = "~/Views/AgreementInfo/ReListOfAgreements.cshtml";
            public string ModListOfAgreements = "~/Views/AgreementInfo/ModListOfAgreements.cshtml";

            public string AllAgreementDetails = "~/Views/AgreementInfo/AllAgreementDetails.cshtml";
            public string ListOfRentSchedule = "~/Views/AgreementInfo/ListOfRentSchedule.cshtml";
            public string ReListOfRentSchedule = "~/Views/AgreementInfo/ReListOfRentSchedule.cshtml";
            public string LatestAgreementList = "~/Views/AgreementInfo/LatestAgreementList.cshtml";            
            public string ModListOfRentSchedule = "~/Views/AgreementInfo/ModListOfRentSchedule.cshtml";
            public string PVLeaseList = "~/Views/AgreementInfo/PVLeaseList.cshtml";

            public string AgreementRentSchedule = "~/Views/AgreementInfo/AgreementRentSchedule.cshtml";
            public string ReAgreementRentSchedule = "~/Views/AgreementInfo/ReAgreementRentSchedule.cshtml";
            public string ModAgreementRentSchedule = "~/Views/AgreementInfo/ModAgreementRentSchedule.cshtml";

            public string RentForecast_AgreementRentSchedule = "~/Views/AgreementInfo/RentForecast_AgreementRentSchedule.cshtml";

            public string HoldAgreementRentSchedule = "~/Views/AgreementInfo/HoldAgreementRentSchedule.cshtml";

            public string LandlordRentSchedule = "~/Views/AgreementInfo/LandlordRentSchedule.cshtml";
            public string HoldLandlordRentSchedule = "~/Views/AgreementInfo/HoldLandlordRentSchedule.cshtml";
            public string ReLandlordRentSchedule = "~/Views/AgreementInfo/ReLandlordRentSchedule.cshtml";
            public string ModLandlordRentSchedule = "~/Views/AgreementInfo/ModLandlordRentSchedule.cshtml";

            public string CostCenterRentSchedule = "~/Views/AgreementInfo/CostCenterRentSchedule.cshtml";
            public string ReCostCenterRentSchedule = "~/Views/AgreementInfo/ReCostCenterRentSchedule.cshtml";
            public string ModCostCenterRentSchedule = "~/Views/AgreementInfo/ModCostCenterRentSchedule.cshtml";

            public string UtilityRentSchedule = "~/Views/AgreementInfo/UtilityRentSchedule.cshtml";
            public string HoldUtilityRentSchedule = "~/Views/AgreementInfo/HoldUtilityRentSchedule.cshtml";
            public string ReUtilityRentSchedule = "~/Views/AgreementInfo/ReUtilityRentSchedule.cshtml";
            public string ModUtilityRentSchedule = "~/Views/AgreementInfo/ModUtilityRentSchedule.cshtml";

            public string IFRSLeaseSchedule = "~/Views/AgreementInfo/IFRSLeaseSchedule.cshtml";
            public string ReIFRSLeaseSchedule = "~/Views/AgreementInfo/ReIFRSLeaseSchedule.cshtml";
            public string ModIFRSLeaseSchedule = "~/Views/AgreementInfo/ModIFRSLeaseSchedule.cshtml";

            public string RentAPExecuteLog = "~/Views/AgreementInfo/RentAPExecuteLog.cshtml";
            public string RentVendorPJExecuteLog = "~/Views/AgreementInfo/RentVendorPJExecuteLog.cshtml";
            public string UtilityVendorPJExecuteLog = "~/Views/AgreementInfo/UtilityVendorPJExecuteLog.cshtml";
            public string UtilityAPExecuteLog = "~/Views/AgreementInfo/UtilityAPExecuteLog.cshtml";

            public string HoldBlockPayment = "~/Views/AgreementInfo/HoldBlockPayment.cshtml";
            public string HoldUnblockPayment = "~/Views/AgreementInfo/HoldUnblockPayment.cshtml";

            public string RentAPPostLog = "~/Views/AgreementInfo/RentAPPostLog.cshtml";
            public string RentVendorPJPostLog = "~/Views/AgreementInfo/RentVendorPJPostLog.cshtml";
            public string UtilityVendorPJPostLog = "~/Views/AgreementInfo/UtilityVendorPJPostLog.cshtml";
            public string UtilityAPPostLog = "~/Views/AgreementInfo/UtilityAPPostLog.cshtml";
            public string RentAPLogDetails = "~/Views/AgreementInfo/RentAPLogDetails.cshtml";
            public string RentVendorPJLogDetails = "~/Views/AgreementInfo/RentVendorPJLogDetails.cshtml";
            public string UtilityVendorPJLogDetails = "~/Views/AgreementInfo/UtilityVendorPJLogDetails.cshtml";
            public string UtilityAPLogDetails = "~/Views/AgreementInfo/UtilityAPLogDetails.cshtml";
            public string RentAPJournalReport = "~/Views/AgreementInfo/RentAPJournalReport.cshtml";
            public string RentVendorPJInfoReport = "~/Views/AgreementInfo/RentVendorPJInfoReport.cshtml";
            public string RentTemplateReport = "~/Views/AgreementInfo/RentTemplateReport.cshtml";
            public string UtilityVendorPJInfoReport = "~/Views/AgreementInfo/UtilityVendorPJInfoReport.cshtml";
            public string RentGovtPJInfoReport = "~/Views/AgreementInfo/RentGovtPJInfoReport.cshtml";
            public string UtilityGovtPJInfoReport = "~/Views/AgreementInfo/UtilityGovtPJInfoReport.cshtml";
            public string UtilityAPJournalReport = "~/Views/AgreementInfo/UtilityAPJournalReport.cshtml";
            public string RentAPJournalDetails = "~/Views/AgreementInfo/RentAPJournalDetails.cshtml";
            public string PreviewRentAPJournalDetails = "~/Views/AgreementInfo/PreviewRentAPJournalDetails.cshtml";
            public string RentVendorPJInfoDetails = "~/Views/AgreementInfo/RentVendorPJInfoDetails.cshtml";
            public string PreviewRentVendorPJInfoDetails = "~/Views/AgreementInfo/PreviewRentVendorPJInfoDetails.cshtml";
            public string UtilityVendorPJInfoDetails = "~/Views/AgreementInfo/UtilityVendorPJInfoDetails.cshtml";
            public string RentGovtPJInfoDetails = "~/Views/AgreementInfo/RentGovtPJInfoDetails.cshtml";
            public string PreviewRentGovtPJInfoDetails = "~/Views/AgreementInfo/PreviewRentGovtPJInfoDetails.cshtml";
            public string UtilityGovtPJInfoDetails = "~/Views/AgreementInfo/UtilityGovtPJInfoDetails.cshtml";
            public string UtilityAPJournalDetails = "~/Views/AgreementInfo/UtilityAPJournalDetails.cshtml";
            public string RentForecast = "~/Views/AgreementInfo/RentForecast.cshtml";
            public string RentForecastCCReport = "~/Views/AgreementInfo/RentForecastCCReport.cshtml";
            public string RentAPReport = "~/Views/AgreementInfo/RentAPReport.cshtml";
            public string RentVendorPJReport = "~/Views/AgreementInfo/RentVendorPJReport.cshtml";
            public string RentTemplate = "~/Views/AgreementInfo/RentTemplate.cshtml";
            public string UtilityVendorPJReport = "~/Views/AgreementInfo/UtilityVendorPJReport.cshtml";
            public string RentGovtPJReport = "~/Views/AgreementInfo/RentGovtPJReport.cshtml";
            public string UtilityGovtPJReport = "~/Views/AgreementInfo/UtilityGovtPJReport.cshtml";
            public string UtilityAPReport = "~/Views/AgreementInfo/UtilityAPReport.cshtml";
            public string RentJournalReport = "~/Views/AgreementInfo/RentJournalReport.cshtml";
            public string BorrowingRate = "~/Views/AgreementInfo/BorrowingRate.cshtml";
            public string RentHoldPayment = "~/Views/AgreementInfo/RentHoldPayment.cshtml";
            public string UtilityHoldPayment = "~/Views/AgreementInfo/UtilityHoldPayment.cshtml";
            public string LeaseInfo = "~/Views/AgreementInfo/LeaseInfo.cshtml";
            public string LeaseInfoReport = "~/Views/AgreementInfo/LeaseInfoReport.cshtml";

            public string IFRSControlData = "~/Views/AgreementInfo/IFRSControlData.cshtml";
            public string CalculatedSummary = "~/Views/AgreementInfo/CalculatedSummary.cshtml";
            public string CalculatedSummaryReport = "~/Views/AgreementInfo/CalculatedSummaryReport.cshtml";
            public string NewSummary = "~/Views/AgreementInfo/NewSummary.cshtml";
            public string NewSummaryReport = "~/Views/AgreementInfo/NewSummaryReport.cshtml";
            public string JournalEntries = "~/Views/AgreementInfo/JournalEntries.cshtml";
            public string JournalEntriesReport = "~/Views/AgreementInfo/JournalEntriesReport.cshtml";
            public string ModSummary = "~/Views/AgreementInfo/ModSummary.cshtml";
            public string ModSummaryReport = "~/Views/AgreementInfo/ModSummaryReport.cshtml";
            public string BlockedSummary = "~/Views/AgreementInfo/BlockedSummary.cshtml";
            public string BlockedSummaryReport = "~/Views/AgreementInfo/BlockedSummaryReport.cshtml";
        }
    }
}