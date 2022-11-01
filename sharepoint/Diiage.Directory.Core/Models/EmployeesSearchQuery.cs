using Diiage.Directory.Core.Interfaces;

namespace Diiage.Directory.Core.Models
{
    public class EmployeesSearchQuery : IModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}
