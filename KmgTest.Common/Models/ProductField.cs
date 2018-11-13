using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestKmg.Common.Models
{
    public class ProductField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [ForeignKey("Field")]
        public int FieldId { get; set; }
        public string Value { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
        public virtual Field Fields { get; set; }
    }
}
