using Demo.DAL.Models;
using Dmo.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var department = _departmentRepository.GetAll();
            
            #region ViewData vs ViewBag
            ////1- ViewData => Dictionary[Key value pair]
            ////               transfer data from Action to it is view
            ////               start with .net framework 3.5
            //ViewData["Message"] = "Hello From View Data";
            ////2- ViewBag => Dinamic Property [Based on Dinamic Keyword]
            ////              transfare data from Controller[Action] To It is view
            ////              start with .ner framework 4.0
            //ViewBag.Message = "Hello From View Bag";
            #endregion
           
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                int Result = _departmentRepository.Add(department);
                if(Result > 0)
                {
                    TempData["Message"] = "Added successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepository.GetById(id.Value);
            if (department is null)
                return NotFound();
            return View(ViewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null)
            //    return BadRequest();
            //var department = _departmentRepository.GetById(id.Value);
            //if(department is null)
            //    return NotFound();
            //return View(department);
            return Details(id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit(Department department, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _departmentRepository.Update(department);
                    if (Result > 0)
                    {
                        TempData["Message"] = "Updated";
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department department, [FromRoute] int id)
        {
            try
            {
                int Result = _departmentRepository.Delete(department);
                if (Result > 0)
                {
                    TempData["Message"] = "Deleted";
                }
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }
        }
    }
}
