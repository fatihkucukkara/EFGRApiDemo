using EFGRApiDemo.Core.Domain;
using System.Collections.Generic;

namespace EFGRApiDemo.Implementation
{
    public interface ISchoolService
    {
        IEnumerable<Student> GetAllStudents();
        int AddStudent(Student student);
        Student GetStudentById(int Id);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
