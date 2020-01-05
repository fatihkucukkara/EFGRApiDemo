using EFGRApiDemo.Core.Domain;
using EFGRApiDemo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFGRApiDemo.Controllers
{
    public class StudentController : ApiController
    {
        private readonly ISchoolService _schoolService;
        public StudentController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        // GET api/student
        //public IEnumerable<Student> Get()
        //{
        //    var sList = _schoolService.GetAllStudents();
        //    return sList;
        //}

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            var sList = _schoolService.GetAllStudents();
            if (sList.Any())
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sList);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }

        // GET api/values/5
        //[Route("api/GetStudents")]        
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            var student = _schoolService.GetStudentById(id);

            if (student != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, student);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }

        public HttpResponseMessage Post([FromBody]Student student)
        {
            HttpResponseMessage response;
            var id = _schoolService.AddStudent(student);

            if (id != 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, id);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public HttpResponseMessage Put([FromBody]Student student)
        {
            HttpResponseMessage response;
            _schoolService.UpdateStudent(student);
            response = Request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }

        public HttpResponseMessage Delete([FromBody]Student student)
        {
            HttpResponseMessage response;
            _schoolService.DeleteStudent(student);
            response = Request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }
    }
}
