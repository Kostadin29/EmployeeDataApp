using EmployeeDataApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        // CRUD Operations
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task<int> DeleteById(int id);
    }
}
