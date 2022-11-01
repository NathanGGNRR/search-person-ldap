using Diiage.Directory.Core.Models.Configuration;

namespace Diiage.Directory.Core.Interfaces.UseCases
{
    /// <summary>
    /// Get application user from authenticated account use case interface.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IUseCase{Diiage.Directory.Core.Models.Configuration.RemoteUiConfiguration}" />
    public interface IGetRemoteUiConfigurationUseCase : Base.IUseCase<RemoteUiConfiguration> { }
}
