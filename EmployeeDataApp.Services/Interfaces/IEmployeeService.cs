

using EmployeeDataApp.ViewModels.EmployeeViewModels;

namespace EmployeeDataApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListViewModel>> GetAllEmployees();
        Task<int> DeleteEmployeeById(int id);
        Task CreateEmployee(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> GetEmployeeForEditing(int id);
        Task EditEmployee(EmployeeViewModel employeeViewModel);
    }
}
