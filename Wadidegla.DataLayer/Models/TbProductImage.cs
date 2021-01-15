using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wadidegla.DataLayer.Models
{
    public class TbProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int ProductId { get; set; }
        [Column(TypeName ="NVARCHAR(50)")]
        
        public string Extension { get; set; }
        public virtual TbProduct Product { get; set; }
    }
}
