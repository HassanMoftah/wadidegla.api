using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wadidegla.viewmodels.CustomValidators;

namespace Wadidegla.viewmodels.ViewModels
{
    public class VMAddCategory
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [IsValidParent]
        public int ParentId { get; set; }

    }
}
