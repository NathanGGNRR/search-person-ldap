using Diiage.Directory.Core.Entities;
using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diiage.Directory.Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Employee employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IList<Employee>> Get(string surname, string firstname)
        {
            IQueryable<Employee> query = _dbContext.Employees;

            if (!string.IsNullOrWhiteSpace(surname))
            {
                query = query.Where(e => e.Surname.StartsWith(surname));
            }

            if (!string.IsNullOrWhiteSpace(firstname))
            {
                query = query.Where(e => e.Firstname.StartsWith(firstname));
            }

            return await query.ToListAsync();
        }
    }
}
