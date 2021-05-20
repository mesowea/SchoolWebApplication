using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Class
    {
        public Class()
        {
            TeachersClasses = new List<TeachersClasses>();
            Students = new List<Student>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Рік навчання")]
        public int Grade { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Літера класу")]
        public string Letter { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Аудиторія")]
        public string Room { get; set; }

        public virtual ICollection<TeachersClasses> TeachersClasses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
