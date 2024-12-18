using Microsoft.AspNetCore.Mvc;
using Lab_6_CRUD_operations.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_6_CRUD_operations.Models
{

    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Номер_отдела")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Название_отдела")]
        public string DepartmentName { get; set; }

        [ForeignKey("Store")]
        [Column("Номер_магазина")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Column("Табельный_номер_заведующего")]
        public int? DirectorId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Product> Products { get; set; }



    }


}
