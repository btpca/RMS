using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Models
{
    public class ForgotPasswordViewModelDTO
    {
        [DisplayName("Email")]
        public string Email { get; set; }

        public string baseUri { get; set; }
    }
}