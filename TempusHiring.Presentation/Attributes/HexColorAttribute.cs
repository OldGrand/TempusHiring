﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TempusHiring.Presentation.Attributes
{
    public class HexColorAttribute : ValidationAttribute
    {
        private string _errorMessage;

        public HexColorAttribute(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var colorHexStr = (string)value;
            var valid = Regex.IsMatch(colorHexStr, "#[0-9a-fA-F]{6}");
            if (valid)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(_errorMessage);
        }
    }
}
