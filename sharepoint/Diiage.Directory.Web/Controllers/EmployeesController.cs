using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Diiage.Directory.Web.Controllers
{
    public class EmployeesController : Base.AppControllerBase
    {
        private readonly IGetEmployeesUseCase _getEmployeesUseCase;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly ISendEmployeeSummaryUseCase _sendEmployeeSummaryUseCase;

        public EmployeesController(
            IGetEmployeesUseCase getEmployeesUseCase,
            IGetEmployeeUseCase getEmployeeUseCase,
            ISendEmployeeSummaryUseCase sendEmployeeSummaryUseCase)
        {
            _getEmployeesUseCase = getEmployeesUseCase;
            _getEmployeeUseCase = getEmployeeUseCase;
            _sendEmployeeSummaryUseCase = sendEmployeeSummaryUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EmployeesSearchQuery query)
        {
            return Ok(await _getEmployeesUseCase.Execute(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _getEmployeeUseCase.Execute(new SingleEmployeeQuery { EmployeeId = id });
            return result != null
                ? Ok(result)
                : NotFound();
        }

        [HttpPost]
        [Route("{id}/sendSummary")]
        public Task SendSummary(int id)
        {
            return _sendEmployeeSummaryUseCase.Execute(new SingleEmployeeQuery { EmployeeId = id });
        }
    }
}
