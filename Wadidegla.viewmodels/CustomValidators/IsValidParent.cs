using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.viewmodels.CustomValidators
{
    public class IsValidParent: ValidationAttribute
    {
       
        private  IUnitOfWork unitOfWork;
      
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var validationres = new ValidationResult("Not Valid Parent");
            unitOfWork = (IUnitOfWork)validationContext
                         .GetService(typeof(IUnitOfWork));
            int parentid = (int)value;
            if (parentid == 0) return ValidationResult.Success;
            else
            {
                var category = unitOfWork.Categories.Get(parentid);
                if (category == null) { return validationres; }
            }
            return ValidationResult.Success;
           
            
        }
    }
}
