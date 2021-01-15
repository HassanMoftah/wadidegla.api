using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wadidegla.DataLayer.Models
{
    public class TbProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }
        [ForeignKey("Id")]
        [Required]
        public int CategoryId { get; set; }
        public virtual TbCategory Category { get; set; }
        
        public int DefaultProductImageId { get; set; }
       
        public virtual List<TbProductImage> ProductImages { get; set; }

        public virtual List<TbProductAttribute> ProductAttributes { get; set; }


    }
}
