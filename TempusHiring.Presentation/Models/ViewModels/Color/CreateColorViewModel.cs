﻿using System.ComponentModel.DataAnnotations;
using TempusHiring.Presentation.Attributes;
using TempusHiring.Presentation.Constants;

namespace TempusHiring.Presentation.Models.ViewModels.Color
{
    public class CreateColorViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [HexColor(ValidationAtrributesMessages.HexAttributeMessage)]
        public string Hex { get; set; }
    }
}
