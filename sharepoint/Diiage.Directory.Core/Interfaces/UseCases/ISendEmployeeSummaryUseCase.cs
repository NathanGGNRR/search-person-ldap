using Diiage.Directory.Core.Models;

namespace Diiage.Directory.Core.Interfaces.UseCases
{
    /// <summary>
    /// Send employee summary by mail to the authenticated user use case interface.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IVoidUseCase{Diiage.Directory.Core.Models.SingleEmployeeQuery}" />
    public interface ISendEmployeeSummaryUseCase : Base.IVoidUseCase<SingleEmployeeQuery> { }
}
