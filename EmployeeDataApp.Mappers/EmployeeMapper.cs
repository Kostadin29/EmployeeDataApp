using EmployeeDataApp.Domain.Models;
using EmployeeDataApp.ViewModels.EmployeeViewModels;
using System.Net.NetworkInformation;

namespace EmployeeDataApp.Mappers
{
    public static class EmployeeMapper
    { 
        public static EmployeeListViewModel ToEmployeeListViewModel(this Employee employee)
        {
            return new EmployeeListViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Salary = employee.Salary,
                DateOfBirth = employee.DateOfBirth
            };
        }

        public static Employee ToEmployee(this EmployeeViewModel employeeViewModel) 
        {
            return new Employee()
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Email = employeeViewModel.Email,
                Salary = employeeViewModel.Salary,
                DateOfBirth = employeeViewModel.DateOfBirth
            };
        }

        public static EmployeeViewModel ToEmployeeViewModel(this Employee employee)
        {
            return new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Salary = employee.Salary,
                DateOfBirth = employee.DateOfBirth
            };
        }
    }
}
