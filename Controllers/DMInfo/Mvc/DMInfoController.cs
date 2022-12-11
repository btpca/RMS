using Excel;
using RMS.DBProcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static RMS.DBProcess.ViewPath;

namespace RMS.Controllers.DMInfo.Mvc
{
    public class DMInfoController : Controller
    {
        private readonly RMSDBContext db = new RMSDBContext();
        private readonly HomePath HomePath = new HomePath();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                DMInfoPath DMInfoPath = new DMInfoPath();
                return View(DMInfoPath.UploadDMInfo);
            }
            catch (Exception Ex)
            {
                ViewBag.Message = Ex.ToString();
                return View(HomePath.DisplayMessage);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UploadData(HttpPostedFileBase file)
        {
            HomePath HomePath = new HomePath();
            try
            {
                if (file != null && file.FileName != "" && file.ContentLength > 0)
                {
                    DataTable dt_AgreementInfo = null;
                    DataTable dt_SpaceInfo = null;
                    DataTable dt_AdvanceInfo = null;
                    DataTable dt_ReviewInfo = null;
                    DataTable dt_LandlordInfo = null;
                    DataTable dt_CostCenterInfo = null;
                    DataTable dt_UtilityInfo = null;
                    int TotalRows_AgreementInfo = 0;
                    int TotalRows_SpaceInfo = 0;
                    int TotalRows_AdvanceInfo = 0;
                    int TotalRows_ReviewInfo = 0;
                    int TotalRows_LandlordInfo = 0;
                    int TotalRows_CostCenterInfo = 0;
                    int TotalRows_UtilityInfo = 0;
                    //==Read Excel File all sheets
                    string fileName = Path.GetFileName(file.FileName);
                    string fileContentType = file.ContentType;
                    Stream stream = file.InputStream;
                    IExcelDataReader readerExcel = null;
                    if (fileName.ToLower().EndsWith(".xls"))
                    {
                        readerExcel = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (fileName.ToLower().EndsWith(".xlsx"))
                    {
                        readerExcel = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //return dt;
                    }
                    readerExcel.IsFirstRowAsColumnNames = true;
                    DataSet ds = readerExcel.AsDataSet();
                    dt_AgreementInfo = ds.Tables[0];
                    dt_SpaceInfo = ds.Tables[1];
                    dt_AdvanceInfo = ds.Tables[2];
                    dt_ReviewInfo = ds.Tables[3];
                    dt_LandlordInfo = ds.Tables[4];
                    dt_CostCenterInfo = ds.Tables[5];
                    dt_UtilityInfo = ds.Tables[6];
                    readerExcel.Close();
                    //==DM_AgreementInfo
                    RMS.Models.DM_AgreementInfo AI = new RMS.Models.DM_AgreementInfo();
                    List<RMS.Models.DM_AgreementInfo> lstAI = new List<RMS.Models.DM_AgreementInfo>();
                    int RowNo = 0;
                    if (dt_AgreementInfo != null)
                    {
                        foreach (DataRow dr in dt_AgreementInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            //if (RowNo == 350)
                            //{ var a = RowNo; }
                            //if (RowNo == 400)
                            //{ var a = RowNo; }
                            //if (RowNo == 410)
                            //{ var a = RowNo; }
                            //if (RowNo == 420)
                            //{ var a = RowNo; }
                            //if (RowNo == 430)
                            //{ var a = RowNo; }
                            //if (RowNo == 440)
                            //{ var a = RowNo; }
                            //if (RowNo == 450)
                            //{ var a = RowNo; }
                            //if (RowNo == 450)
                            //{ var a = RowNo; }
                            //if (RowNo == 500)
                            //{ var a = RowNo; }
                            //if (RowNo == 550)
                            //{ var a = RowNo; }
                            int colCount = dt_AgreementInfo.Columns.Count;
                            AI = new RMS.Models.DM_AgreementInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "AgreementInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //==AgreementName
                                else if (i == 1)
                                {
                                    AI.AgreementName = colValue;
                                }
                                //==PremiseType
                                else if (i == 2)
                                {
                                    AI.PremiseType = colValue;
                                }
                                //==PremiseName
                                else if (i == 3)
                                {
                                    AI.PremiseName = colValue;
                                }
                                //==PremiseAddress
                                else if (i == 4)
                                {
                                    AI.PremiseAddress = colValue;
                                }
                                //==AgreementStartDate
                                else if (i == 5)
                                {
                                    AI.AgreementStartDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //==AgreementEndDate
                                else if (i == 6)
                                {
                                    AI.AgreementEndDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //==AgreementPeriod
                                else if (i == 7)
                                {
                                    AI.AgreementPeriod = 1 + (AI.AgreementEndDate.Year - AI.AgreementStartDate.Year) * 12 + AI.AgreementEndDate.Month - AI.AgreementStartDate.Month;
                                }
                                //==PostedMonths
                                else if (i == 8)
                                {
                                    AI.PostedMonths = Convert.ToInt32(colValue.ToString());
                                }
                                //==UOM
                                else if (i == 9)
                                {
                                    AI.UOM = colValue;
                                }
                                //==TotalArea
                                else if (i == 10)
                                {
                                    AI.TotalArea = Convert.ToDouble(colValue.ToString());
                                }
                                //==CostPerUnit
                                else if (i == 11)
                                {
                                    AI.CostPerUnit = Convert.ToDouble(colValue.ToString());
                                }
                                //==TotalRentAmount
                                else if (i == 12)
                                {
                                    AI.TotalRentAmount = Convert.ToDouble(colValue.ToString());
                                }
                                //==RentDueDay
                                else if (i == 13)
                                {
                                    AI.RentDueDay = Convert.ToInt32(colValue.ToString());
                                }
                                //==SecurityDepositAmount
                                else if (i == 14)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.SecurityDepositAmount = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.SecurityDepositAmount = 0;
                                    }
                                }
                                //==AdvanceAmount
                                else if (i == 15)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.AdvanceAmount = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.AdvanceAmount = 0;
                                    }
                                }
                                //==Tax%
                                else if (i == 16)
                                {
                                    AI.TaxPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==VAT%
                                else if (i == 17)
                                {
                                    AI.VATPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==TaxType
                                else if (i == 18)
                                {
                                    if (colValue == "N/A")
                                    {
                                        AI.TaxType = "Inclusive";
                                    }
                                    else
                                    {
                                        AI.TaxType = colValue;
                                    }
                                }
                                //==VatType
                                else if (i == 19)
                                {
                                    if (colValue == "N/A")
                                    {
                                        AI.VATType = "Inclusive";
                                    }
                                    else
                                    {
                                        AI.VATType = colValue;
                                    }
                                }
                                //==ReviewFrequency
                                else if (i == 20)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.ReviewFrequency = Convert.ToInt32(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.ReviewFrequency = 0;
                                    }
                                }
                                //==Enhancement%
                                else if (i == 21)
                                {
                                    AI.ReviewPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==AdvanceGLCode
                                else if (i == 22)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.AdvanceGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.AdvanceGLCode = "NA";
                                    }
                                }
                                //==AdvanceAdjustmentGLCode
                                else if (i == 23)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.AdvanceAdjustmentGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.AdvanceAdjustmentGLCode = "NA";
                                    }
                                }
                                //==CashGLCode
                                else if (i == 24)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.CashGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.CashGLCode = "NA";
                                    }
                                }
                                //==BankGLCode
                                else if (i == 25)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.BankGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.BankGLCode = "NA";
                                    }
                                }
                                //==RentGLCode
                                else if (i == 26)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.RentGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.RentGLCode = "NA";
                                    }
                                }
                                //==UtilityGLCode
                                else if (i == 27)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.UtilityGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.UtilityGLCode = "NA";
                                    }
                                }
                                //==TaxGLCode
                                else if (i == 28)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.TaxGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.TaxGLCode = "NA";
                                    }
                                }
                                //==VATGLCode
                                else if (i == 29)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.VATGLCode = colValue;
                                    }
                                    else
                                    {
                                        AI.VATGLCode = "NA";
                                    }
                                }
                                //==ServiceCharge
                                else if (i == 30)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.ServiceCharge = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.ServiceCharge = Convert.ToDouble(colValue.ToString());
                                    }
                                }
                                //==OnlineTower
                                else if (i == 31)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.OnlineTower = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.OnlineTower = 0;
                                    }
                                }
                                //==GeneratorSpace
                                else if (i == 32)
                                {
                                    if (colValue != "-")
                                    {
                                        AI.GeneratorSpace = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.GeneratorSpace = 0;
                                    }
                                }
                                //==CarParking
                                else if (i == 33)
                                {

                                    if (colValue != "-")
                                    {
                                        AI.CarParking = Convert.ToDouble(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.CarParking = 0;
                                    }
                                }
                                //==Premise Address Bangla
                                else if (i == 34)
                                {
                                    AI.PremiseAddressBangla = colValue;
                                }
                                //==Area Status
                                else if (i == 35)
                                {
                                    AI.AreaStatus = colValue;
                                }
                                //==Regional Office
                                else if (i == 36)
                                {
                                    AI.RegionalOffice = colValue;
                                }
                                //==Primary SOL
                                else if (i == 37)
                                {
                                    AI.PrimarySOL = colValue;
                                }
                                //==Attached Control
                                else if (i == 38)
                                {
                                    AI.AttachedControl = colValue;
                                }
                                //==Controller Office Distance
                                else if (i == 39)
                                {
                                    AI.ControllerOfficeDistance = colValue;
                                }
                                //==Routing Number
                                else if (i == 40)
                                {
                                    AI.RoutingNumber = colValue;
                                }
                                //==Division
                                else if (i == 41)
                                {
                                    AI.Division = colValue;
                                }
                                //==District
                                else if (i == 42)
                                {
                                    AI.District = colValue;
                                }
                                //==Upazila
                                else if (i == 43)
                                {
                                    AI.Upazila = colValue;
                                }
                                //==Thana
                                else if (i == 44)
                                {
                                    AI.Thana = colValue;
                                }
                                //==Thana Code
                                else if (i == 45)
                                {
                                    AI.ThanaCode = colValue;
                                }
                                //==Pourasabha
                                else if (i == 46)
                                {
                                    AI.Pourasabha = colValue;
                                }
                                //==Pourasabha Type
                                else if (i == 47)
                                {
                                    AI.PourasabhaType = colValue;
                                }
                                //==Union Name
                                else if (i == 48)
                                {
                                    AI.UnionName = colValue;
                                }
                                //==Ward No
                                else if (i == 49)
                                {
                                    AI.WardNo = colValue;
                                }
                                //==Premises Type for Accounts
                                else if (i == 50)
                                {
                                    AI.PremisesTypeforAccounts = colValue;
                                }
                                //Parent Agreement Code
                                else if (i == 51)
                                {
                                    AI.ParentAgreementCode = colValue;
                                }
                                //Electricity Load
                                else if (i == 52)
                                {
                                    AI.ElectricityLoad = colValue;
                                }
                                //Electricity Provided By
                                else if (i == 53)
                                {
                                    AI.ElectricityProvidedBy = colValue;
                                }
                                //AIT Bourne By
                                else if (i == 54)
                                {
                                    AI.AITBourneBy = colValue;
                                }
                                //Commercial Permission
                                else if (i == 55)
                                {
                                    AI.CommercialPermission = colValue;
                                }
                                //Building Plan
                                else if (i == 56)
                                {
                                    AI.BuildingPlan = colValue;
                                }
                                //Premises Situated Floor
                                else if (i == 57)
                                {
                                    AI.PremisesSituatedFloor = colValue;
                                }
                                //Bangladesh Bank Approval
                                else if (i == 58)
                                {
                                    AI.BangladeshBankApproval = colValue;
                                }
                                //Bangladesh Bank Reference
                                else if (i == 59)
                                {
                                    AI.BangladeshBankReference = colValue;
                                }
                                //IT Tower Rent Clause
                                else if (i == 60)
                                {
                                    AI.ITTowerRentClause = colValue;
                                }
                                //Termination Clause
                                else if (i == 61)
                                {
                                    AI.TerminationClause = colValue;
                                }
                                //Termination Notice Period
                                else if (i == 62)
                                {
                                    AI.TerminationNoticePeriod = Convert.ToInt32(colValue.ToString());
                                }
                                //Premises Opening Date
                                else if (i == 63)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.PremisesOpeningDate = Convert.ToDateTime(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.PremisesOpeningDate = null;
                                    }
                                }
                                //Remarks
                                else if (i == 64)
                                {
                                    AI.AgreementRemarks = colValue;
                                }
                                //Document Date
                                else if (i == 65)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.DocumentDate = Convert.ToDateTime(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.DocumentDate = null;
                                    }
                                }
                                //Borrowing Rate%
                                else if (i == 66)
                                {
                                    AI.BorrowingRate = Convert.ToDouble(colValue.ToString());
                                }
                                //Payment Method
                                else if (i == 67)
                                {
                                    AI.PaymentMethod = colValue;
                                }
                                //IFRS Impact
                                else if (i == 68)
                                {
                                    if (colValue == "Yes" || colValue == "YES")
                                    {
                                        AI.IsIFRSEnable = true;
                                    }
                                    else
                                    {
                                        AI.IsIFRSEnable = false;
                                    }
                                }
                                //Calculation Method
                                else if (i == 69)
                                {
                                    AI.CalculationMethod = colValue;
                                }
                                //WithHolding Code
                                else if (i == 70)
                                {
                                    AI.WithHoldingCode = colValue;
                                }
                                //Additional Expense
                                else if (i == 71)
                                {
                                    AI.AdditionalExpense = Convert.ToDouble(colValue.ToString());
                                }
                                //Initial Direct Cost
                                else if (i == 72)
                                {
                                    AI.InitialDirectCost = Convert.ToDouble(colValue.ToString());
                                }
                                //Dismantling Cost
                                else if (i == 73)
                                {
                                    AI.DismantlingCost = Convert.ToDouble(colValue.ToString());
                                }
                                //Car Parking No
                                else if (i == 74)
                                {
                                    AI.CarParkingNo = colValue;
                                }
                                //Provision GL Tax
                                else if (i == 75)
                                {
                                    AI.ProvisionGLTax = colValue;
                                }
                                //Provision GL AP
                                else if (i == 76)
                                {
                                    AI.ProvisionGLAP = colValue;
                                }
                                //RTGS GL
                                else if (i == 77)
                                {
                                    AI.RTGSGL = colValue;
                                }
                                //EFTN GL
                                else if (i == 78)
                                {
                                    AI.EFTNGL = colValue;
                                }
                                //Pay Order GL
                                else if (i == 79)
                                {
                                    AI.PayOrderGL = colValue;
                                }
                                //IBB Payment GL
                                else if (i == 80)
                                {
                                    AI.IBBPaymentGL = colValue;
                                }
                                //City Brokerage GL
                                else if (i == 81)
                                {
                                    AI.CityBrokerageGL = colValue;
                                }
                                //City Capital GL
                                else if (i == 82)
                                {
                                    AI.CityCapitalGL = colValue;
                                }
                                //Others GL
                                else if (i == 83)
                                {
                                    AI.OthersGL = colValue;
                                }
                                //Water Bill Type
                                else if (i == 84)
                                {
                                    AI.WaterBillType = colValue;
                                }
                                //Water Bill Amount
                                else if (i == 85)
                                {
                                    AI.WaterBillAmount = Convert.ToDouble(colValue.ToString());
                                }
                                //IFRS Effective Date
                                else if (i == 86)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AI.IFRSEffectiveDate = Convert.ToDateTime(colValue.ToString());
                                    }
                                    else
                                    {
                                        AI.IFRSEffectiveDate = null;
                                    }
                                }
                                //Corporate Tax Rate
                                else if (i == 87)
                                {
                                    AI.CorporateTaxRate = Convert.ToDouble(colValue.ToString());
                                }
                                //==End
                            }
                            lstAI.Add(AI);
                        }
                        db.DM_AgreementInfos.AddRange(lstAI);
                        db.SaveChanges();
                        TotalRows_AgreementInfo = RowNo;
                    }
                    //==DM_SpaceInfo
                    RMS.Models.DM_SpaceInfo SP = new RMS.Models.DM_SpaceInfo();
                    List<RMS.Models.DM_SpaceInfo> lstSP = new List<RMS.Models.DM_SpaceInfo>();
                    RowNo = 0;
                    if (dt_SpaceInfo != null)
                    {
                        foreach (DataRow dr in dt_SpaceInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_SpaceInfo.Columns.Count;
                            SP = new RMS.Models.DM_SpaceInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        SP.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "SpaceInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //Sub Premises Type
                                else if (i == 1)
                                {
                                    SP.SpaceType = colValue;
                                }
                                //Space Area
                                else if (i == 2)
                                {
                                    SP.SpaceArea = Convert.ToDouble(colValue.ToString());
                                }
                                //Space Rate
                                else if (i == 3)
                                {
                                    SP.SpaceRate = Convert.ToDouble(colValue.ToString());
                                }
                                //Space Rent
                                else if (i == 4)
                                {
                                    SP.SpaceRent = Convert.ToDouble(colValue.ToString());
                                }
                                //Space Total Advance
                                else if (i == 5)
                                {
                                    SP.SpaceTotalAdvance = Convert.ToDouble(colValue.ToString());
                                }
                                //Space Total Adjustment
                                else if (i == 6)
                                {
                                    SP.SpaceTotalAdjustment = Convert.ToDouble(colValue.ToString());
                                }
                                //Remarks
                                else if (i == 7)
                                {
                                    SP.SpaceRemarks = colValue;
                                }
                            }
                            lstSP.Add(SP);
                        }
                        db.DM_SpaceInfos.AddRange(lstSP);
                        db.SaveChanges();
                        TotalRows_SpaceInfo = RowNo;
                    }
                    //==DM_AdvanceInfo
                    RMS.Models.DM_AdvanceInfo AD = new RMS.Models.DM_AdvanceInfo();
                    List<RMS.Models.DM_AdvanceInfo> lstAD = new List<RMS.Models.DM_AdvanceInfo>();
                    RowNo = 0;
                    if (dt_AdvanceInfo != null)
                    {
                        foreach (DataRow dr in dt_AdvanceInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_AdvanceInfo.Columns.Count;
                            AD = new RMS.Models.DM_AdvanceInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        AD.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "SpaceInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //Advance Adjustment No
                                else if (i == 1)
                                {
                                    AD.AdvanceNo = Convert.ToInt32(colValue.ToString());
                                }
                                //Advance Start Date
                                else if (i == 2)
                                {
                                    AD.StartDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //Advance End Date
                                else if (i == 3)
                                {
                                    AD.EndDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //Advance Period
                                else if (i == 4)
                                {
                                    AD.AdvanceSlotPeriod = 1 + (AD.EndDate.Year - AD.StartDate.Year) * 12 + AD.EndDate.Month - AD.StartDate.Month;
                                }
                                //Advance Adjustment Amount
                                else if (i == 5)
                                {
                                    AD.AdvanceSlotAmount = Convert.ToDouble(colValue.ToString());
                                }
                                //Remarks
                                else if (i == 6)
                                {
                                    AD.AdvanceNote = colValue;
                                }
                            }
                            lstAD.Add(AD);
                        }
                        db.DM_AdvanceInfos.AddRange(lstAD);
                        db.SaveChanges();
                        TotalRows_AdvanceInfo = RowNo;
                    }
                    //==DM_ReviewInfo
                    RMS.Models.DM_ReviewInfo RV = new RMS.Models.DM_ReviewInfo();
                    List<RMS.Models.DM_ReviewInfo> lstReview = new List<RMS.Models.DM_ReviewInfo>();
                    RowNo = 0;
                    if (dt_ReviewInfo != null)
                    {
                        foreach (DataRow dr in dt_ReviewInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_ReviewInfo.Columns.Count;
                            RV = new RMS.Models.DM_ReviewInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        RV.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "ReviewInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //Enhancement No                               
                                else if (i == 1)
                                {
                                    RV.ReviewNo = Convert.ToInt32(colValue.ToString());
                                }
                                //Review Start Date
                                else if (i == 2)
                                {
                                    RV.StartDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //Review End Date
                                else if (i == 3)
                                {
                                    RV.EndDate = Convert.ToDateTime(colValue.ToString());
                                }
                                //Review Period
                                else if (i == 4)
                                {
                                    RV.Period = 1 + (RV.EndDate.Year - RV.StartDate.Year) * 12 + RV.EndDate.Month - RV.StartDate.Month;
                                }
                                // Either Increase Amount 
                                else if (i == 5)
                                {
                                    RV.IncreaseAmount = Convert.ToDouble(colValue.ToString());
                                }
                                //Or Increase %
                                else if (i == 6)
                                {
                                    RV.IncreasePercentage = Convert.ToDouble(colValue.ToString());
                                }
                                //Review Note
                                else if (i == 7)
                                {
                                    RV.ReviewNote = colValue;
                                }
                            }
                            lstReview.Add(RV);
                        }
                        db.DM_ReviewInfos.AddRange(lstReview);
                        db.SaveChanges();
                        TotalRows_ReviewInfo = RowNo;
                    }
                    //==DM_LandlordInfo
                    RMS.Models.DM_LandlordInfo LI = new RMS.Models.DM_LandlordInfo();
                    List<RMS.Models.DM_LandlordInfo> lstLI = new List<RMS.Models.DM_LandlordInfo>();
                    RowNo = 0;
                    if (dt_LandlordInfo != null)
                    {
                        foreach (DataRow dr in dt_LandlordInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_LandlordInfo.Columns.Count;
                            LI = new RMS.Models.DM_LandlordInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        LI.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "LandlordInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //==VendorCode
                                else if (i == 1)
                                {
                                    LI.VendorCode = colValue;
                                }
                                //==LandlordName
                                else if (i == 2)
                                {
                                    LI.LandlordName = colValue;
                                }
                                //==ModeOfPayment
                                else if (i == 3)
                                {
                                    LI.ModeOfPayment = colValue;
                                }
                                //==Advance%
                                else if (i == 4)
                                {
                                    LI.AdvancePC = Convert.ToDouble(colValue.ToString());
                                }
                                //==AdvanceAdjustment%
                                else if (i == 5)
                                {
                                    LI.AdvanceAdjustmentPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==Tax%
                                else if (i == 6)
                                {
                                    LI.TaxPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==VAT%
                                else if (i == 7)
                                {
                                    LI.VATPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==Rent%
                                else if (i == 8)
                                {
                                    LI.RentPC = Convert.ToDouble(colValue.ToString());
                                }
                                //Landlord Address
                                else if (i == 9)
                                {
                                    LI.LLAddress = colValue;
                                }
                                //Landlord Contact No
                                else if (i == 10)
                                {
                                    LI.LLContactNo = colValue;
                                }
                                //Landlord  Email
                                else if (i == 11)
                                {
                                    LI.LLEmail = colValue;
                                }
                                //==ACNo
                                else if (i == 12)
                                {
                                    LI.ACNo = colValue;
                                }
                                //==BankName
                                else if (i == 13)
                                {
                                    LI.BankName = colValue;
                                }
                                //==BranchName
                                else if (i == 14)
                                {
                                    LI.BranchName = colValue;
                                }
                                //==RoutingNo
                                else if (i == 15)
                                {
                                    LI.RoutingNo = colValue;
                                }
                            }
                            lstLI.Add(LI);
                        }
                        db.DM_LandlordInfos.AddRange(lstLI);
                        db.SaveChanges();
                        TotalRows_LandlordInfo = RowNo;
                    }
                    //==DM_CostCenterInfo
                    RMS.Models.DM_CostCenterInfo CC = new RMS.Models.DM_CostCenterInfo();
                    List<RMS.Models.DM_CostCenterInfo> lstCC = new List<RMS.Models.DM_CostCenterInfo>();
                    RowNo = 0;
                    if (dt_CostCenterInfo != null)
                    {
                        foreach (DataRow dr in dt_CostCenterInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_CostCenterInfo.Columns.Count;
                            CC = new RMS.Models.DM_CostCenterInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        CC.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "CostCenterInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //==CostCenterCode
                                else if (i == 1)
                                {
                                    CC.CCCode = colValue;
                                }
                                //==CostCenterName
                                else if (i == 2)
                                {
                                    CC.CCName = colValue;
                                }
                                //==SOLCode
                                else if (i == 3)
                                {
                                    CC.SOLCode = colValue;
                                }
                                //==SOLName
                                else if (i == 4)
                                {
                                    CC.SOLName = colValue;
                                }
                                //==ShareAllotment%
                                else if (i == 5)
                                {
                                    CC.CCShareAllotment = Convert.ToDouble(colValue.ToString());
                                }
                            }
                            lstCC.Add(CC);
                        }
                        db.DM_CostCenterInfos.AddRange(lstCC);
                        db.SaveChanges();
                        TotalRows_CostCenterInfo = RowNo;
                    }
                    //==DM_UtilityInfo
                    RMS.Models.DM_UtilityInfo UI = new RMS.Models.DM_UtilityInfo();
                    List<RMS.Models.DM_UtilityInfo> lstUI = new List<RMS.Models.DM_UtilityInfo>();
                    RowNo = 0;
                    if (dt_UtilityInfo != null)
                    {
                        foreach (DataRow dr in dt_UtilityInfo.Rows)
                        {
                            RowNo = RowNo + 1;
                            int colCount = dt_UtilityInfo.Columns.Count;
                            UI = new RMS.Models.DM_UtilityInfo();
                            for (int i = 0; i < colCount; i++)
                            {
                                var colValue = dr[i].ToString();
                                //==AgreementCode
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(colValue) && !string.IsNullOrWhiteSpace(colValue))
                                    {
                                        UI.AgreementCode = colValue;
                                    }
                                    else
                                    {
                                        return Json(new { CheckStatus = false, RowNo = RowNo, Type = "UtilityInfo", ColName = "AgreementCode", ErrorType = "Blank" }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                //==VendorCode
                                else if (i == 1)
                                {
                                    UI.UtilityVendorCode = colValue;
                                }
                                //==LandlordName
                                else if (i == 2)
                                {
                                    UI.UtilityLandlordName = colValue;
                                }
                                //==ModeOfPayment
                                else if (i == 3)
                                {
                                    UI.UtilityModeOfPayment = colValue;
                                }
                                //==ServiceCharge%
                                else if (i == 4)
                                {
                                    UI.ServiceChargePC = Convert.ToDouble(colValue.ToString());
                                }
                                //==OnlineTowerCharge%
                                else if (i == 5)
                                {
                                    UI.OnlineTowerPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==GeneratorSpaceCharge%
                                else if (i == 6)
                                {
                                    UI.GeneratorSpacePC = Convert.ToDouble(colValue.ToString());
                                }
                                //==CarParkingCharge%
                                else if (i == 7)
                                {
                                    UI.CarParkingPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==Tax%
                                else if (i == 8)
                                {
                                    UI.TaxPC = Convert.ToDouble(colValue.ToString());
                                }
                                //==VAT%
                                else if (i == 9)
                                {
                                    UI.VATPC = Convert.ToDouble(colValue.ToString());
                                }
                                //Landlord Address
                                else if (i == 10)
                                {
                                    UI.UtilityAddress = colValue;
                                }
                                //Landlord Contact No
                                else if (i == 11)
                                {
                                    UI.UtilityContactNo = colValue;
                                }
                                //Landlord Email
                                else if (i == 12)
                                {
                                    UI.UtilityEmail = colValue;
                                }
                                //==ACNo
                                else if (i == 13)
                                {
                                    UI.UtilityACNo = colValue;
                                }
                                //==BankName
                                else if (i == 14)
                                {
                                    UI.UtilityBankName = colValue;
                                }
                                //==BranchName
                                else if (i == 15)
                                {
                                    UI.UtilityBranchName = colValue;
                                }
                                //==RoutingNo
                                else if (i == 16)
                                {
                                    UI.UtilityRoutingNo = colValue;
                                }
                            }
                            lstUI.Add(UI);
                        }
                        db.DM_UtilityInfos.AddRange(lstUI);
                        db.SaveChanges();
                        TotalRows_UtilityInfo = RowNo;
                    }
                    //==Save to Agreement Info Table
                    List<RMS.Models.DM_AgreementInfo> lstDM_AI = db.DM_AgreementInfos.OrderBy(x => x.AgreementSLNo).ToList();
                    RMS.Models.AgreementInfo Agr = new RMS.Models.AgreementInfo();
                    AgreementType AgreementType = new AgreementType();
                    AgreementUOM AgreementUOM = new AgreementUOM();
                    TaxVatType TaxVatType = new TaxVatType();
                    AgreementStatus AgreementStatus = new AgreementStatus();
                    DTOBasic DTOBasic = new DTOBasic();
                    ModeOfPaymentLocation ModeOfPaymentLocation = new ModeOfPaymentLocation();
                    foreach (var item in lstDM_AI)
                    {
                        int Max = db.AgreementInfos.Max(x => (int?)x.AgreementCode) ?? 0;
                        if (Max == 0)
                        {
                            Max = 10001;
                        }
                        else
                        {
                            Max = Max + 1;
                        }
                        Agr.AgreementCode = Max;
                        Agr.AgreementType = AgreementType.Regular;
                        Agr.AliasCode = Max.ToString();
                        //==Basic Info
                        Agr.PremiseTypeSLNo = db.PremiseTypeInfos.Where(x => x.PremiseType == item.PremiseType).Select(x => x.PremiseTypeSLNo).SingleOrDefault();
                        Agr.PremiseName = item.PremiseName;
                        Agr.PremiseAddress = item.PremiseAddress;
                        //==Agreement Info
                        Agr.AgreementName = item.AgreementName;
                        Agr.AgreementStartDate = item.AgreementStartDate;
                        Agr.AgreementEndDate = item.AgreementEndDate;
                        Agr.AgreementPeriod = item.AgreementPeriod;
                        Agr.RenewalFrequency = item.AgreementPeriod;
                        Agr.RentDueDay = item.RentDueDay;
                        if (item.UOM == AgreementUOM.SquareFeetText)
                        {
                            Agr.UOM = AgreementUOM.SquareFeetValue;
                        }
                        else
                        {
                            Agr.UOM = AgreementUOM.SquareMeterValue;
                        }
                        Agr.TotalArea = item.TotalArea;
                        Agr.CostPerUnit = item.CostPerUnit;
                        //==
                        Agr.TotalRentAmount = item.TotalArea * item.CostPerUnit;
                        if (item.TaxType == TaxVatType.InclusiveText && item.VATType == TaxVatType.InclusiveText)
                        {
                            Agr.VATAmount = (Agr.TotalRentAmount / 115) * item.VATPC;
                            Agr.TaxAmount = (Agr.TotalRentAmount - Agr.VATAmount) * item.TaxPC / 100;
                        }
                        else if (item.TaxType == TaxVatType.InclusiveText && item.VATType == TaxVatType.ExclusiveText)
                        {
                            Agr.TaxAmount = (Agr.TotalRentAmount * item.TaxPC) / 100;
                            Agr.VATAmount = (Agr.TotalRentAmount * item.VATPC) / 100;
                            Agr.TotalRentAmount = Agr.TotalRentAmount + Agr.VATAmount;
                        }
                        else if (item.TaxType == TaxVatType.ExclusiveText && item.VATType == TaxVatType.ExclusiveText)
                        {
                            Agr.TaxAmount = (Agr.TotalRentAmount / (100 - item.TaxPC)) * item.TaxPC;
                            Agr.VATAmount = (Agr.TotalRentAmount + Agr.TaxAmount) * item.VATPC / 100;
                            Agr.TotalRentAmount = Agr.TotalRentAmount + Agr.TaxAmount + Agr.VATAmount;
                        }
                        //==
                        Agr.SecurityDepositAmount = item.SecurityDepositAmount;
                        Agr.AdvanceAmount = item.AdvanceAmount;
                        Agr.TaxPercentage = item.TaxPC;
                        Agr.VATPercentage = item.VATPC;
                        if (item.TaxType == TaxVatType.InclusiveText)
                        {
                            Agr.TaxType = TaxVatType.InclusiveValue;
                        }
                        else
                        {
                            Agr.TaxType = TaxVatType.ExclusiveValue;
                        }
                        if (item.VATType == TaxVatType.InclusiveText)
                        {
                            Agr.VatType = TaxVatType.InclusiveValue;
                        }
                        else
                        {
                            Agr.VatType = TaxVatType.ExclusiveValue;
                        }
                        Agr.NetRentAmount = Agr.TotalRentAmount - Agr.AdvanceAdjustmentAmount;
                        Agr.AgreementStatus = AgreementStatus.Created;
                        Agr.AgreementText = item.AgreementCode;
                        Agr.Status = DTOBasic.active;
                        Agr.UserSLNo = 1;
                        Agr.EntryDate = DateTime.Now;
                        Agr.IsDeleted = false;
                        Agr.ReviewFrequency = item.ReviewFrequency;
                        Agr.ReviewPercentage = item.ReviewPC;
                        Agr.ServiceCharge = item.ServiceCharge;
                        Agr.OnlineTower = item.OnlineTower;
                        Agr.GeneratorSpace = item.GeneratorSpace;
                        Agr.CarParking = item.CarParking;
                        //==Control Data
                        Agr.CashGLCode = item.CashGLCode;
                        Agr.BankGLCode = item.BankGLCode;
                        Agr.AdvanceGLCode = item.AdvanceGLCode;
                        Agr.AdvanceAdjustmentGLCode = item.AdvanceAdjustmentGLCode;
                        Agr.RentGLCode = item.RentGLCode;
                        Agr.ServiceChargeGLCode = item.UtilityGLCode;
                        Agr.TaxGLCode = item.TaxGLCode;
                        Agr.VATGLCode = item.VATGLCode;
                        //==
                        Agr.PremiseAddressBangla = item.PremiseAddressBangla;
                        Agr.AreaStatus = item.AreaStatus;
                        Agr.RegionalOffice = item.RegionalOffice;
                        Agr.PrimarySOL = item.PrimarySOL;
                        Agr.AttachedControl = item.AttachedControl;
                        Agr.ControllerOfficeDistance = item.ControllerOfficeDistance;
                        Agr.RoutingNumber = item.RoutingNumber;
                        Agr.Division = item.Division;
                        Agr.District = item.District;
                        Agr.Upazila = item.Upazila;
                        Agr.Thana = item.Thana;
                        Agr.ThanaCode = item.ThanaCode;
                        Agr.Pourasabha = item.Pourasabha;
                        Agr.PourasabhaType = item.PourasabhaType;
                        Agr.UnionName = item.UnionName;
                        Agr.WardNo = item.WardNo;
                        Agr.PremisesTypeforAccounts = item.PremisesTypeforAccounts;
                        Agr.ParentAgreementCode = item.ParentAgreementCode;
                        Agr.ElectricityLoad = item.ElectricityLoad;
                        Agr.ElectricityProvidedBy = item.ElectricityProvidedBy;
                        Agr.AITBourneBy = item.AITBourneBy;
                        Agr.CommercialPermission = item.CommercialPermission;
                        Agr.BuildingPlan = item.BuildingPlan;
                        Agr.PremisesSituatedFloor = item.PremisesSituatedFloor;
                        Agr.BangladeshBankApproval = item.BangladeshBankApproval;
                        Agr.BangladeshBankReference = item.BangladeshBankReference;
                        Agr.ITTowerRentClause = item.ITTowerRentClause;
                        Agr.TerminationClause = item.TerminationClause;
                        Agr.TerminationNoticePeriod = item.TerminationNoticePeriod;
                        if (item.PremisesOpeningDate != null)
                        {
                            Agr.PremisesOpeningDate = item.PremisesOpeningDate;
                        }
                        else
                        {
                            Agr.PremisesOpeningDate = null;
                        }
                        if (item.DocumentDate != null)
                        {
                            Agr.DocumentDate = item.DocumentDate;
                        }
                        else
                        {
                            Agr.DocumentDate = null;
                        }
                        Agr.AgreementRemarks = item.AgreementRemarks;
                        Agr.BorrowingRate = item.BorrowingRate;
                        Agr.PaymentMethod = item.PaymentMethod;
                        Agr.IsIFRSEnable = item.IsIFRSEnable;
                        Agr.CalculationMethod = item.CalculationMethod;
                        Agr.WithHoldingCode = item.WithHoldingCode;
                        Agr.AdditionalExpense = item.AdditionalExpense;
                        Agr.InitialDirectCost = item.InitialDirectCost;
                        Agr.DismantlingCost = item.DismantlingCost;
                        Agr.CarParkingNo = item.CarParkingNo;
                        Agr.ProvisionGLTax = item.ProvisionGLTax;
                        Agr.ProvisionGLAP = item.ProvisionGLAP;
                        Agr.RTGSGL = item.RTGSGL;
                        Agr.EFTNGL = item.EFTNGL;
                        Agr.PayOrderGL = item.PayOrderGL;
                        Agr.IBBPaymentGL = item.IBBPaymentGL;
                        Agr.CityBrokerageGL = item.CityBrokerageGL;
                        Agr.CityCapitalGL = item.CityCapitalGL;
                        Agr.OthersGL = item.OthersGL;
                        Agr.WaterBillType = item.WaterBillType;
                        Agr.WaterBillAmount = item.WaterBillAmount;
                        if (item.IFRSEffectiveDate != null)
                        {
                            Agr.IFRSEffectiveDate = item.IFRSEffectiveDate;
                        }
                        else
                        {
                            Agr.IFRSEffectiveDate = null;
                        }
                        Agr.CorporateTaxRate = item.CorporateTaxRate;
                        //==
                        db.AgreementInfos.Add(Agr);
                        db.SaveChanges();
                        //==Save Space Info
                        List<RMS.Models.DM_SpaceInfo> lstDM_SP = db.DM_SpaceInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.SpaceSLNo).ToList();
                        foreach (var itemSP in lstDM_SP)
                        {
                            RMS.Models.SpaceInfo Agr_SP = new RMS.Models.SpaceInfo();
                            Agr_SP.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_SP.SpaceType = itemSP.SpaceType;
                            Agr_SP.SpaceArea = itemSP.SpaceArea;
                            Agr_SP.SpaceRate = itemSP.SpaceRate;
                            Agr_SP.SpaceRent = itemSP.SpaceRent;
                            Agr_SP.SpaceTotalAdvance = itemSP.SpaceTotalAdvance;
                            Agr_SP.SpaceTotalAdjustment = itemSP.SpaceTotalAdjustment;
                            Agr_SP.SpaceRemarks = itemSP.SpaceRemarks;
                            db.SpaceInfos.Add(Agr_SP);
                            db.SaveChanges();
                        }
                        //==Save Advance Info
                        List<RMS.Models.DM_AdvanceInfo> lstDM_AD = db.DM_AdvanceInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.AdvanceSLNo).ToList();
                        foreach (var itemAD in lstDM_AD)
                        {
                            RMS.Models.AdvanceInfo Agr_AD = new RMS.Models.AdvanceInfo();
                            Agr_AD.AdvanceNo = itemAD.AdvanceNo;
                            Agr_AD.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_AD.StartDate = itemAD.StartDate;
                            Agr_AD.EndDate = itemAD.EndDate;
                            Agr_AD.AdvanceSlotPeriod = itemAD.AdvanceSlotPeriod;
                            Agr_AD.AdvanceSlotAmount = itemAD.AdvanceSlotAmount;
                            Agr_AD.AdvanceNote = itemAD.AdvanceNote;
                            db.AdvanceInfos.Add(Agr_AD);
                            db.SaveChanges();
                        }
                        //==Save Review Info
                        List<RMS.Models.DM_ReviewInfo> lstDM_RV = db.DM_ReviewInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.ReviewNo).ToList();
                        foreach (var itemRV in lstDM_RV)
                        {
                            RMS.Models.ReviewInfo Agr_RV = new RMS.Models.ReviewInfo();
                            Agr_RV.ReviewNo = itemRV.ReviewNo;
                            Agr_RV.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_RV.StartDate = itemRV.StartDate;
                            Agr_RV.EndDate = itemRV.EndDate;
                            Agr_RV.Period = itemRV.Period;
                            Agr_RV.IncreaseAmount = itemRV.IncreaseAmount;
                            Agr_RV.IncreasePercentage = itemRV.IncreasePercentage;
                            Agr_RV.ReviewNote = itemRV.ReviewNote;
                            db.ReviewInfos.Add(Agr_RV);
                            db.SaveChanges();
                        }
                        //==Save Landlord Info
                        List<RMS.Models.DM_LandlordInfo> lstDM_LI = db.DM_LandlordInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.LandlordSLNo).ToList();
                        foreach (var itemLI in lstDM_LI)
                        {
                            RMS.Models.LandlordInfo Agr_LI = new RMS.Models.LandlordInfo();
                            Agr_LI.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_LI.VendorCode = itemLI.VendorCode;
                            Agr_LI.LandlordName = itemLI.LandlordName;
                            if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strAccountTransfer) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.AccountTransfer; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strRTGS) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.RTGS; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strEFTN) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.EFTN; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strPayOrder) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.PayOrder; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strCash) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.Cash; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strIBBPayment) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.IBBPayment; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strCityBrokerage) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.CityBrokerage; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strCityCapital) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.CityCapital; }
                            else if (itemLI.ModeOfPayment == ModeOfPaymentLocation.strOthers) { Agr_LI.ModeOfPayment = ModeOfPaymentLocation.Others; }
                            Agr_LI.AdvancePC = Convert.ToDouble(itemLI.AdvancePC.ToString());
                            Agr_LI.AdvanceAmount = (Agr.AdvanceAmount * Agr_LI.AdvancePC) / 100;
                            Agr_LI.AdvanceAdjustmentPC = Convert.ToDouble(itemLI.AdvanceAdjustmentPC.ToString());
                            //LI.AdvanceAdjustmentAmount = Convert.ToDouble(VendorAdvanceAdjustmentAmountList[i].ToString());
                            Agr_LI.TaxPC = Convert.ToDouble(itemLI.TaxPC.ToString());
                            Agr_LI.TaxAmount = (Agr.TaxAmount * Agr_LI.TaxPC) / 100;
                            Agr_LI.VATPC = Convert.ToDouble(itemLI.VATPC.ToString());
                            Agr_LI.VATAmount = (Agr.VATAmount * Agr_LI.VATPC) / 100;
                            Agr_LI.RentPC = Convert.ToDouble(itemLI.RentPC.ToString());
                            //LI.RentAmount = Convert.ToDouble(VendorRentAmountList[i].ToString());
                            Agr_LI.LLAddress = itemLI.LLAddress;
                            Agr_LI.LLContactNo = itemLI.LLContactNo;
                            Agr_LI.LLEmail = itemLI.LLEmail;
                            Agr_LI.ACNo = itemLI.ACNo;
                            Agr_LI.BankName = itemLI.BankName;
                            Agr_LI.BranchName = itemLI.BranchName;
                            Agr_LI.RoutingNo = itemLI.RoutingNo;
                            db.LandlordInfos.Add(Agr_LI);
                            db.SaveChanges();
                        }
                        //==Save CostCenter Info
                        List<RMS.Models.DM_CostCenterInfo> lstDM_CC = db.DM_CostCenterInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.CCSLNo).ToList();
                        foreach (var itemCC in lstDM_CC)
                        {
                            RMS.Models.CostCenterInfo Agr_CC = new RMS.Models.CostCenterInfo();
                            Agr_CC.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_CC.CCCode = itemCC.CCCode;
                            Agr_CC.CCName = itemCC.CCName;
                            Agr_CC.SOLCode = itemCC.SOLCode;
                            Agr_CC.SOLName = itemCC.SOLName;
                            Agr_CC.CCShareAllotment = Convert.ToDouble(itemCC.CCShareAllotment);
                            db.CostCenterInfos.Add(Agr_CC);
                            db.SaveChanges();
                        }
                        //==Save Utility Info
                        List<RMS.Models.DM_UtilityInfo> lstDM_UI = db.DM_UtilityInfos.Where(x => x.AgreementCode == item.AgreementCode).OrderBy(x => x.UtilitySLNo).ToList();
                        foreach (var itemUI in lstDM_UI)
                        {
                            RMS.Models.UtilityInfo Agr_UI = new RMS.Models.UtilityInfo();
                            Agr_UI.AgreementSLNo = Agr.AgreementSLNo;
                            Agr_UI.UtilityVendorCode = itemUI.UtilityVendorCode;
                            Agr_UI.UtilityLandlordName = itemUI.UtilityLandlordName;
                            if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strAccountTransfer) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.AccountTransfer; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strRTGS) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.RTGS; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strEFTN) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.EFTN; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strPayOrder) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.PayOrder; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strCash) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.Cash; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strIBBPayment) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.IBBPayment; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strCityBrokerage) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.CityBrokerage; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strCityCapital) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.CityCapital; }
                            else if (itemUI.UtilityModeOfPayment == ModeOfPaymentLocation.strOthers) { Agr_UI.UtilityModeOfPayment = ModeOfPaymentLocation.Others; }
                            Agr_UI.ServiceChargePC = Convert.ToDouble(itemUI.ServiceChargePC);
                            Agr_UI.ServiceChargeAmount = (Agr.ServiceCharge * Agr_UI.ServiceChargePC) / 100;
                            Agr_UI.OnlineTowerPC = Convert.ToDouble(itemUI.OnlineTowerPC);
                            Agr_UI.OnlineTowerAmount = (Agr.OnlineTower * Agr_UI.OnlineTowerPC) / 100;
                            Agr_UI.GeneratorSpacePC = Convert.ToDouble(itemUI.GeneratorSpacePC);
                            Agr_UI.GeneratorSpaceAmount = (Agr.GeneratorSpace * Agr_UI.GeneratorSpacePC) / 100;
                            Agr_UI.CarParkingPC = Convert.ToDouble(itemUI.CarParkingPC);
                            Agr_UI.CarParkingAmount = (Agr.CarParking * Agr_UI.CarParkingPC) / 100;
                            Agr_UI.TaxPC = Convert.ToDouble(itemUI.TaxPC);
                            Agr_UI.TaxAmount = (Agr.ServiceCharge + Agr.OnlineTower + Agr.GeneratorSpace + Agr.CarParking) * Agr_UI.TaxPC / 100;
                            Agr_UI.VATPC = Convert.ToDouble(itemUI.VATPC);
                            Agr_UI.VATAmount = (Agr.ServiceCharge + Agr.OnlineTower + Agr.GeneratorSpace + Agr.CarParking) * Agr_UI.VATPC / 100;
                            Agr_UI.UtilityAddress = itemUI.UtilityAddress;
                            Agr_UI.UtilityContactNo = itemUI.UtilityContactNo;
                            Agr_UI.UtilityEmail = itemUI.UtilityEmail;
                            Agr_UI.UtilityACNo = itemUI.UtilityACNo;
                            Agr_UI.UtilityBankName = itemUI.UtilityBankName;
                            Agr_UI.UtilityBranchName = itemUI.UtilityBranchName;
                            Agr_UI.UtilityRoutingNo = itemUI.UtilityRoutingNo;
                            db.UtilityInfos.Add(Agr_UI);
                            db.SaveChanges();
                        }
                        //==
                    }
                    //==
                    return Json(new { CheckStatus = true, TotalRows_AgreementInfo = TotalRows_AgreementInfo, TotalRows_SpaceInfo = TotalRows_SpaceInfo, TotalRows_AdvanceInfo = TotalRows_AdvanceInfo, TotalRows_ReviewInfo = TotalRows_ReviewInfo, TotalRows_LandlordInfo = TotalRows_LandlordInfo, TotalRows_CostCenterInfo = TotalRows_CostCenterInfo, TotalRows_UtilityInfo = TotalRows_UtilityInfo }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View(HomePath.Login);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Message = Ex.ToString();
                return View(HomePath.DisplayMessage);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Activate_UploadData()
        {
            try
            {
                AgreementStatus AgreementStatus = new AgreementStatus();
                List<RMS.Models.AgreementInfo> lstMaster_AI = db.AgreementInfos.Where(x => x.AgreementStatus == AgreementStatus.Created).ToList();
                foreach (RMS.Models.AgreementInfo itemMaster_AI in lstMaster_AI)
                {
                    int AgreementSLNo = itemMaster_AI.AgreementSLNo;
                    RMS.Models.AgreementInfo AI = db.AgreementInfos.Where(x => x.AgreementSLNo == AgreementSLNo).SingleOrDefault();
                    AI.ActivateBy = "111";
                    AI.ActivateDate = DateTime.Now;
                    AI.AgreementStatus = AgreementStatus.Activate;
                    db.Entry(AI).State = EntityState.Modified;
                    db.SaveChanges();
                    //==Contract Rent Schedule
                    RMS.Models.ContractSchedule CS = new RMS.Models.ContractSchedule();
                    RMS.Models.LandlordSchedule LS = new RMS.Models.LandlordSchedule();
                    RMS.Models.CostCenterSchedule CCS = new RMS.Models.CostCenterSchedule();
                    //RMS.Models.UtilitySchedule US = new RMS.Models.UtilitySchedule();
                    RMS.Models.IFRSSchedule IFRS = new RMS.Models.IFRSSchedule();
                    List<RMS.Models.LandlordInfo> lstLandlords = db.LandlordInfos.Where(x => x.AgreementSLNo == AI.AgreementSLNo).ToList();
                    List<RMS.Models.CostCenterInfo> lstCostCenter = db.CostCenterInfos.Where(x => x.AgreementSLNo == AI.AgreementSLNo).ToList();
                    //List<RMS.Models.UtilityInfo> lstUtility = db.UtilityInfos.Where(x => x.AgreementSLNo == AI.AgreementSLNo).ToList();
                    List<RMS.Models.ReviewInfo> lstReviewInfo = db.ReviewInfos.Where(x => x.AgreementSLNo == AgreementSLNo).OrderBy(x => x.ReviewNo).ToList();
                    List<RMS.Models.AdvanceInfo> lstAdvanceInfo = db.AdvanceInfos.Where(x => x.AgreementSLNo == AgreementSLNo).OrderBy(x => x.AdvanceNo).ToList();
                    DateTime ScheduleDate = AI.AgreementStartDate;
                    //===xxx====
                    int LastMonthDaysCount = DateTime.DaysInMonth(AI.AgreementEndDate.Year, AI.AgreementEndDate.Month);
                    int ReviewMonthDaysCount = 0;
                    int MonthDays = 0;

                    double RentPerDay = 0;
                    double BeforeReviewAmount = 0;
                    double AfterReviewAmount = 0;
                    double NetCalcAmount = 0;
                    if (AI.ReviewFrequency < 1 && lstReviewInfo.Count == 0)
                    {
                        //==Without Review
                        for (int i = 1; i <= AI.AgreementPeriod; i++)
                        {
                            CS = new RMS.Models.ContractSchedule();
                            if (i != 1)
                            {
                                ScheduleDate = ScheduleDate.AddMonths(1);
                            }
                            //==Contract Schedule
                            CS.ScheduleDate = ScheduleDate;
                            CS.AgreementSLNo = AI.AgreementSLNo;
                            CS.MonthNo = i;
                            CS.Year = CS.ScheduleDate.Year;
                            CS.Month = CS.ScheduleDate.ToString("MMMM");
                            CS.ReviewNo = 0;
                            if (i <= AI.AdvanceAdjustmentPeriod)
                            {
                                CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                            }
                            CS.CostPerUnit = AI.CostPerUnit;
                            CS.TotalRentAmount = AI.CostPerUnit * AI.TotalArea;
                            //==First Month
                            if (i == 1)
                            {
                                //==Full Month
                                if (ScheduleDate.Day != 1)
                                {
                                    //==Fraction Date Rent Amount
                                    MonthDays = DateTime.DaysInMonth(ScheduleDate.Year, ScheduleDate.Month);
                                    RentPerDay = CS.TotalRentAmount / MonthDays;
                                    CS.TotalRentAmount = ((MonthDays - ScheduleDate.Day) + 1) * RentPerDay;
                                }
                            }
                            //==Last Month
                            else if (i == AI.AgreementPeriod)
                            {
                                //==Full Month
                                if (AI.AgreementEndDate.Day != LastMonthDaysCount)
                                {
                                    //==Fraction Date Rent Amount
                                    RentPerDay = CS.TotalRentAmount / LastMonthDaysCount;
                                    CS.TotalRentAmount = AI.AgreementEndDate.Day * RentPerDay;
                                }
                            }
                            #region "Tax Type & VAT Type"
                            //1. Inclusive Inclusive
                            if (AI.TaxType == 1 && AI.VatType == 1)
                            {
                                CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //2. Inclusive Exclusive
                            else if (AI.TaxType == 1 && AI.VatType == 2)
                            {
                                CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //3. Inclusive Exempted
                            else if (AI.TaxType == 1 && AI.VatType == 3)
                            {
                                CS.VATAmount = 0;
                                CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //4. Exclusive Inclusive
                            else if (AI.TaxType == 2 && AI.VatType == 1)
                            {
                                CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //5. Exclusive Exclusive
                            else if (AI.TaxType == 2 && AI.VatType == 2)
                            {
                                CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                NetCalcAmount = CS.TotalRentAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //6. Exclusive Exempted
                            else if (AI.TaxType == 2 && AI.VatType == 3)
                            {
                                CS.VATAmount = 0;
                                CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                NetCalcAmount = CS.TotalRentAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //7. Exempted  Inclusive
                            else if (AI.TaxType == 3 && AI.VatType == 1)
                            {
                                CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                CS.TaxAmount = 0;
                                NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //8. Exempted  Exclusive
                            else if (AI.TaxType == 3 && AI.VatType == 2)
                            {
                                CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                CS.TaxAmount = 0;
                                NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            //9. Exempted Exempted
                            else if (AI.TaxType == 3 && AI.VatType == 3)
                            {
                                CS.VATAmount = 0;
                                CS.TaxAmount = 0;
                                NetCalcAmount = CS.TotalRentAmount;
                                CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                            }
                            #endregion
                            CS.UserSLNo = AI.UserSLNo;
                            CS.EntryDate = DateTime.Now;
                            db.ContractSchedules.Add(CS);
                            db.SaveChanges();
                            //==Landlord Schedule
                            foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                            {
                                LS = new RMS.Models.LandlordSchedule();
                                LS.ScheduleDate = ScheduleDate;
                                LS.AgreementSLNo = AI.AgreementSLNo;
                                LS.LandlordSLNo = LI.LandlordSLNo;
                                LS.MonthNo = i;
                                LS.Year = CS.ScheduleDate.Year;
                                LS.Month = CS.ScheduleDate.ToString("MMMM");
                                LS.ReviewNo = 0;
                                if (i <= AI.AdvanceAdjustmentPeriod)
                                {
                                    LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                }
                                LS.CostPerUnit = AI.CostPerUnit;
                                LS.TotalRentAmount = CS.TotalRentAmount;
                                //==
                                if (CS.TaxAmount > 0)
                                {
                                    LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                }
                                if (CS.VATAmount > 0)
                                {
                                    LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                }
                                //==
                                LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - (LS.AdvanceAdjustmentAmount);
                                LS.UserSLNo = AI.UserSLNo;
                                LS.EntryDate = DateTime.Now;
                                db.LandlordSchedules.Add(LS);
                                db.SaveChanges();
                            }
                            //==Cost Allocation Schedule
                            foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                            {
                                CCS = new RMS.Models.CostCenterSchedule();
                                CCS.ScheduleDate = ScheduleDate;
                                CCS.AgreementSLNo = AI.AgreementSLNo;
                                CCS.CCSLNo = CC.CCSLNo;
                                CCS.MonthNo = i;
                                CCS.Year = CS.ScheduleDate.Year;
                                CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                CCS.ReviewNo = 0;
                                CCS.CostPerUnit = AI.CostPerUnit;
                                CCS.TotalRentAmount = CS.TotalRentAmount;
                                if (i <= AI.AdvanceAdjustmentPeriod)
                                {
                                    CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                }
                                if (CS.TaxAmount > 0)
                                {
                                    CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                }
                                if (CS.VATAmount > 0)
                                {
                                    CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                }
                                //==
                                CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                CCS.UserSLNo = AI.UserSLNo;
                                CCS.EntryDate = DateTime.Now;
                                db.CostCenterSchedules.Add(CCS);
                                db.SaveChanges();
                            }
                        }
                    }
                    else if (AI.ReviewFrequency > 0)
                    {
                        //==Review Frequency (Repeated)
                        int ReviewCount = AI.ReviewFrequency + 1;
                        int ReviewNo = 0;
                        double NewCPU = AI.CostPerUnit;
                        for (int i = 1; i <= AI.AgreementPeriod; i++)
                        {
                            CS = new RMS.Models.ContractSchedule();
                            if (i != 1)
                            {
                                ScheduleDate = ScheduleDate.AddMonths(1);
                            }
                            if (i <= AI.ReviewFrequency)
                            {
                                //==Contract Schedule
                                CS.ScheduleDate = ScheduleDate;
                                CS.AgreementSLNo = AI.AgreementSLNo;
                                CS.MonthNo = i;
                                CS.Year = CS.ScheduleDate.Year;
                                CS.Month = CS.ScheduleDate.ToString("MMMM");
                                CS.ReviewNo = ReviewNo;
                                if (i <= AI.AdvanceAdjustmentPeriod)
                                {
                                    CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                }
                                CS.CostPerUnit = NewCPU;
                                CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                if (i == 1)
                                {
                                    //==Full Month
                                    if (ScheduleDate.Day != 1)
                                    {
                                        //==Fraction Date Rent Amount
                                        MonthDays = DateTime.DaysInMonth(ScheduleDate.Year, ScheduleDate.Month);
                                        RentPerDay = CS.TotalRentAmount / MonthDays;
                                        CS.TotalRentAmount = ((MonthDays - ScheduleDate.Day) + 1) * RentPerDay;
                                    }
                                }
                                #region "Tax Type & VAT Type"
                                //1. Inclusive Inclusive
                                if (AI.TaxType == 1 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //2. Inclusive Exclusive
                                else if (AI.TaxType == 1 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //3. Inclusive Exempted
                                else if (AI.TaxType == 1 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //4. Exclusive Inclusive
                                else if (AI.TaxType == 2 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //5. Exclusive Exclusive
                                else if (AI.TaxType == 2 && AI.VatType == 2)
                                {
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //6. Exclusive Exempted
                                else if (AI.TaxType == 2 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //7. Exempted  Inclusive
                                else if (AI.TaxType == 3 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //8. Exempted  Exclusive
                                else if (AI.TaxType == 3 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //9. Exempted Exempted
                                else if (AI.TaxType == 3 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                #endregion
                                CS.UserSLNo = AI.UserSLNo;
                                CS.EntryDate = DateTime.Now;
                                db.ContractSchedules.Add(CS);
                                db.SaveChanges();
                                //==Landlord Schedule
                                foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                {
                                    LS = new RMS.Models.LandlordSchedule();
                                    LS.ScheduleDate = ScheduleDate;
                                    LS.AgreementSLNo = AI.AgreementSLNo;
                                    LS.LandlordSLNo = LI.LandlordSLNo;
                                    LS.MonthNo = i;
                                    LS.Year = CS.ScheduleDate.Year;
                                    LS.Month = CS.ScheduleDate.ToString("MMMM");
                                    LS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                    }
                                    LS.CostPerUnit = NewCPU;
                                    LS.TotalRentAmount = CS.TotalRentAmount;
                                    if (CS.TaxAmount > 0)
                                    {
                                        LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                    }
                                    //==
                                    LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                    LS.UserSLNo = AI.UserSLNo;
                                    LS.EntryDate = DateTime.Now;
                                    db.LandlordSchedules.Add(LS);
                                    db.SaveChanges();
                                }
                                //==Cost Allocation Schedule
                                foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                {
                                    CCS = new RMS.Models.CostCenterSchedule();
                                    CCS.ScheduleDate = ScheduleDate;
                                    CCS.AgreementSLNo = AI.AgreementSLNo;
                                    CCS.CCSLNo = CC.CCSLNo;
                                    CCS.MonthNo = i;
                                    CCS.Year = CS.ScheduleDate.Year;
                                    CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CCS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                    }
                                    CCS.CostPerUnit = NewCPU;
                                    CCS.TotalRentAmount = CS.TotalRentAmount;
                                    if (CS.TaxAmount > 0)
                                    {
                                        CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                    }
                                    //==
                                    CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                    CCS.UserSLNo = AI.UserSLNo;
                                    CCS.EntryDate = DateTime.Now;
                                    db.CostCenterSchedules.Add(CCS);
                                    db.SaveChanges();
                                }
                            }
                            else if (i == ReviewCount)
                            {
                                //==Contract Schedule
                                if (i != AI.AgreementPeriod)
                                {
                                    ReviewNo = ReviewNo + 1;
                                }
                                ReviewCount = ReviewCount + AI.ReviewFrequency;
                                CS.ScheduleDate = ScheduleDate;
                                CS.AgreementSLNo = AI.AgreementSLNo;
                                CS.MonthNo = i;
                                CS.Year = CS.ScheduleDate.Year;
                                CS.Month = CS.ScheduleDate.ToString("MMMM");
                                CS.ReviewNo = ReviewNo;
                                if (i <= AI.AdvanceAdjustmentPeriod)
                                {
                                    CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                }
                                //==xx
                                //==Last Month
                                if (i == AI.AgreementPeriod)
                                {
                                    CS.CostPerUnit = NewCPU;
                                    CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                    //==Full Month
                                    if (AI.AgreementEndDate.Day != LastMonthDaysCount)
                                    {
                                        //==Fraction Date Rent Amount
                                        RentPerDay = CS.TotalRentAmount / LastMonthDaysCount;
                                        CS.TotalRentAmount = AI.AgreementEndDate.Day * RentPerDay;
                                    }
                                }
                                else
                                {
                                    //==Fraction Month
                                    if (ScheduleDate.Day != 1)
                                    {
                                        //==Before Review Amount
                                        MonthDays = DateTime.DaysInMonth(ScheduleDate.Year, ScheduleDate.Month);
                                        RentPerDay = (NewCPU * AI.TotalArea) / MonthDays;
                                        BeforeReviewAmount = (ScheduleDate.Day - 1) * RentPerDay;
                                        //==After Review Amount
                                        NewCPU = NewCPU + (NewCPU * AI.ReviewPercentage) / 100;
                                        CS.CostPerUnit = NewCPU;
                                        RentPerDay = (CS.CostPerUnit * AI.TotalArea) / MonthDays;
                                        AfterReviewAmount = ((MonthDays - ScheduleDate.Day) + 1) * RentPerDay;
                                        CS.TotalRentAmount = BeforeReviewAmount + AfterReviewAmount;
                                    }
                                    else
                                    {
                                        NewCPU = NewCPU + (NewCPU * AI.ReviewPercentage) / 100;
                                        CS.CostPerUnit = NewCPU;
                                        CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                    }
                                }
                                #region "Tax Type & VAT Type"
                                //1. Inclusive Inclusive
                                if (AI.TaxType == 1 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //2. Inclusive Exclusive
                                else if (AI.TaxType == 1 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //3. Inclusive Exempted
                                else if (AI.TaxType == 1 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //4. Exclusive Inclusive
                                else if (AI.TaxType == 2 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //5. Exclusive Exclusive
                                else if (AI.TaxType == 2 && AI.VatType == 2)
                                {
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //6. Exclusive Exempted
                                else if (AI.TaxType == 2 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //7. Exempted  Inclusive
                                else if (AI.TaxType == 3 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //8. Exempted  Exclusive
                                else if (AI.TaxType == 3 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //9. Exempted Exempted
                                else if (AI.TaxType == 3 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                #endregion
                                CS.UserSLNo = AI.UserSLNo;
                                CS.EntryDate = DateTime.Now;
                                db.ContractSchedules.Add(CS);
                                db.SaveChanges();
                                //==Landlord Schedule
                                foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                {
                                    LS = new RMS.Models.LandlordSchedule();
                                    LS.ScheduleDate = ScheduleDate;
                                    LS.AgreementSLNo = AI.AgreementSLNo;
                                    LS.LandlordSLNo = LI.LandlordSLNo;
                                    LS.MonthNo = i;
                                    LS.Year = CS.ScheduleDate.Year;
                                    LS.Month = CS.ScheduleDate.ToString("MMMM");
                                    LS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                    }
                                    if (CS.TaxAmount > 0)
                                    {
                                        LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                    }
                                    LS.CostPerUnit = NewCPU;
                                    LS.TotalRentAmount = CS.TotalRentAmount;
                                    //==
                                    LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                    LS.UserSLNo = AI.UserSLNo;
                                    LS.EntryDate = DateTime.Now;
                                    db.LandlordSchedules.Add(LS);
                                    db.SaveChanges();
                                }
                                //==Cost Allocation Schedule
                                foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                {
                                    CCS = new RMS.Models.CostCenterSchedule();
                                    CCS.ScheduleDate = ScheduleDate;
                                    CCS.AgreementSLNo = AI.AgreementSLNo;
                                    CCS.CCSLNo = CC.CCSLNo;
                                    CCS.MonthNo = i;
                                    CCS.Year = CS.ScheduleDate.Year;
                                    CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CCS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                    }
                                    if (CS.TaxAmount > 0)
                                    {
                                        CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                    }
                                    CCS.CostPerUnit = NewCPU;
                                    CCS.TotalRentAmount = CS.TotalRentAmount;
                                    //==
                                    CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                    CCS.UserSLNo = AI.UserSLNo;
                                    CCS.EntryDate = DateTime.Now;
                                    db.CostCenterSchedules.Add(CCS);
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                CS.ScheduleDate = ScheduleDate;
                                CS.AgreementSLNo = AI.AgreementSLNo;
                                CS.MonthNo = i;
                                CS.Year = CS.ScheduleDate.Year;
                                CS.Month = CS.ScheduleDate.ToString("MMMM");
                                CS.ReviewNo = ReviewNo;
                                if (i <= AI.AdvanceAdjustmentPeriod)
                                {
                                    CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                }
                                CS.CostPerUnit = NewCPU;
                                CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                //==Last Month
                                if (i == AI.AgreementPeriod)
                                {
                                    //==Full Month
                                    if (AI.AgreementEndDate.Day != LastMonthDaysCount)
                                    {
                                        //==Fraction Date Rent Amount
                                        RentPerDay = CS.TotalRentAmount / LastMonthDaysCount;
                                        CS.TotalRentAmount = AI.AgreementEndDate.Day * RentPerDay;
                                    }
                                }
                                #region "Tax Type & VAT Type"
                                //1. Inclusive Inclusive
                                if (AI.TaxType == 1 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //2. Inclusive Exclusive
                                else if (AI.TaxType == 1 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //3. Inclusive Exempted
                                else if (AI.TaxType == 1 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //4. Exclusive Inclusive
                                else if (AI.TaxType == 2 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                    CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //5. Exclusive Exclusive
                                else if (AI.TaxType == 2 && AI.VatType == 2)
                                {
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //6. Exclusive Exempted
                                else if (AI.TaxType == 2 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //7. Exempted  Inclusive
                                else if (AI.TaxType == 3 && AI.VatType == 1)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //8. Exempted  Exclusive
                                else if (AI.TaxType == 3 && AI.VatType == 2)
                                {
                                    CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                //9. Exempted Exempted
                                else if (AI.TaxType == 3 && AI.VatType == 3)
                                {
                                    CS.VATAmount = 0;
                                    CS.TaxAmount = 0;
                                    NetCalcAmount = CS.TotalRentAmount;
                                    CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                    CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                }
                                #endregion
                                CS.UserSLNo = AI.UserSLNo;
                                CS.EntryDate = DateTime.Now;
                                db.ContractSchedules.Add(CS);
                                db.SaveChanges();
                                //==Landlord Schedule
                                foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                {
                                    LS = new RMS.Models.LandlordSchedule();
                                    LS.ScheduleDate = ScheduleDate;
                                    LS.AgreementSLNo = AI.AgreementSLNo;
                                    LS.LandlordSLNo = LI.LandlordSLNo;
                                    LS.MonthNo = i;
                                    LS.Year = CS.ScheduleDate.Year;
                                    LS.Month = CS.ScheduleDate.ToString("MMMM");
                                    LS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                    }
                                    if (CS.TaxAmount > 0)
                                    {
                                        LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                    }
                                    LS.CostPerUnit = NewCPU;
                                    LS.TotalRentAmount = CS.TotalRentAmount;
                                    //==
                                    LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                    LS.UserSLNo = AI.UserSLNo;
                                    LS.EntryDate = DateTime.Now;
                                    db.LandlordSchedules.Add(LS);
                                    db.SaveChanges();
                                }
                                //==Cost Allocation Schedule
                                foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                {
                                    CCS = new RMS.Models.CostCenterSchedule();
                                    CCS.ScheduleDate = ScheduleDate;
                                    CCS.AgreementSLNo = AI.AgreementSLNo;
                                    CCS.CCSLNo = CC.CCSLNo;
                                    CCS.MonthNo = i;
                                    CCS.Year = CS.ScheduleDate.Year;
                                    CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CCS.ReviewNo = ReviewNo;
                                    if (i <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                    }
                                    if (CS.TaxAmount > 0)
                                    {
                                        CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                    }
                                    if (CS.VATAmount > 0)
                                    {
                                        CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                    }
                                    CCS.CostPerUnit = NewCPU;
                                    CCS.TotalRentAmount = CS.TotalRentAmount;
                                    //==
                                    CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                    CCS.UserSLNo = AI.UserSLNo;
                                    CCS.EntryDate = DateTime.Now;
                                    db.CostCenterSchedules.Add(CCS);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    else if (AI.ReviewFrequency < 1 && lstReviewInfo.Count > 0)
                    {
                        //==Review Declaration Wise
                        int MonthNo = 0;
                        int ReviewNo = 0;
                        double NewCPU = AI.CostPerUnit;
                        //==Review Wise
                        foreach (RMS.Models.ReviewInfo RI in lstReviewInfo)
                        {
                            ReviewNo = ReviewNo + 1;
                            if (RI.ReviewNo == 1)
                            {
                                //==Schedule without Review
                                int ReviewStartMonth = ((RI.StartDate.Year - AI.AgreementStartDate.Year) * 12 + RI.StartDate.Month - AI.AgreementStartDate.Month) + 1;
                                for (int i = 1; i < ReviewStartMonth; i++)
                                {
                                    MonthNo = MonthNo + 1;
                                    CS = new RMS.Models.ContractSchedule();
                                    if (i != 1)
                                    {
                                        ScheduleDate = ScheduleDate.AddMonths(1);
                                    }
                                    //==Contract Schedule
                                    CS.ScheduleDate = ScheduleDate;
                                    CS.AgreementSLNo = AI.AgreementSLNo;
                                    CS.MonthNo = MonthNo;
                                    CS.Year = CS.ScheduleDate.Year;
                                    CS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CS.ReviewNo = 0;
                                    if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                    }
                                    CS.CostPerUnit = AI.CostPerUnit;
                                    CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                    if (i == 1)
                                    {
                                        //==Full Month
                                        if (ScheduleDate.Day != 1)
                                        {
                                            //==Fraction Date Rent Amount
                                            MonthDays = DateTime.DaysInMonth(ScheduleDate.Year, ScheduleDate.Month);
                                            RentPerDay = CS.TotalRentAmount / MonthDays;
                                            CS.TotalRentAmount = ((MonthDays - ScheduleDate.Day) + 1) * RentPerDay;
                                        }
                                    }
                                    #region "Tax Type & VAT Type"
                                    //1. Inclusive Inclusive
                                    if (AI.TaxType == 1 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //2. Inclusive Exclusive
                                    else if (AI.TaxType == 1 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //3. Inclusive Exempted
                                    else if (AI.TaxType == 1 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //4. Exclusive Inclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //5. Exclusive Exclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 2)
                                    {
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //6. Exclusive Exempted
                                    else if (AI.TaxType == 2 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //7. Exempted  Inclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //8. Exempted  Exclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //9. Exempted Exempted
                                    else if (AI.TaxType == 3 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    #endregion
                                    CS.UserSLNo = AI.UserSLNo;
                                    CS.EntryDate = DateTime.Now;
                                    db.ContractSchedules.Add(CS);
                                    db.SaveChanges();
                                    //==Landlord Schedule
                                    foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                    {
                                        LS = new RMS.Models.LandlordSchedule();
                                        LS.ScheduleDate = ScheduleDate;
                                        LS.AgreementSLNo = AI.AgreementSLNo;
                                        LS.LandlordSLNo = LI.LandlordSLNo;
                                        LS.MonthNo = MonthNo;
                                        LS.Year = CS.ScheduleDate.Year;
                                        LS.Month = CS.ScheduleDate.ToString("MMMM");
                                        LS.ReviewNo = 0;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                        }
                                        LS.CostPerUnit = AI.CostPerUnit;
                                        LS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                        LS.UserSLNo = AI.UserSLNo;
                                        LS.EntryDate = DateTime.Now;
                                        db.LandlordSchedules.Add(LS);
                                        db.SaveChanges();
                                    }
                                    //==Cost Allocation Schedule
                                    foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                    {
                                        CCS = new RMS.Models.CostCenterSchedule();
                                        CCS.ScheduleDate = ScheduleDate;
                                        CCS.AgreementSLNo = AI.AgreementSLNo;
                                        CCS.CCSLNo = CC.CCSLNo;
                                        CCS.MonthNo = MonthNo;
                                        CCS.Year = CS.ScheduleDate.Year;
                                        CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                        CCS.ReviewNo = 0;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                        }
                                        CCS.CostPerUnit = AI.CostPerUnit;
                                        CCS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                        CCS.UserSLNo = AI.UserSLNo;
                                        CCS.EntryDate = DateTime.Now;
                                        db.CostCenterSchedules.Add(CCS);
                                        db.SaveChanges();
                                    }
                                }
                                //==Schedule with Review
                                for (int i = 1; i <= RI.Period; i++)
                                {
                                    MonthNo = MonthNo + 1;
                                    CS = new RMS.Models.ContractSchedule();
                                    ScheduleDate = ScheduleDate.AddMonths(1);
                                    //==Contract Schedule
                                    CS.ScheduleDate = ScheduleDate;
                                    CS.AgreementSLNo = AI.AgreementSLNo;
                                    CS.MonthNo = MonthNo;
                                    CS.Year = CS.ScheduleDate.Year;
                                    CS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CS.ReviewNo = ReviewNo;
                                    if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                    }
                                    //==Fraction Month
                                    if (i == 1)
                                    {
                                        if (RI.StartDate.Day != 1)
                                        {
                                            //==Before Review Amount
                                            MonthDays = DateTime.DaysInMonth(RI.StartDate.Year, RI.StartDate.Month);
                                            RentPerDay = (NewCPU * AI.TotalArea) / MonthDays;
                                            BeforeReviewAmount = (RI.StartDate.Day - 1) * RentPerDay;
                                            //==After Review Amount                                            
                                            if (RI.IncreaseAmount > 0)
                                            {
                                                NewCPU = NewCPU + (RI.IncreaseAmount / AI.TotalArea);
                                            }
                                            else
                                            {
                                                NewCPU = NewCPU + ((NewCPU * RI.IncreasePercentage) / 100);
                                            }
                                            CS.CostPerUnit = NewCPU;
                                            RentPerDay = (CS.CostPerUnit * AI.TotalArea) / MonthDays;
                                            AfterReviewAmount = ((MonthDays - RI.StartDate.Day) + 1) * RentPerDay;
                                            CS.TotalRentAmount = BeforeReviewAmount + AfterReviewAmount;
                                        }
                                        else
                                        {
                                            if (RI.IncreaseAmount > 0)
                                            {
                                                NewCPU = NewCPU + (RI.IncreaseAmount / AI.TotalArea);
                                            }
                                            else
                                            {
                                                NewCPU = NewCPU + ((NewCPU * RI.IncreasePercentage) / 100);
                                            }
                                            CS.CostPerUnit = NewCPU;
                                            CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                        }
                                    }
                                    //==Review Last Month
                                    else if (i == RI.Period)
                                    {
                                        ReviewMonthDaysCount = DateTime.DaysInMonth(RI.EndDate.Year, RI.EndDate.Month);
                                        //==Full Month
                                        if (RI.EndDate.Day != ReviewMonthDaysCount)
                                        {
                                            //==Fraction Date Rent Amount
                                            CS.CostPerUnit = NewCPU;
                                            RentPerDay = (CS.CostPerUnit * AI.TotalArea) / ReviewMonthDaysCount;
                                            CS.TotalRentAmount = RI.EndDate.Day * RentPerDay;
                                        }
                                        else
                                        {
                                            CS.CostPerUnit = NewCPU;
                                            CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                        }
                                    }
                                    else
                                    {
                                        CS.CostPerUnit = NewCPU;
                                        CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                    }
                                    #region "Tax Type & VAT Type"
                                    //1. Inclusive Inclusive
                                    if (AI.TaxType == 1 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //2. Inclusive Exclusive
                                    else if (AI.TaxType == 1 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //3. Inclusive Exempted
                                    else if (AI.TaxType == 1 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //4. Exclusive Inclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //5. Exclusive Exclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 2)
                                    {
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //6. Exclusive Exempted
                                    else if (AI.TaxType == 2 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //7. Exempted  Inclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //8. Exempted  Exclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //9. Exempted Exempted
                                    else if (AI.TaxType == 3 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    #endregion
                                    CS.UserSLNo = AI.UserSLNo;
                                    CS.EntryDate = DateTime.Now;
                                    db.ContractSchedules.Add(CS);
                                    db.SaveChanges();
                                    //==Landlord Schedule
                                    foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                    {
                                        LS = new RMS.Models.LandlordSchedule();
                                        LS.ScheduleDate = ScheduleDate;
                                        LS.AgreementSLNo = AI.AgreementSLNo;
                                        LS.LandlordSLNo = LI.LandlordSLNo;
                                        LS.MonthNo = MonthNo;
                                        LS.Year = CS.ScheduleDate.Year;
                                        LS.Month = CS.ScheduleDate.ToString("MMMM");
                                        LS.ReviewNo = ReviewNo;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                        }
                                        LS.CostPerUnit = NewCPU;
                                        LS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                        LS.UserSLNo = AI.UserSLNo;
                                        LS.EntryDate = DateTime.Now;
                                        db.LandlordSchedules.Add(LS);
                                        db.SaveChanges();
                                    }
                                    //==Cost Allocation Schedule
                                    foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                    {
                                        CCS = new RMS.Models.CostCenterSchedule();
                                        CCS.ScheduleDate = ScheduleDate;
                                        CCS.AgreementSLNo = AI.AgreementSLNo;
                                        CCS.CCSLNo = CC.CCSLNo;
                                        CCS.MonthNo = MonthNo;
                                        CCS.Year = CS.ScheduleDate.Year;
                                        CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                        CCS.ReviewNo = ReviewNo;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                        }
                                        CCS.CostPerUnit = NewCPU;
                                        CCS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                        CCS.UserSLNo = AI.UserSLNo;
                                        CCS.EntryDate = DateTime.Now;
                                        db.CostCenterSchedules.Add(CCS);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                //==Schedule rest of the Review
                                for (int i = 1; i <= RI.Period; i++)
                                {
                                    CS = new RMS.Models.ContractSchedule();
                                    //==Conditions applicable for multiple enhancement slots are two enhancements in the same month
                                    if (i == 1 && ScheduleDate.Year == RI.StartDate.Year && ScheduleDate.Month == RI.StartDate.Month)
                                    {
                                        //===MonthNo wise Delete from Contract Schedule
                                        db.ContractSchedules.RemoveRange(db.ContractSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo == MonthNo));
                                        db.SaveChanges();
                                        //===MonthNo wise Delete from Landlord Schedule
                                        db.LandlordSchedules.RemoveRange(db.LandlordSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo == MonthNo));
                                        db.SaveChanges();
                                        //===MonthNo wise Delete from Cost Center Schedule
                                        db.CostCenterSchedules.RemoveRange(db.CostCenterSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo == MonthNo));
                                        db.SaveChanges();
                                        //==
                                    }
                                    else
                                    {
                                        MonthNo = MonthNo + 1;
                                        ScheduleDate = ScheduleDate.AddMonths(1);
                                    }
                                    //==Contract Schedule
                                    CS.ScheduleDate = ScheduleDate;
                                    CS.AgreementSLNo = AI.AgreementSLNo;
                                    CS.MonthNo = MonthNo;
                                    CS.Year = CS.ScheduleDate.Year;
                                    CS.Month = CS.ScheduleDate.ToString("MMMM");
                                    CS.ReviewNo = ReviewNo;
                                    if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                    {
                                        CS.AdvanceAdjustmentAmount = AI.AdvanceAdjustmentAmount;
                                    }
                                    //==Fraction Month
                                    if (i == 1)
                                    {
                                        if (RI.StartDate.Day != 1)
                                        {
                                            //==Before Review Amount
                                            MonthDays = DateTime.DaysInMonth(RI.StartDate.Year, RI.StartDate.Month);
                                            RentPerDay = (NewCPU * AI.TotalArea) / MonthDays;
                                            BeforeReviewAmount = (RI.StartDate.Day - 1) * RentPerDay;
                                            //==After Review Amount                                            
                                            if (RI.IncreaseAmount > 0)
                                            {
                                                NewCPU = NewCPU + (RI.IncreaseAmount / AI.TotalArea);
                                            }
                                            else
                                            {
                                                NewCPU = NewCPU + ((NewCPU * RI.IncreasePercentage) / 100);
                                            }
                                            CS.CostPerUnit = NewCPU;
                                            RentPerDay = (CS.CostPerUnit * AI.TotalArea) / MonthDays;
                                            AfterReviewAmount = ((MonthDays - RI.StartDate.Day) + 1) * RentPerDay;
                                            CS.TotalRentAmount = BeforeReviewAmount + AfterReviewAmount;
                                        }
                                        else
                                        {
                                            if (RI.IncreaseAmount > 0)
                                            {
                                                NewCPU = NewCPU + (RI.IncreaseAmount / AI.TotalArea);
                                            }
                                            else
                                            {
                                                NewCPU = NewCPU + ((NewCPU * RI.IncreasePercentage) / 100);
                                            }
                                            CS.CostPerUnit = NewCPU;
                                            CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                        }
                                    }
                                    //==Review Last Month
                                    else if (i == RI.Period)
                                    {
                                        ReviewMonthDaysCount = DateTime.DaysInMonth(RI.EndDate.Year, RI.EndDate.Month);
                                        //==Full Month
                                        if (RI.EndDate.Day != ReviewMonthDaysCount)
                                        {
                                            //==Fraction Date Rent Amount
                                            CS.CostPerUnit = NewCPU;
                                            RentPerDay = (CS.CostPerUnit * AI.TotalArea) / ReviewMonthDaysCount;
                                            CS.TotalRentAmount = RI.EndDate.Day * RentPerDay;
                                        }
                                        else
                                        {
                                            CS.CostPerUnit = NewCPU;
                                            CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                        }
                                    }
                                    else
                                    {
                                        CS.CostPerUnit = NewCPU;
                                        CS.TotalRentAmount = CS.CostPerUnit * AI.TotalArea;
                                    }
                                    #region "Tax Type & VAT Type"
                                    //1. Inclusive Inclusive
                                    if (AI.TaxType == 1 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) * AI.TaxPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //2. Inclusive Exclusive
                                    else if (AI.TaxType == 1 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //3. Inclusive Exempted
                                    else if (AI.TaxType == 1 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount * AI.TaxPercentage) / 100;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //4. Exclusive Inclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - AI.TaxPercentage)) * AI.VATPercentage;
                                        CS.TaxAmount = (CS.TotalRentAmount - CS.VATAmount) / (100 - AI.TaxPercentage) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //5. Exclusive Exclusive
                                    else if (AI.TaxType == 2 && AI.VatType == 2)
                                    {
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        CS.VATAmount = (CS.TotalRentAmount + CS.TaxAmount) * AI.VATPercentage / 100;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //6. Exclusive Exempted
                                    else if (AI.TaxType == 2 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = (CS.TotalRentAmount / (100 - AI.TaxPercentage)) * AI.TaxPercentage;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //7. Exempted  Inclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 1)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount / (100 + AI.VATPercentage - 0)) * AI.VATPercentage;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.VATAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //8. Exempted  Exclusive
                                    else if (AI.TaxType == 3 && AI.VatType == 2)
                                    {
                                        CS.VATAmount = (CS.TotalRentAmount * AI.VATPercentage) / 100;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount - CS.TaxAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    //9. Exempted Exempted
                                    else if (AI.TaxType == 3 && AI.VatType == 3)
                                    {
                                        CS.VATAmount = 0;
                                        CS.TaxAmount = 0;
                                        NetCalcAmount = CS.TotalRentAmount;
                                        CS.TotalRentAmount = CS.VATAmount + CS.TaxAmount + NetCalcAmount;
                                        CS.NetRentAmount = CS.TotalRentAmount - CS.AdvanceAdjustmentAmount;
                                    }
                                    #endregion
                                    CS.UserSLNo = AI.UserSLNo;
                                    CS.EntryDate = DateTime.Now;
                                    db.ContractSchedules.Add(CS);
                                    db.SaveChanges();
                                    //==Landlord Schedule
                                    foreach (RMS.Models.LandlordInfo LI in lstLandlords)
                                    {
                                        LS = new RMS.Models.LandlordSchedule();
                                        LS.ScheduleDate = ScheduleDate;
                                        LS.AgreementSLNo = AI.AgreementSLNo;
                                        LS.LandlordSLNo = LI.LandlordSLNo;
                                        LS.MonthNo = MonthNo;
                                        LS.Year = CS.ScheduleDate.Year;
                                        LS.Month = CS.ScheduleDate.ToString("MMMM");
                                        LS.ReviewNo = ReviewNo;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            LS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * LI.AdvanceAdjustmentPC) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            LS.TaxAmount = (CS.TaxAmount * LI.TaxPC) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            LS.VATAmount = (CS.VATAmount * LI.VATPC) / 100;
                                        }
                                        LS.CostPerUnit = NewCPU;
                                        LS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        LS.NetRentAmount = (LS.TotalRentAmount * LI.RentPC / 100) - LS.AdvanceAdjustmentAmount;
                                        LS.UserSLNo = AI.UserSLNo;
                                        LS.EntryDate = DateTime.Now;
                                        db.LandlordSchedules.Add(LS);
                                        db.SaveChanges();
                                    }
                                    //==Cost Allocation Schedule
                                    foreach (RMS.Models.CostCenterInfo CC in lstCostCenter)
                                    {
                                        CCS = new RMS.Models.CostCenterSchedule();
                                        CCS.ScheduleDate = ScheduleDate;
                                        CCS.AgreementSLNo = AI.AgreementSLNo;
                                        CCS.CCSLNo = CC.CCSLNo;
                                        CCS.MonthNo = MonthNo;
                                        CCS.Year = CS.ScheduleDate.Year;
                                        CCS.Month = CS.ScheduleDate.ToString("MMMM");
                                        CCS.ReviewNo = ReviewNo;
                                        if (MonthNo <= AI.AdvanceAdjustmentPeriod)
                                        {
                                            CCS.AdvanceAdjustmentAmount = (CS.AdvanceAdjustmentAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.TaxAmount > 0)
                                        {
                                            CCS.TaxAmount = (CS.TaxAmount * CC.CCShareAllotment) / 100;
                                        }
                                        if (CS.VATAmount > 0)
                                        {
                                            CCS.VATAmount = (CS.VATAmount * CC.CCShareAllotment) / 100;
                                        }
                                        CCS.CostPerUnit = NewCPU;
                                        CCS.TotalRentAmount = CS.TotalRentAmount;
                                        //==
                                        CCS.NetRentAmount = (CCS.TotalRentAmount * CC.CCShareAllotment / 100) - CCS.AdvanceAdjustmentAmount;
                                        CCS.UserSLNo = AI.UserSLNo;
                                        CCS.EntryDate = DateTime.Now;
                                        db.CostCenterSchedules.Add(CCS);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                    #region Advance Adjustment
                    //==Advance Info Loop
                    DateTime AdvStartDate = DateTime.Now;
                    int AdvYear = 0;
                    string AdvMonthName = String.Empty;
                    double AdvAdjPerDay = 0;
                    double AdvAdjAmount = 0;
                    double AdvanceMonthDaysCount = 0;
                    foreach (RMS.Models.AdvanceInfo AdvInfo in lstAdvanceInfo)
                    {
                        AdvStartDate = AdvInfo.StartDate;
                        for (int i = 1; i <= AdvInfo.AdvanceSlotPeriod; i++)
                        {
                            if (i != 1)
                            {
                                AdvStartDate = AdvStartDate.AddMonths(1);
                            }
                            AdvYear = AdvStartDate.Year;
                            AdvMonthName = AdvStartDate.ToString("MMMM");
                            AdvAdjAmount = AdvInfo.AdvanceSlotAmount;
                            //==Fraction Advance Adjustment
                            //==First Month
                            if (i == 1)
                            {
                                if (AdvStartDate.Day != 1)
                                {
                                    MonthDays = DateTime.DaysInMonth(AdvStartDate.Year, AdvStartDate.Month);
                                    //==Fraction Date Adv Adj Amount
                                    AdvAdjPerDay = AdvInfo.AdvanceSlotAmount / MonthDays;
                                    AdvAdjAmount = ((MonthDays - AdvStartDate.Day) + 1) * AdvAdjPerDay;
                                }
                            }
                            else
                            {
                                //==Last Month
                                if (i == AdvInfo.AdvanceSlotPeriod)
                                {
                                    AdvanceMonthDaysCount = DateTime.DaysInMonth(AdvInfo.EndDate.Year, AdvInfo.EndDate.Month);
                                    if (AdvInfo.EndDate.Day != AdvanceMonthDaysCount)
                                    {
                                        //==Fraction Date Adv Adj Amount
                                        AdvAdjPerDay = AdvInfo.AdvanceSlotAmount / AdvanceMonthDaysCount;
                                        AdvAdjAmount = AdvInfo.EndDate.Day * AdvAdjPerDay;
                                    }
                                }
                            }
                            //==Advance Process Contract Schedule
                            RMS.Models.ContractSchedule GCS = db.ContractSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.Year == AdvYear && x.Month == AdvMonthName).SingleOrDefault();
                            GCS.AdvanceAdjustmentAmount = AdvAdjAmount;
                            GCS.NetRentAmount = GCS.NetRentAmount - GCS.AdvanceAdjustmentAmount;
                            db.Entry(GCS).State = EntityState.Modified;
                            db.SaveChanges();
                            //==Advance Process Landlord Schedule
                            List<RMS.Models.LandlordSchedule> lstGLS = db.LandlordSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.Year == AdvYear && x.Month == AdvMonthName).ToList();
                            foreach (RMS.Models.LandlordSchedule GLS in lstGLS)
                            {
                                var GLandlordInfo = db.LandlordInfos.Where(x => x.AgreementSLNo == AgreementSLNo && x.LandlordSLNo == GLS.LandlordSLNo).Select(x => new { x.AdvanceAdjustmentPC, x.RentPC }).SingleOrDefault();
                                GLS.AdvanceAdjustmentAmount = (GCS.AdvanceAdjustmentAmount * GLandlordInfo.AdvanceAdjustmentPC) / 100;
                                GLS.NetRentAmount = GLS.NetRentAmount - GLS.AdvanceAdjustmentAmount;
                                db.Entry(GLS).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            //==Advance Process Cost Center Schedule
                            double CCSharePC = 0;
                            List<RMS.Models.CostCenterSchedule> lstGCCS = db.CostCenterSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.Year == AdvYear && x.Month == AdvMonthName).ToList();
                            foreach (RMS.Models.CostCenterSchedule GCCS in lstGCCS)
                            {
                                CCSharePC = db.CostCenterInfos.Where(x => x.AgreementSLNo == AgreementSLNo && x.CCSLNo == GCCS.CCSLNo).Select(x => x.CCShareAllotment).SingleOrDefault();
                                GCCS.AdvanceAdjustmentAmount = (GCS.AdvanceAdjustmentAmount * CCSharePC) / 100;
                                GCCS.NetRentAmount = GCCS.NetRentAmount - GCCS.AdvanceAdjustmentAmount;
                                db.Entry(GCCS).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                    #endregion
                    #region Utility Schedule
                    //ScheduleDate = AI.AgreementStartDate.AddMonths(-1);
                    //for (int i = 1; i <= AI.AgreementPeriod; i++)
                    //{
                    //    ScheduleDate = ScheduleDate.AddMonths(1);
                    //    //==Utility Schedule
                    //    foreach (RMS.Models.UtilityInfo UI in lstUtility)
                    //    {
                    //        US = new RMS.Models.UtilitySchedule();
                    //        US.ScheduleDate = ScheduleDate;
                    //        US.AgreementSLNo = AI.AgreementSLNo;
                    //        US.UtilitySLNo = UI.UtilitySLNo;
                    //        US.MonthNo = i;
                    //        US.Year = US.ScheduleDate.Year;
                    //        US.Month = US.ScheduleDate.ToString("MMMM");
                    //        US.ServiceChargeAmount = UI.ServiceChargeAmount;
                    //        US.OnlineTowerAmount = UI.OnlineTowerAmount;
                    //        US.GeneratorSpaceAmount = UI.GeneratorSpaceAmount;
                    //        US.CarParkingAmount = UI.CarParkingAmount;
                    //        US.TaxAmount = UI.TaxAmount;
                    //        US.VATAmount = UI.VATAmount;
                    //        US.UserSLNo = AI.UserSLNo;
                    //        US.EntryDate = DateTime.Now;
                    //        db.UtilitySchedules.Add(US);
                    //        db.SaveChanges();
                    //    }
                    //}
                    #endregion
                    //==IFRS Schedule
                    //==IFRS Schedule
                    if (AI.IsIFRSEnable == true)
                    {
                        List<RMS.Models.ContractSchedule> lstContractSchedule = db.ContractSchedules.Where(x => x.AgreementSLNo == AI.AgreementSLNo).ToList();
                        DateTime IFRSEffectiveDate = Convert.ToDateTime(AI.IFRSEffectiveDate);
                        int IFRSPeriod = AI.AgreementPeriod;
                        ScheduleDate = AI.AgreementStartDate;
                        int IFRS_Start_MonthNo = 1;
                        if (AI.AgreementStartDate != IFRSEffectiveDate)
                        {
                            IFRS_Start_MonthNo = ((IFRSEffectiveDate.Year - AI.AgreementStartDate.Year) * 12 + IFRSEffectiveDate.Month - AI.AgreementStartDate.Month) + 1;
                            IFRSPeriod = (AI.AgreementPeriod - IFRS_Start_MonthNo) + 1;
                            ScheduleDate = IFRSEffectiveDate;
                        }
                        //==Save New Data into BorrowingRateDetails
                        List<RMS.Models.BorrowingRateDetails> lstBRDetails = new List<RMS.Models.BorrowingRateDetails>();
                        RMS.Models.BorrowingRateDetails BRD;
                        for (int i = 1; i <= IFRSPeriod; i++)
                        {
                            BRD = new RMS.Models.BorrowingRateDetails();
                            BRD.MonthNo = i;
                            BRD.Rate = AI.BorrowingRate;
                            BRD.PV1 = Math.Pow(1 / (1 + (AI.BorrowingRate / 100) / 12), i - 1);
                            BRD.PV2 = Math.Pow(1 / (1 + (AI.BorrowingRate / 100) / 12), i);
                            BRD.AgreementSLNo = AgreementSLNo;
                            lstBRDetails.Add(BRD);
                        }
                        db.BorrowingRateDetails.AddRange(lstBRDetails);
                        db.SaveChanges();
                        //==
                        double PaymentAmount = 0;
                        double PV = 0; //Present value
                        double OBLeaseLiability = 0;
                        double CBLeaseLiability = 0;
                        double CBROU = 0;
                        double CBAdvance = 0;
                        double Depreciation = 0;
                        double AdvanceDepreciation = 0;
                        double Rate = AI.BorrowingRate / 100;
                        //==IFRS Schedule finding the OBLeaseLiability by Current Month or Following Month
                        //==Current Month (PV1) Calculation Method
                        if (AI.CalculationMethod == "Current Month")
                        {
                            for (int i = 1; i <= IFRSPeriod; i++)
                            {
                                PaymentAmount = lstContractSchedule.Where(x => x.MonthNo == IFRS_Start_MonthNo).Select(x => x.TotalRentAmount - x.AdvanceAdjustmentAmount - x.VATAmount).SingleOrDefault();
                                PV = lstBRDetails.Where(x => x.MonthNo == i).Select(x => x.PV1).SingleOrDefault();
                                OBLeaseLiability = OBLeaseLiability + (PaymentAmount * PV);
                                IFRS_Start_MonthNo = IFRS_Start_MonthNo + 1;
                            }
                        }
                        //==Following Month (PV2) Calculation Method
                        else if (AI.CalculationMethod == "Following Month")
                        {
                            for (int i = 1; i <= IFRSPeriod; i++)
                            {
                                PaymentAmount = lstContractSchedule.Where(x => x.MonthNo == IFRS_Start_MonthNo).Select(x => x.TotalRentAmount - x.AdvanceAdjustmentAmount - x.VATAmount).SingleOrDefault();
                                PV = lstBRDetails.Where(x => x.MonthNo == i).Select(x => x.PV2).SingleOrDefault();
                                OBLeaseLiability = OBLeaseLiability + (PaymentAmount * PV);
                                IFRS_Start_MonthNo = IFRS_Start_MonthNo + 1;
                            }
                        }
                        IFRS_Start_MonthNo = 1;
                        if (AI.AgreementStartDate != IFRSEffectiveDate)
                        {
                            IFRS_Start_MonthNo = ((IFRSEffectiveDate.Year - AI.AgreementStartDate.Year) * 12 + IFRSEffectiveDate.Month - AI.AgreementStartDate.Month) + 1;
                        }
                        //===IFRS Schedule
                        for (int i = 1; i <= IFRSPeriod; i++)
                        {
                            var ItemContractShecule = lstContractSchedule.Where(x => x.MonthNo == IFRS_Start_MonthNo).SingleOrDefault();
                            IFRS = new RMS.Models.IFRSSchedule();
                            if (i != 1)
                            {
                                ScheduleDate = ScheduleDate.AddMonths(1);
                            }
                            if (i == 1)
                            {
                                //==IFRS Schedule
                                IFRS.ScheduleDate = ScheduleDate;
                                IFRS.AgreementSLNo = AI.AgreementSLNo;
                                IFRS.MonthNo = i;
                                IFRS.Year = IFRS.ScheduleDate.Year;
                                IFRS.Month = IFRS.ScheduleDate.ToString("MMMM");
                                IFRS.ReviewNo = ItemContractShecule.ReviewNo;
                                IFRS.CostPerUnit = ItemContractShecule.CostPerUnit;
                                IFRS.AdvanceAdjustmentAmount = ItemContractShecule.AdvanceAdjustmentAmount;
                                IFRS.PaymentAmount = ItemContractShecule.TotalRentAmount - (ItemContractShecule.AdvanceAdjustmentAmount + ItemContractShecule.VATAmount);
                                //Current Month (PV1) Calculation Method
                                if (AI.CalculationMethod == "Current Month")
                                {
                                    IFRS.DiscountFactor = lstBRDetails.Where(x => x.MonthNo == IFRS.MonthNo).Select(x => x.PV1).SingleOrDefault();
                                }
                                //Following Month (PV2) Calculation Method
                                else if (AI.CalculationMethod == "Following Month")
                                {
                                    IFRS.DiscountFactor = lstBRDetails.Where(x => x.MonthNo == IFRS.MonthNo).Select(x => x.PV2).SingleOrDefault();
                                }
                                IFRS.PresentValue = IFRS.PaymentAmount * IFRS.DiscountFactor;
                                IFRS.OBLeaseLiability = OBLeaseLiability;
                                IFRS.LeasePayment = IFRS.PaymentAmount;
                                //Current Month Interest Expense = 0 only for the 1st Month (Month No = 1)
                                if (AI.CalculationMethod == "Current Month")
                                {
                                    IFRS.InteresetExpense = 0;
                                }
                                else
                                {
                                    IFRS.InteresetExpense = IFRS.OBLeaseLiability * Rate / 12;
                                }
                                IFRS.SettlementofLeaseLiabilities = IFRS.LeasePayment - IFRS.InteresetExpense;
                                IFRS.CBLeaseLiability = IFRS.OBLeaseLiability - IFRS.SettlementofLeaseLiabilities;
                                CBLeaseLiability = IFRS.CBLeaseLiability;

                                IFRS.OBROU = IFRS.OBLeaseLiability;
                                IFRS.Depreciation = IFRS.OBROU / IFRSPeriod;
                                Depreciation = IFRS.Depreciation;
                                IFRS.CBROU = IFRS.OBROU - IFRS.Depreciation;
                                CBROU = IFRS.CBROU;

                                //== Advance
                                IFRS.OBAdvance = AI.AdvanceAmount;
                                IFRS.AdvanceDepreciation = IFRS.OBAdvance / IFRSPeriod;
                                AdvanceDepreciation = IFRS.AdvanceDepreciation;
                                IFRS.CBAdvance = IFRS.OBAdvance - IFRS.AdvanceDepreciation;
                                CBAdvance = IFRS.CBAdvance;

                                IFRS.UserSLNo = AI.UserSLNo;
                                IFRS.EntryDate = DateTime.Now;
                                db.IFRSSchedules.Add(IFRS);
                                db.SaveChanges();
                                IFRS_Start_MonthNo = IFRS_Start_MonthNo + 1;
                            }
                            else
                            {
                                //==IFRS Schedule
                                IFRS.ScheduleDate = ScheduleDate;
                                IFRS.AgreementSLNo = AI.AgreementSLNo;
                                IFRS.MonthNo = i;
                                IFRS.Year = IFRS.ScheduleDate.Year;
                                IFRS.Month = IFRS.ScheduleDate.ToString("MMMM");
                                IFRS.ReviewNo = ItemContractShecule.ReviewNo;
                                IFRS.CostPerUnit = ItemContractShecule.CostPerUnit;
                                IFRS.AdvanceAdjustmentAmount = ItemContractShecule.AdvanceAdjustmentAmount;
                                IFRS.PaymentAmount = ItemContractShecule.TotalRentAmount - (ItemContractShecule.AdvanceAdjustmentAmount + ItemContractShecule.VATAmount);
                                //Current Month (PV1) Calculation Method
                                if (AI.CalculationMethod == "Current Month")
                                {
                                    IFRS.DiscountFactor = lstBRDetails.Where(x => x.MonthNo == IFRS.MonthNo).Select(x => x.PV1).SingleOrDefault();
                                }
                                //Following Month (PV2) Calculation Method
                                else if (AI.CalculationMethod == "Following Month")
                                {
                                    IFRS.DiscountFactor = lstBRDetails.Where(x => x.MonthNo == IFRS.MonthNo).Select(x => x.PV2).SingleOrDefault();
                                }
                                IFRS.PresentValue = IFRS.PaymentAmount * IFRS.DiscountFactor;
                                IFRS.OBLeaseLiability = CBLeaseLiability;
                                IFRS.LeasePayment = IFRS.PaymentAmount;
                                IFRS.InteresetExpense = IFRS.OBLeaseLiability * Rate / 12;
                                IFRS.SettlementofLeaseLiabilities = IFRS.LeasePayment - IFRS.InteresetExpense;
                                IFRS.CBLeaseLiability = IFRS.OBLeaseLiability - IFRS.SettlementofLeaseLiabilities;
                                CBLeaseLiability = IFRS.CBLeaseLiability;

                                IFRS.OBROU = CBROU;
                                IFRS.Depreciation = Depreciation;
                                Depreciation = IFRS.Depreciation;
                                IFRS.CBROU = IFRS.OBROU - IFRS.Depreciation;
                                CBROU = IFRS.CBROU;

                                //== Advance
                                IFRS.OBAdvance = CBAdvance;
                                IFRS.AdvanceDepreciation = AdvanceDepreciation;
                                AdvanceDepreciation = IFRS.AdvanceDepreciation;
                                IFRS.CBAdvance = IFRS.OBAdvance - IFRS.AdvanceDepreciation;
                                CBAdvance = IFRS.CBAdvance;

                                IFRS.UserSLNo = AI.UserSLNo;
                                IFRS.EntryDate = DateTime.Now;
                                db.IFRSSchedules.Add(IFRS);
                                db.SaveChanges();
                                IFRS_Start_MonthNo = IFRS_Start_MonthNo + 1;
                            }
                        }
                        //==
                    }
                    //==End IFRS Schedule
                    //==================================
                    //==Posted Schedule
                    List<RMS.Models.DM_AgreementInfo> lstDM_AI = db.DM_AgreementInfos.Where(x => x.AgreementCode == itemMaster_AI.AgreementText).ToList();
                    int PostedMonths = lstDM_AI.GroupBy(x => x.AgreementCode).Select(x => x.First().PostedMonths).Distinct().SingleOrDefault();
                    //==================================
                    if (PostedMonths > 0)
                    {
                        //==Contract Schedule
                        List<RMS.Models.ContractSchedule> lstMaster_CS = db.ContractSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo >= 1 && x.MonthNo <= PostedMonths).ToList();
                        lstMaster_CS.ForEach(x =>
                        {
                            x.IsPosted = true;
                            x.PostingID = "123";
                            x.PostingDate = Convert.ToDateTime("01/01/2021");
                            x.PostingUserSLNo = 1;
                            x.IsPJPosted = true;
                            x.PJPostingID = "456";
                            x.PJPostingDate = Convert.ToDateTime("01/01/2021");
                            x.PJPostingUserSLNo = 1;
                        });
                        db.SaveChanges();
                        //==Landlord Schedule
                        List<RMS.Models.LandlordSchedule> lstMaster_LI = db.LandlordSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo >= 1 && x.MonthNo <= PostedMonths).ToList();
                        lstMaster_LI.ForEach(x =>
                        {
                            x.IsPosted = true;
                            x.PostingID = "123";
                            x.PostingDate = Convert.ToDateTime("01/01/2021");
                            x.PostingUserSLNo = 1;
                            x.IsPJPosted = true;
                            x.PJPostingID = "456";
                            x.PJPostingDate = Convert.ToDateTime("01/01/2021");
                            x.PJPostingUserSLNo = 1;
                        });
                        db.SaveChanges();
                        //==CostCenter Schedule
                        List<RMS.Models.CostCenterSchedule> lstMaster_CC = db.CostCenterSchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo >= 1 && x.MonthNo <= PostedMonths).ToList();
                        lstMaster_CC.ForEach(x =>
                        {
                            x.IsPosted = true;
                            x.PostingID = "123";
                            x.PostingDate = Convert.ToDateTime("01/01/2021");
                            x.PostingUserSLNo = 1;
                            x.IsPJPosted = true;
                            x.PJPostingID = "456";
                            x.PJPostingDate = Convert.ToDateTime("01/01/2021");
                            x.PJPostingUserSLNo = 1;
                        });
                        db.SaveChanges();
                        //==Utility Schedule
                        //List<RMS.Models.UtilitySchedule> lstMaster_UI = db.UtilitySchedules.Where(x => x.AgreementSLNo == AgreementSLNo && x.MonthNo >= 1 && x.MonthNo <= PostedMonths).ToList();
                        //lstMaster_UI.ForEach(x =>
                        //{
                        //    x.IsPosted = true;
                        //    x.PostingID = "123";
                        //    x.PostingDate = Convert.ToDateTime("01/01/2021");
                        //    x.PostingUserSLNo = 1;
                        //    x.IsPJPosted = true;
                        //    x.PJPostingID = "456";
                        //    x.PJPostingDate = Convert.ToDateTime("01/01/2021");
                        //    x.PJPostingUserSLNo = 1;
                        //});
                        //db.SaveChanges();
                    }
                    //==================================
                }
                //==
                return Json(new { CheckStatus = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ViewBag.Message = Ex.ToString();
                return View(HomePath.DisplayMessage);
            }
        }

        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public sealed class ValidateHeaderAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                var httpContext = filterContext.HttpContext;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
            }
        }
    }
}
