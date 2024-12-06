using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_6_CRUD_operations.Models
{

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Идентификатор_товара")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("Department")]
        [Column("Номер_отдела")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Column("Цена")]
        public decimal Price { get; set; }
        [Column("Количество")]
        public int Quantity { get; set; }
        [Column("Срок_годности")]
        public DateTime? ExpiredDate { get; set; }
        [Column("Дата_поставки")]
        public DateTime? ArrivalDate { get; set; }

        [ForeignKey("Supplier")]
        [Column("Номер_поставщика")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

}
