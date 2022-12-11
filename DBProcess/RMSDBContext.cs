using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace RMS.DBProcess
{
    public class RMSDBContext : DbContext
    {
        public RMSDBContext() : base("name=RMSDBContext")
        {
            //Database.SetInitializer<AccountingContext>(new AccountingDBInitializer());
            Database.SetInitializer<RMSDBContext>(null);
            base.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<RMS.Models.PreviewRentVendorPJInfo> PreviewRentVendorPJInfos { get; set; }
        public DbSet<RMS.Models.PreviewRentGovtPJInfo> PreviewRentGovtPJInfos { get; set; }
        public DbSet<RMS.Models.PreviewRentAPJournalInfo> PreviewRentAPJournalInfos { get; set; }
        public DbSet<RMS.Models.SpaceInfo> SpaceInfos { get; set; }
        public DbSet<RMS.Models.Lookup> Lookups { get; set; }
        public DbSet<RMS.Models.EmailAccount> EmailAccounts { get; set; }
        public DbSet<RMS.Models.HOCCSOLInfo> HOCCSOLInfos { get; set; }
        public DbSet<RMS.Models.UserInfo> UserInfos { get; set; }
        public DbSet<RMS.Models.UserPermission> UserPermissions { get; set; }
        public DbSet<RMS.Models.StatusInfo> StatusInfos { get; set; }
        public DbSet<RMS.Models.PremiseTypeInfo> PremiseTypeInfos { get; set; }
        public DbSet<RMS.Models.AgreementInfo> AgreementInfos { get; set; }
        public DbSet<RMS.Models.AdvanceInfo> AdvanceInfos { get; set; }
        public DbSet<RMS.Models.ReviewInfo> ReviewInfos { get; set; }
        public DbSet<RMS.Models.LandlordInfo> LandlordInfos { get; set; }
        public DbSet<RMS.Models.CostCenterInfo> CostCenterInfos { get; set; }
        public DbSet<RMS.Models.UtilityInfo> UtilityInfos { get; set; }
        public DbSet<RMS.Models.ContractSchedule> ContractSchedules { get; set; }
        public DbSet<RMS.Models.LandlordSchedule> LandlordSchedules { get; set; }
        public DbSet<RMS.Models.CostCenterSchedule> CostCenterSchedules { get; set; }
        public DbSet<RMS.Models.UtilitySchedule> UtilitySchedules { get; set; }
        public DbSet<RMS.Models.RentAPExecuteLog> RentAPExecuteLogs { get; set; }
        public DbSet<RMS.Models.RentVendorPJExecuteLog> RentVendorPJExecuteLogs { get; set; }
        public DbSet<RMS.Models.UtilityVendorPJExecuteLog> UtilityVendorPJExecuteLogs { get; set; }
        public DbSet<RMS.Models.UtilityAPExecuteLog> UtilityAPExecuteLogs { get; set; }
        public DbSet<RMS.Models.RentAPJournalInfo> RentAPJournalInfos { get; set; }
        public DbSet<RMS.Models.RentVendorPJInfo> RentVendorPJInfos { get; set; }
        public DbSet<RMS.Models.UtilityVendorPJInfo> UtilityVendorPJInfos { get; set; }
        public DbSet<RMS.Models.RentGovtPJInfo> RentGovtPJInfos { get; set; }
        public DbSet<RMS.Models.UtilityGovtPJInfo> UtilityGovtPJInfos { get; set; }
        public DbSet<RMS.Models.UtilityAPJournalInfo> UtilityAPJournalInfos { get; set; }
        public DbSet<RMS.Models.LogRegister> LogRegisters { get; set; }
        public DbSet<RMS.Models.BorrowingRateDetails> BorrowingRateDetails { get; set; }
        public DbSet<RMS.Models.IFRSSchedule> IFRSSchedules { get; set; }
        public DbSet<RMS.Models.FileUploadInfo> FileUploadInfos { get; set; }

        public DbSet<RMS.Models.DraftSpaceInfo> DraftSpaceInfos { get; set; }
        public DbSet<RMS.Models.DraftAgreementInfo> DraftAgreementInfos { get; set; }
        public DbSet<RMS.Models.DraftAdvanceInfo> DraftAdvanceInfos { get; set; }
        public DbSet<RMS.Models.DraftReviewInfo> DraftReviewInfos { get; set; }
        public DbSet<RMS.Models.DraftLandlordInfo> DraftLandlordInfos { get; set; }
        public DbSet<RMS.Models.DraftCostCenterInfo> DraftCostCenterInfos { get; set; }
        public DbSet<RMS.Models.DraftUtilityInfo> DraftUtilityInfos { get; set; }

        public DbSet<RMS.Models.DM_AgreementInfo> DM_AgreementInfos { get; set; }
        public DbSet<RMS.Models.DM_SpaceInfo> DM_SpaceInfos { get; set; }
        public DbSet<RMS.Models.DM_AdvanceInfo> DM_AdvanceInfos { get; set; }
        public DbSet<RMS.Models.DM_ReviewInfo> DM_ReviewInfos  { get; set; }
        public DbSet<RMS.Models.DM_LandlordInfo> DM_LandlordInfos { get; set; }
        public DbSet<RMS.Models.DM_CostCenterInfo> DM_CostCenterInfos { get; set; }
        public DbSet<RMS.Models.DM_UtilityInfo> DM_UtilityInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}