using Diiage.Directory.Core.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diiage.Directory.Core.Interfaces.Services
{
    /// <summary>
    /// Employees repository interface.
    /// </summary>
    public interface IEmployeesRepository
    {
        Task Add(Employee employee);

        Task<Employee> GetById(int id);

        Task<IList<Employee>> Get(string surname, string firstname);
    }
}
