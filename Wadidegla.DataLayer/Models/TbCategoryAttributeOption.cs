using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wadidegla.DataLayer.Models
{
    public class TbCategoryAttributeOption
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="NVARCHAR(MAX)")]
        public string Value { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int CategoryAttributeId { get; set; }
        public virtual TbCategoryAttribute CategoryAttribute { get; set; }
    }
}
