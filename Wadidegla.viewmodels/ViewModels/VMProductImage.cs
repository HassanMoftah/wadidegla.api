using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wadidegla.viewmodels.ViewModels
{
    public class VMProductImage
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        public string Extension { get; set; }
    }
}
