using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Dmo.BLL.Interfaces;
using Dmo.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            //IEnumerable<Employee> employees;
            
            //if (string.IsNullOrEmpty(SearchValue))
            //    employees = _unitOfWork.EmployeeRepository.GetAll();
            //else
            //    employees = _unitOfWork.EmployeeRepository.GetByName(SearchValue);
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            if (! string.IsNullOrEmpty(SearchValue))
            {
                employees = _unitOfWork.EmployeeRepository.GetByName(SearchValue);
            }
            var MappedEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeView>>(employees);
            return View(MappedEmployee);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Department = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeView employeeView)
        {
            if (ModelState.IsValid)
            {
                #region Manual Mapping
                //var MappedEmployee = new Employee()
                //{
                //    Name = employeeView.Name,
                //    Age = employeeView.Age,
                //    Addres = employeeView.Addres,
                //    IsActive = employeeView.IsActive,
                //    HireDate = employeeView.HireDate,
                //    DepartmentId = employeeView.DepartmentId,
                //    Email = employeeView.Email,
                //    PhoneNumber = employeeView.PhoneNumber,
                //    Salary = employeeView.Salary,
                //};
                #endregion

                var MappedEmployee = _mapper.Map<EmployeeView, Employee>(employeeView);

                 _unitOfWork.EmployeeRepository.Add(MappedEmployee);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                    TempData["Message"] = "Add successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employeeView);
        }
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id.Value);
            if(employee is null)
                return NotFound();
            var MappedEmployee = _mapper.Map<Employee, EmployeeView>(employee);
            return View(ViewName, MappedEmployee);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
           return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeView employeeView, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmployee = _mapper.Map<EmployeeView, Employee>(employeeView);
                    _unitOfWork.EmployeeRepository.Update(MappedEmployee);
                    int Result = await _unitOfWork.CompleteAsync();
                    if (Result > 0)
                        TempData["Message"] = "Updated";
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeView);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeView employeeView, [FromRoute] int id)
        {
            try
            {
                var MappedEmployee = _mapper.Map<EmployeeView, Employee>(employeeView);
                _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                    TempData["Message"] = "Deleted";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeView);
            }
        }
    }
}
