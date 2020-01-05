using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EFGRApiDemo.Core.Domain
{
    public class StudentCourseRel
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Key, Column(Order = 1)]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
