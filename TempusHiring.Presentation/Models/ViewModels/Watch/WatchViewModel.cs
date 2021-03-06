﻿using System.Collections.Generic;
using TempusHiring.DataAccess.EntityEnums;
using TempusHiring.Presentation.Models.ViewModels.BodyMaterial;
using TempusHiring.Presentation.Models.ViewModels.GlassMaterial;
using TempusHiring.Presentation.Models.ViewModels.Manufacturer;
using TempusHiring.Presentation.Models.ViewModels.Mechanism;
using TempusHiring.Presentation.Models.ViewModels.Strap;

namespace TempusHiring.Presentation.Models.ViewModels.Watch
{
    public class WatchViewModel
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Description { get; set; }
        public string PreviewPhoto { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public int CountInStock { get; set; }
        public int SaledCount { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
        public int GlassMaterialId { get; set; }
        public GlassMaterialViewModel GlassMaterial { get; set; }
        public int MechanismId { get; set; }
        public MechanismViewModel Mechanism { get; set; }
        public int BodyMaterialId { get; set; }
        public BodyMaterialViewModel BodyMaterial { get; set; }
        public int StrapId { get; set; }
        public StrapViewModel Strap { get; set; }
        public ICollection<PhotoViewModel> Photos { get; set; }
    }
}
