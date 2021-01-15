using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wadidegla.DataLayer.Models
{
    public class TbCategoryAttribute
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(MAX)")]
       
        public string Name { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int CategoryId { get; set; }
        public virtual TbCategory Category { get; set; }

        public virtual List<TbCategoryAttributeOption> CategoryAttributeOptions { get; set; }

        public virtual List<TbProductAttribute> ProductAttributes { get; set; }


    }
}
