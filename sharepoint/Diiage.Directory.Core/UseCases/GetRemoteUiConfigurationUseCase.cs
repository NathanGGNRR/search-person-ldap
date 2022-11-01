using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models.Configuration;

using System.Threading.Tasks;

namespace Diiage.Directory.Core.UseCases
{
    /// <summary>
    /// Get UI (SPA) configuration use case.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.UseCases.Base.UseCaseBase{Diiage.Directory.Core.Models.Configuration.RemoteUiConfiguration}" />
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.IGetRemoteUiConfigurationUseCase" />
    public class GetRemoteUiConfigurationUseCase : Base.UseCaseBase<RemoteUiConfiguration>, IGetRemoteUiConfigurationUseCase
    {
        private readonly ApplicationConfiguration _applicationConfiguration;

        public GetRemoteUiConfigurationUseCase(ApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        /// <summary>
        /// Retreive SPA configuration
        /// </summary>
        /// <returns>The SPA configuration</returns>
        protected override Task<RemoteUiConfiguration> ExecuteInternal()
        {
            return Task.FromResult(new RemoteUiConfiguration
            {
                Version = _applicationConfiguration.Ui.Version,
                Upn = "test",
                UserId = "test",
                DisplayName = "test"
            });
        }
    }
}
