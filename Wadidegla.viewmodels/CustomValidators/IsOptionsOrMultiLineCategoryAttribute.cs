using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.viewmodels.CustomValidators
{
    public class IsOptionsOrMultiLineCategoryAttribute: ValidationAttribute
    {
        private IUnitOfWork unitOfWork;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationres = new ValidationResult("Not Valid Category Attribute Type");
            unitOfWork = (IUnitOfWork)validationContext
                         .GetService(typeof(IUnitOfWork));
            int categoryattributeId = (int)value;
            if (categoryattributeId == 0) return validationres;
            else
            {
                var categoryAttribute = unitOfWork.CategoryAttributes.Get(categoryattributeId);
                if (categoryAttribute == null||categoryAttribute.Type=="Yes/No"||
                    categoryAttribute.Type == "Text") { return validationres; }
            }
            return ValidationResult.Success;


        }
    }
}
