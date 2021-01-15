using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.viewmodels.CustomValidators
{
    public class IsValidType: ValidationAttribute
    {
        private IUnitOfWork unitOfWork;
        private static readonly List<string> Types = new List<string> { "Text", "Options", "Multiline", "Yes/No" };
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationres = new ValidationResult("Not Valid Type");
            unitOfWork = (IUnitOfWork)validationContext
                         .GetService(typeof(IUnitOfWork));
            string type = (string)value;
            var found = Types.Where(x => x == type).SingleOrDefault();
            if (found == null) { return validationres; }
            
            return ValidationResult.Success;


        }
    }
}
