using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StudentHelper api = new StudentHelper();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ---------------- Index ----------------
        public async Task<IActionResult> Index()
        {
            List<StudentData> students = new List<StudentData>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/student");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentData>>(results);
            }

            return View(students);
        }

        // ---------------- Details ----------------
        public async Task<IActionResult> Details(int Id)
        {
            StudentData student = new StudentData();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/student/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(results);
            }

            return View(student);
        }

        // ---------------- Create ----------------
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentData student)
        {
            HttpClient client = api.Initial();

            //HTTP Post
            var postTask = client.PostAsJsonAsync<StudentData>("api/student", student);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        // ---------------- Edit ----------------
        public async Task<IActionResult> Edit(int Id)
        {
            StudentData student = new StudentData();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/student/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(results);
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentData student)
        {
            HttpClient client = api.Initial();

            //HTTP Post
            var putTask = client.PutAsJsonAsync<StudentData>("api/student", student);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        // ---------------- Delete ----------------
        public async Task<IActionResult> Delete(int Id)
        {
            StudentData student = new StudentData();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/student/{Id}");

            return RedirectToAction("Index");
        }

        // ----------------------------------------------------------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
