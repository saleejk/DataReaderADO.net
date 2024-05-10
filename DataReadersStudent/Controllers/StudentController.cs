using DataReadersStudent.Model;
using DataReadersStudent.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataReadersStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _istudent;
        public StudentController(IStudent student)
        {
            _istudent = student;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_istudent.GetAllStudents());
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_istudent.GetStudent(id));
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _istudent.AddStudent(student);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStudent(int id,Student student)
        {
            _istudent.UpdateStudent(id,student);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _istudent.DeleteStudent(id);
            return Ok();
        }
    }
}
