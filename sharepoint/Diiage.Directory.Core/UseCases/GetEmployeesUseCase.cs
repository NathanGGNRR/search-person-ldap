using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models;

using System.Threading.Tasks;

namespace Diiage.Directory.Core.UseCases
{
    /// <summary>
    /// Get employees according to search filters use case.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.IGetEmployeesUseCase" />
    public class GetEmployeesUseCase : Base.UseCaseBase<EmployeesSearchQuery, EmployeesSearchResponse>, IGetEmployeesUseCase
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IBusinessMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmployeesUseCase"/> class.
        /// </summary>
        /// <param name="employeesRepository">The employees repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetEmployeesUseCase(
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
        protected override async Task<EmployeesSearchResponse> ExecuteInternal(EmployeesSearchQuery input)
        {
            return _mapper.Map<EmployeesSearchResponse>(
                await _employeesRepository.Get(input.Surname, input.Firstname));
        }
    }
}
