using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wadidegla.viewmodels.ViewModels
{
    public class VMProduct

    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
        public int DefaultProductImageId { get; set; }
    }
}
