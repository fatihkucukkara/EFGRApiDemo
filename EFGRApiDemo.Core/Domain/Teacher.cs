using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFGRApiDemo.Core.Domain
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
