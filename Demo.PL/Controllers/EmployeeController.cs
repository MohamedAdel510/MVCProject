using Demo.DAL.Models;
using Dmo.BLL.Interfaces;
using Dmo.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var Employees = _employeeRepository.GetAll();
            return View(Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int Result = _employeeRepository.Add(employee);
                if (Result > 0)
                    TempData["Message"] = "Add successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeRepository.GetById(id.Value);
            if(employee is null)
                return NotFound();
            return View(ViewName, employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
           return Details(id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit(Employee employee, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _employeeRepository.Update(employee);
                    if (Result > 0)
                        TempData["Message"] = "Updated";
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Employee employee, [FromRoute] int id)
        {
            try
            {
                int Result = _employeeRepository.Delete(employee);
                if (Result > 0)
                    TempData["Message"] = "Deleted";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employee);
            }
        }
    }
}
