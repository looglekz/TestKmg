using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestKmg.Common.Models
{
    public class ProductGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NameKaz { get; set; }
        [Required]
        public string NameRus { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [InverseProperty("Group")]
        public virtual List<Product> Products { get; set; }
    }
}
