﻿using System.Collections.Generic;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.DataAccess.Entities
{
    public class Watch
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Diameter { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Gender Gender { get; set; }
        public int CountInStock { get; set; }
        public int SaledCount { get; set; }
        
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int GlassMaterialId { get; set; }
        public virtual GlassMaterial GlassMaterial { get; set; }
        public int MechanismId { get; set; }
        public virtual Mechanism Mechanism { get; set; }
        public int BodyMaterialId { get; set; }
        public virtual BodyMaterial BodyMaterial { get; set; }
        public int StrapId { get; set; }
        public virtual Strap Strap { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
