using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.UseCases.Base;

using System.Threading.Tasks;

namespace Diiage.Directory.Core.UseCases.Base
{
    /// <summary>
    /// Use case base class for process with no output.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IVoidUseCase{TInput}" />
    public abstract class VoidUseCaseBase<TInput> : IVoidUseCase<TInput>
        where TInput : IModel
    {
        /// <summary>
        /// Determines whether the specified use case execution is allowed.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><see langword="true"/> if allowed, otherwise <see langword="false"/>.</returns>
        protected virtual Task<bool> IsAllowed(TInput input) => Task.FromResult(true);

        /// <summary>
        /// Executes the use case after permission checks.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        protected abstract Task ExecuteInternal(TInput input);

        /// <summary>
        /// Executes the current use case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <exception cref="Exceptions.BusinessException"></exception>
        public async Task Execute(TInput input)
        {
            if (!await IsAllowed(input))
            {
                throw new Exceptions.BusinessException(Exceptions.ErrorType.Forbidden);
            }

            await ExecuteInternal(input);
        }
    }
}
