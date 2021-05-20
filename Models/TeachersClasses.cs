using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApplication.Models
{
    public class TeachersClasses
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Class Class { get; set; }
    }
}
