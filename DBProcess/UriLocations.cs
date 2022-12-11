
namespace RMS.DBProcess
{
    public class UriLocations
    {
        //===Production Server - SBP Sub Domain - 204.93.178.39
        //public string baseUri = "http://www.rms.btp-inc.ca/";
        //public string baseUri = "http://www.btp-inc.ca/";
        //public string baseUri = "https://rms.thecitybank.com/";

        //===VS.Net IDE Default Applicaiton Host IIS
        //public string baseUri = "https://localhost:44335/";

        //==CBL Server
        //public string baseUri = "http://10.10.115.51/";
        //public string baseUri = "http://192.168.100.159/";
        //public string baseUri = "http://192.168.100.159:8093/";

        //===Local PC Host IIS
        //public string baseUri = "http://192.168.0.141/";
        //public string baseUri = "http://localhost/";

        public string baseRedirection = "index";
        public string requestFromatToApi = "application/json";
    }

    public class UserInfoLocation
    {
        public string UserInfoApi = "api/UserInfoApi/";
        public string UserInfoMvc = "UserInfo";
    }

    public class AgreementInfoLocation
    {
        public string AgreementInfoApi = "api/AgreementInfoApi/";
        public string AgreementInfoMvc = "AgreementInfo";
    }

    public class DMInfoLocation
    {
        public string DMInfoMvc = "DMInfo";
    }

    public class DTOBasic
    {
        public int active = 1;
        public int InActive = 0;
    }

    public class DebitCredit
    {
        public int Debit = 1;
        public int Credit = 2;
    }

    public class AgreementStatus
    {
        public int Created = 1;
        public int Activate = 2;
    }

    public class AgreementType
    {
        public int Regular = 1;
        public int Renewal = 2;
        public int Modified = 3;
    }
    public class ModeOfPaymentLocation
    {
        public int AccountTransfer = 1;
        public int RTGS = 2;
        public int EFTN = 3;
        public int PayOrder = 4;
        public int Cash = 5;
        public int IBBPayment = 6;
        public int CityBrokerage = 7;
        public int CityCapital = 8;
        public int Others = 9;

        public string strAccountTransfer = "Account Transfer";
        public string strRTGS = "RTGS";
        public string strEFTN = "EFTN";
        public string strPayOrder = "Pay Order";
        public string strCash = "Cash";
        public string strIBBPayment = "IBB Payment";
        public string strCityBrokerage = "City Brokerage";
        public string strCityCapital = "City Capital";
        public string strOthers = "Others";
    }

    public class AgreementUOM
    {
        public int SquareFeetValue = 1;
        public string SquareFeetText = "Square Feet";

        public int SquareMeterValue = 2;
        public string SquareMeterText = "Square Meter";
    }

    public class TaxVatType
    {
        public int InclusiveValue = 1;
        public string InclusiveText = "Inclusive";

        public int ExclusiveValue = 2;
        public string ExclusiveText = "Exclusive";
    }

    public class UserPermissionMessage
    {
        public string AccessDenied = "You do not have permission to execute this transaction!";
    }

}