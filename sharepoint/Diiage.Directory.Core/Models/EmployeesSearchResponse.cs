using Diiage.Directory.Core.Interfaces;

using System.Collections.Generic;

namespace Diiage.Directory.Core.Models
{
    public class EmployeesSearchResponse : IModel
    {
        public IList<Employee> Employees { get; set; }
    }
}
