using EFGRApiDemo.Core.Domain;
using EFGRApiDemo.Dal.Base.Interfaces;
using System.Collections.Generic;

namespace EFGRApiDemo.Implementation
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<Student> _studentRepository;
        public SchoolService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public int AddStudent(Student student)
        {
            return _studentRepository.Insert(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.Table;
        }

        public Student GetStudentById(int id)
        {

            //var s = (from st in _studentRepository.Table
            //         select st).FirstOrDefault();

            return _studentRepository.GetById(id);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
