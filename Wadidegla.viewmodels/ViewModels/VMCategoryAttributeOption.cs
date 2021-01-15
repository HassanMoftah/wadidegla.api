using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wadidegla.viewmodels.CustomValidators;

namespace Wadidegla.viewmodels.ViewModels
{
    public  class VMCategoryAttributeOption
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        [IsOptionsOrMultiLineCategoryAttribute]
        public int CategoryAttributeId { get; set; }
    }
}
