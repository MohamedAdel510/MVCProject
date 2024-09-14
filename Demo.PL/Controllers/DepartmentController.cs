using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Dmo.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var department = await _unitOfWork.DepartmentRepository.GetAllAsync();
            var MappedDepartments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentView>>(department);
            
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

            return View(MappedDepartments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentView departmentView)
        {
            if (ModelState.IsValid)
            {
                var MappedDepartment = _mapper.Map<DepartmentView, Department>(departmentView);
                _unitOfWork.DepartmentRepository.Add(MappedDepartment);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                {
                    TempData["Message"] = "Added successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departmentView);
        }
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id.Value);
            if (department is null)
                return NotFound();
            var MappedDepartment = _mapper.Map<Department, DepartmentView>(department);
            return View(ViewName, MappedDepartment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id is null)
            //    return BadRequest();
            //var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            //if(department is null)
            //    return NotFound();
            //return View(department);
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentView departmentView, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedDepartment = _mapper.Map<DepartmentView, Department>(departmentView);
                    _unitOfWork.DepartmentRepository.Update(MappedDepartment);
                    int Result = await _unitOfWork.CompleteAsync();
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
            return View(departmentView);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentView departmentView, [FromRoute] int id)
        {
            try
            {
                var MappedDepartment = _mapper.Map<DepartmentView, Department>(departmentView);
                _unitOfWork.DepartmentRepository.Delete(MappedDepartment);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                {
                    TempData["Message"] = "Deleted";
                }
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(departmentView);
            }
        }
    }
}
