using EmployeeDataApp.DataAccess.DataContext;
using EmployeeDataApp.DataAccess.Interfaces;
using EmployeeDataApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataApp.DataAccess.Implementations
{

    // Here in this class I implement CRUD operations which they comes from IRepository interface.
    public class EmployeeRepository : IRepository<Employee>
    {
        private EmployeeDataAppDbContext _dbContext;

        public EmployeeRepository(EmployeeDataAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<int> DeleteById(int id)
        {
            Employee employeeDb = await _dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);

            if (employeeDb == null)
                throw new Exception($"Item with Id:{id} not found!");

            _dbContext.Employees.Remove(employeeDb);
            await _dbContext.SaveChangesAsync();

            return employeeDb.Id;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }


        public async Task<Employee> GetById(int id)
        {
            return await _dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Employee entity)
        {
            await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Employee entity)
        {
            _dbContext.Employees.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
