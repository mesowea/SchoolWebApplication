using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApplication.Models
{
    public class SchoolType 
    {
        public SchoolType()
        {
            Schools = new List<School>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}
