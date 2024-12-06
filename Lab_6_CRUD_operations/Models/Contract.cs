using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_6_CRUD_operations.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Номер_договора")]
        public int ContractId { get; set; }

        [Required]
        [Column("Дата")]
        public DateTime? Date { get; set; }

        [ForeignKey("Supplier")]
        [Column("Номер_поставщика")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

}
