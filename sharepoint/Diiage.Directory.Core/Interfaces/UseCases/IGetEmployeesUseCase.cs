using Diiage.Directory.Core.Models;

namespace Diiage.Directory.Core.Interfaces.UseCases
{
    /// <summary>
    /// Get employees according to search filters use case interface.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IUseCase{Diiage.Directory.Core.Models.EmployeesSearchQuery, Diiage.Directory.Core.Models.EmployeesSearchResponse}" />
    public interface IGetEmployeesUseCase : Base.IUseCase<EmployeesSearchQuery, EmployeesSearchResponse> { }
}
