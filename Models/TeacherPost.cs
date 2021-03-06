using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApplication.Models
{
    public class TeacherPost
    {
        public TeacherPost()
        {
            Teachers = new List<Teacher>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
