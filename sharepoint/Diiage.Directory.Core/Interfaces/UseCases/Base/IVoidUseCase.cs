using System.Threading.Tasks;

namespace Diiage.Directory.Core.Interfaces.UseCases.Base
{
    public interface IVoidUseCase<in TInput>
        where TInput : IModel
    {
        Task Execute(TInput input);
    }
}
