using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Teacher
    {
        public Teacher()
        {
            TeachersClasses = new List<TeachersClasses>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }
        public int TeacherTypeId { get; set; }
        public int SchoolId { get; set; }

        [Display(Name = "Характеристика")]
        public string Characteristics { get; set; }

        public virtual TeacherType TeacherType { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<TeachersClasses> TeachersClasses { get; set; }

    }
}
