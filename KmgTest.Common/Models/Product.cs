using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestKmg.Common.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NameKaz { get; set; }
        [Required]
        public string NameRus { get; set; }
        [Required]
        public string DescriptionRus { get; set; }
        [Required]
        public string DescriptionKaz { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [InverseProperty("Product")]
        public virtual List<ProductField> Fields { get; set; }
        public virtual ProductGroup Group { get; set; }
    }
}
