using Diiage.Directory.Core.Interfaces.UseCases;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diiage.Directory.Web.Controllers
{
    /// <summary>
    /// UI (SPA) configuration controller.
    /// </summary>
    public class UiConfigurationsController : Base.AppControllerBase
    {
        private readonly IGetRemoteUiConfigurationUseCase _getUiConfigurationUseCase;


        public UiConfigurationsController(IGetRemoteUiConfigurationUseCase getUiConfigurationUseCase)
        {
            _getUiConfigurationUseCase = getUiConfigurationUseCase;
        }

        /// <summary>
        /// Gets the UI (SPA) configuration.
        /// </summary>
        /// <returns>The UI (SPA) configuration</returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            return Ok(await _getUiConfigurationUseCase.Execute());
        }
    }
}
