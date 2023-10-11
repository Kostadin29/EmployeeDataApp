using EmployeeDataApp.DataAccess.Interfaces;
using EmployeeDataApp.Services.Interfaces;
using EmployeeDataApp.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace EmployeeDataApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _employeeService.GetAllEmployees());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _employeeService.DeleteEmployeeById(id));
        }

        public IActionResult Create()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployee(employeeViewModel);
                TempData["successMessage"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Model data is not valid";
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeForEditing(id);

            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.EditEmployee(employeeViewModel);
                    TempData["successMessage"] = "Employee details updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }
        }


    }
}
