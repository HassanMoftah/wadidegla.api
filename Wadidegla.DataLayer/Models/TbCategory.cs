using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wadidegla.DataLayer.Models
{
    public class TbCategory
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int ParentId { get; set; }
        public virtual List<TbCategoryAttribute> CategoryAttributes { get; set; }
        public virtual List<TbProduct> Products { get; set; }


    }
}
