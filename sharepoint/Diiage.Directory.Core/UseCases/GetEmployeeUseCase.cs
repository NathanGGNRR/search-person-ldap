using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models;

using System.Threading.Tasks;

namespace Diiage.Directory.Core.UseCases
{
    /// <summary>
    /// Get an employee from its identifier use case.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.IGetEmployeeUseCase" />
    public class GetEmployeeUseCase : Base.UseCaseBase<SingleEmployeeQuery, Employee>, IGetEmployeeUseCase
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IBusinessMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmployeeUseCase"/> class.
        /// </summary>
        /// <param name="employeesRepository">The employees repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetEmployeeUseCase(
            IEmployeesRepository employeesRepository,
            IBusinessMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the current use case after permission checks.
        /// </summary>
        /// <param name="input">The use case input.</param>
        /// <returns>
        /// The use case output.
        /// </returns>
        protected override async Task<Employee> ExecuteInternal(SingleEmployeeQuery input)
        {
            return _mapper.Map<Employee>(
                await _employeesRepository.GetById(input.EmployeeId));
        }
    }
}
