using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Характеристика")]
        public string Characteristics { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
