using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class City
    {
        public City()
        {
            Schools = new List<School>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name ="Назва")]
        public string Name { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
