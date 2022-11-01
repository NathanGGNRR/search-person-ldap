using System.Threading.Tasks;

namespace Diiage.Directory.Core.Interfaces.UseCases.Base
{
    /// <summary>
    /// Use case interface with input and output.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public interface IUseCase<TInput, TOutput>
        where TInput : IModel
        where TOutput : IModel
    {
        /// <summary>
        /// Executes the use case with specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The use case output.</returns>
        Task<TOutput> Execute(TInput input);
    }

    /// <summary>
    /// Use case interface with no input and an output.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public interface IUseCase<TOutput>
        where TOutput : IModel
    {
        /// <summary>
        /// Executes the use case and returns output.
        /// </summary>
        /// <returns>The use case output.</returns>
        Task<TOutput> Execute();
    }
}
