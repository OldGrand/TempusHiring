﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Watch
{
    public class CreateWatchViewModel
    {
        [Range(20, double.MaxValue)]
        public double Diameter { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(64)]
        public string Description { get; set; }

        [Required]
        [MaxLength(128)]
        public string PreviewPhoto { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int CountInStock { get; set; }

        [Range(0, int.MaxValue)]
        public int SaledCount { get; set; }


        public Gender Gender { get; set; }

        public SelectList Manufacturers { get; set; }
        public int ManufacturerId { get; set; }

        public SelectList GlassMaterials { get; set; }
        public int GlassMaterialId { get; set; }

        public SelectList Mechanisms { get; set; }
        public int MechanismId { get; set; }

        public SelectList BodyMaterials { get; set; }
        public int BodyMaterialId { get; set; }

        public SelectList Straps { get; set; }
        public int StrapId { get; set; }

        public ICollection<PhotoViewModel> Photos { get; set; }
    }
}
