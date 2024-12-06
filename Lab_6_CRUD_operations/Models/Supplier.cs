using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Lab_6_CRUD_operations.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Номер_поставщика")]
        public int SupplierId { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("Название_поставщика")]
        public string SupplierName { get; set; }

        [MaxLength(255)]
        [Column("Адрес_поставщика")]
        public string SupplierAdress { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }



}
