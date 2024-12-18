using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_6_CRUD_operations.Models
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Номер_магазина")]
        public int StoreId { get; set; }
        [Required]
        [Column("Название_магазина")]
        [MaxLength(100)]
        public string StoreName { get; set; }
        [Column("Специализация")]
        [MaxLength(100)]
        public string Specialization { get; set; }
        [Column("ИНН")]
        [MaxLength(20)]
        [Range(1000000000, 9999999999)]
        public string INN { get; set; }
        [Column("Адрес")]
        [MaxLength(255)]
        public string Address { get; set; }
        [Column("Табельный_номер_директора")]
        public int DirectorId { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }

}
