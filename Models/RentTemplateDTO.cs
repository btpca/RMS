using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RMS.Models
{
    public class RentTemplateDTO
    {
        public string Upl { get; set; }
        public int RecordNo { get; set; }
        public string InvoiceNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double InvoiceAmount { get; set; }

        public string InvoiceDate { get; set; }
        public string VendorCode { get; set; }
        public string LandlordName { get; set; }
        public string PremisesTypeforAccounts { get; set; }
        public string InvoiceType { get; set; }
        public string Requestor { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentMethod { get; set; }
        public string GLDate { get; set; }
        public string InvoiceDescription { get; set; }
        public string VATChallanNo { get; set; }
        public string ChallanDate { get; set; }
        public string VATAmountInMushak { get; set; }
        public string VatableAmount { get; set; }
        public string LineType { get; set; }
        public string FADSLNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double CCAmount { get; set; }

        public string LineDescription { get; set; }
        public string GLCode { get; set; }
        public string SOLCode { get; set; }
        public string CCCode1 { get; set; }
        public string CCCode2 { get; set; }
        public string VATTaxCode { get; set; }
        public string PaymentWithholdingGroupName { get; set; }
        public string WithHoldingCode { get; set; }
        public string TrainingName { get; set; }
        public string Messages { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double TotalInvoice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AdvanceAdjustment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double VATAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double TaxAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double NetPayment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double RemainingAdvance { get; set; }

        public int AgreementSLNo { get; set; }
    }
}

