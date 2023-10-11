using EmployeeDataApp.DataAccess.Implementations;
using EmployeeDataApp.DataAccess.Interfaces;
using EmployeeDataApp.Domain.Models;
using EmployeeDataApp.Mappers;
using EmployeeDataApp.Services.Implementations;
using EmployeeDataApp.Services.Interfaces;
using EmployeeDataApp.ViewModels.EmployeeViewModels;

namespace EmployeeDataApp.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        private IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }
        public Task CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            return _employeeRepository.Insert(employeeViewModel.ToEmployee());
        }

        public async Task<int> DeleteEmployeeById(int id)
        {
            return await _employeeRepository.DeleteById(id);
        }

        public async Task EditEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employeeDb = await _employeeRepository.GetById(employeeViewModel.Id);

            if (employeeDb == null)
                throw new Exception("Employee not found");

            employeeDb.Id = employeeViewModel.Id;
            employeeDb.FirstName = employeeViewModel.FirstName;
            employeeDb.LastName = employeeViewModel.LastName;
            employeeDb.DateOfBirth = employeeViewModel.DateOfBirth;
            employeeDb.Email = employeeViewModel.Email;
            employeeDb.Salary = employeeViewModel.Salary;

            await _employeeRepository.Update(employeeDb);
        }

        public async Task<List<EmployeeListViewModel>> GetAllEmployees()
        {
            List<Employee> employeeDb = await _employeeRepository.GetAll();

            return employeeDb.Select(x => x.ToEmployeeListViewModel()).ToList();
        }

        public async Task<EmployeeViewModel> GetEmployeeForEditing(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);

            if (employee == null)
                throw new Exception("Employee not found");

            EmployeeViewModel employeeViewModel = employee.ToEmployeeViewModel();

            return employeeViewModel;
        }
    }
}

