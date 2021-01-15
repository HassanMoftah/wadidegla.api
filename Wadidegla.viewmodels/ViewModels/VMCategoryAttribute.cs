using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wadidegla.viewmodels.CustomValidators;

namespace Wadidegla.viewmodels.ViewModels
{
    public class VMCategoryAttribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [IsValidType]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
