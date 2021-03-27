using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private Context context;
        public StudentController(Context context)
        {
            this.context = context;
        }

        // Get All Students
        [HttpGet]
        public List<Student> Get()
        {
            return context.Students.ToList();
        }

        // Get Single Student
        [HttpGet("{Id}")]
        public Student GetStudent(int Id)
        {
            var student = context.Students.Where(a => a.Id == Id).FirstOrDefault();
            return student;
        }

        // Save Single Student
        [HttpPost]
        public IActionResult PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            context.Students.Add(student);
            context.SaveChanges();

            return Ok("The student is saved successfully!");
        }

        // Save Single Student
        [HttpPut]
        public IActionResult PutStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            Student currentStudent = context.Students.Find(student.Id);
            currentStudent.Name = student.Name;

            context.SaveChanges();

            return Ok("The student is saved successfully!");
        }

        // Delete Single Student
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
