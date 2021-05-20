using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class School
    {
        public School()
        {
            Teachers = new List<Teacher>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int SchoolTypeId { get; set; }
        public int CityId { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Адреса")]
        public string Address { get; set; }

        public virtual SchoolType SchoolType { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
