using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [Route("EmployeeList")]
        [ValidateModelStateFilter]
        public ActionResult EmployeeList(string jobTitle, string employeeType, string salaryOrder, string dateOrder)
        {
            var employees = EmployeeBusinessLayer.Filter(jobTitle, employeeType, salaryOrder,dateOrder);
            return View(employees);
        }

        [Route("CreateEmployee")]
        public ActionResult EmployeeForm()
        {
          
            return View();
        }
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateEmployee")]
    
        public ActionResult EmployeeForm([FromForm] Employee employee)
        {
         
                EmployeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Success");
          
        }


        [Route("Delete")]
        public ActionResult DeleteEmployees(int id)
        {
            EmployeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("EmployeeList");
        }
        //custom binding https://localhost:7249/Delete2?Ids=1,2,3

        [Route("Delete2")]
        public ActionResult DeleteEmployees([ModelBinder(typeof(CommaSeparatedModelBinder))] List<int> Ids)
        {
            EmployeeBusinessLayer.DeleteEmployee2(Ids);
            return RedirectToAction("EmployeeList");
        }
        [HttpPost]
        public IActionResult FilterEmployees(string jobTitle, string employeeType, string salaryOrder, string dateOrder)
        {
            var employees = EmployeeBusinessLayer.Filter(jobTitle, employeeType, salaryOrder, dateOrder);
            return RedirectToAction("EmployeeList", new { jobTitle, employeeType, salaryOrder, dateOrder });
        }


        //FromRoute example....https://localhost:7249/Mern stack/Part Time/desc/asc
        [Route("{jobtitle}/{employeeType}/{salaryOrder}/{dateOrder}")]
        public IActionResult FilterEmployeess([FromRoute] string jobTitle, string employeeType, string salaryOrder, string dateOrder)
        {
           
            var employees = EmployeeBusinessLayer.Filter(jobTitle, employeeType, salaryOrder, dateOrder);
            return RedirectToAction("EmployeeList", new { jobTitle, employeeType, salaryOrder, dateOrder });
        }


        [Route("query")]
        public ActionResult GetQuery([FromQuery] string myname)
        {
            return Content("name is my " + myname);
        }


        //action for name validation...

       

    }
}

