using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFGRApiDemo.Core.Domain
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
