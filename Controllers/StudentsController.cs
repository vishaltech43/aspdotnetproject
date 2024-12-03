using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class StudentsController : Controller
    {

        [HttpGet("Student/Create")]
        public ViewResult CreateView()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "None", Value = "1" },
                new SelectListItem { Text = "CSE", Value = "2" },
                new SelectListItem { Text = "ETC", Value = "3" },
                new SelectListItem { Text = "Mech", Value = "4" }
            };
            // Assuming you have a list of hobbies to choose from
            ViewBag.Hobbies = new List<string> { "Reading", "Swimming", "Painting", "Cycling", "Hiking" };
            return View();
        }
        [HttpPost("Student/Create")]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Successful");
            }
            else
            {
                ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                ViewBag.AllBranches = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "None", Value = "1" },
                    new SelectListItem { Text = "CSE", Value = "2" },
                    new SelectListItem { Text = "ETC", Value = "3" },
                    new SelectListItem { Text = "Mech", Value = "4" }
                };
                //List of hobbies to choose from
                ViewBag.Hobbies = new List<string> { "Reading", "Swimming", "Painting", "Cycling", "Hiking" };
                return View(student);
            }
        }
        public string Successful()
        {
            return "Student Created Successfully";
        }
    }
}
