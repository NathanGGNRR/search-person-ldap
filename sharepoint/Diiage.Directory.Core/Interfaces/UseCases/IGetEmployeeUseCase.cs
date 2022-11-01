using Diiage.Directory.Core.Models;

namespace Diiage.Directory.Core.Interfaces.UseCases
{
    /// <summary>
    /// Get employee from its identifier use case interface.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IUseCase{Diiage.Directory.Core.Models.SingleEmployeeQuery, Diiage.Directory.Core.Models.Employee}" />
    public interface IGetEmployeeUseCase : Base.IUseCase<SingleEmployeeQuery, Employee> { }
}
