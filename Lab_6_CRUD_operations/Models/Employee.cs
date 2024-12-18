using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_6_CRUD_operations.Models
{

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Табельный_номер_сотрудника")]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Фамилия")]
        public string Surname { get; set; }

        [MaxLength(50)]
        [Column("Имя")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Column("Отчество")]
        public string Otchestvo { get; set; }

        [MaxLength(255)]
        [Column("Адрес")]
        public string Address { get; set; }

        [MaxLength(50)]
        [Column("Пол_семейное_положение")]
        [RegularExpression(@"^(female|male)$", ErrorMessage = "Значение должно быть 'Муж' или 'Жен'")]
        public string Gender { get; set; }

        [Column("Дата_рождения")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2025", ErrorMessage = "Дата рождения должна быть в пределах с 01.01.1900 по 01.01.2025")]
        public DateTime? DateOfBirth { get; set; }

        [ForeignKey("Department")]
        [Column("Номер_отдела")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }


}
