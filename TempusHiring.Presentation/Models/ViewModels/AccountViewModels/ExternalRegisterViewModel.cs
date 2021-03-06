﻿using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.AccountViewModels
{
    public class ExternalRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
