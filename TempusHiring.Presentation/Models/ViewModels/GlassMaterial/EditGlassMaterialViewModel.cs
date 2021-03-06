﻿using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.GlassMaterial
{
    public class EditGlassMaterialViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
