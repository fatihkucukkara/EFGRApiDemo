using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFGRApiDemo.Core.Domain
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
