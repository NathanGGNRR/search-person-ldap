using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.UseCases.Base;

using System.Threading.Tasks;

namespace Diiage.Directory.Core.UseCases.Base
{
    /// <summary>
    /// Use case base class for process with no input.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IUseCase{TOutput}" />
    public abstract class UseCaseBase<TOutput> : IUseCase<TOutput>
        where TOutput : IModel
    {
        /// <summary>
        /// Determines whether the current use case execution is allowed.
        /// </summary>
        /// <returns>True if allowed, <see langword="false"/> otherwise.</returns>
        protected virtual Task<bool> IsAllowed() => Task.FromResult(true);

        /// <summary>
        /// Executes the use case after permission checks.
        /// </summary>
        /// <returns>The use case output.</returns>
        protected abstract Task<TOutput> ExecuteInternal();

        /// <summary>
        /// Executes the use case and returns output.
        /// </summary>
        /// <returns>
        /// The use case output.
        /// </returns>
        /// <exception cref="Exceptions.BusinessException"></exception>
        public async Task<TOutput> Execute()
        {
            if (!await IsAllowed())
            {
                throw new Exceptions.BusinessException(Exceptions.ErrorType.Forbidden);
            }

            return await ExecuteInternal();
        }
    }

    /// <summary>
    /// Use case base class accepting an input and an ouput.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.Base.IUseCase{TOutput}" />
    public abstract class UseCaseBase<TInput, TOutput> : IUseCase<TInput, TOutput>
        where TInput : IModel
        where TOutput : IModel
    {
        /// <summary>
        /// Determines whether the current use case execution is allowed.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>True if allowed, <see langword="false"/> otherwise.</returns>
        protected virtual Task<bool> IsAllowed(TInput input) => Task.FromResult(true);

        /// <summary>
        /// Executes the current use case after permission checks.
        /// </summary>
        /// <param name="input">The use case input.</param>
        /// <returns>The use case output.</returns>
        protected abstract Task<TOutput> ExecuteInternal(TInput input);

        /// <summary>
        /// Executes the use case with specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The use case output.
        /// </returns>
        /// <exception cref="Exceptions.BusinessException"></exception>
        public async Task<TOutput> Execute(TInput input)
        {
            if (!await IsAllowed(input))
            {
                throw new Exceptions.BusinessException(Exceptions.ErrorType.Forbidden);
            }

            return await ExecuteInternal(input);
        }
    }
}
