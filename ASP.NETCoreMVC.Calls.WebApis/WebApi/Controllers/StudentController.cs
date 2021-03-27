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
    }
}
