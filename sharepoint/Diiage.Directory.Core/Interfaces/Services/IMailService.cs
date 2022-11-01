using System.Threading.Tasks;

namespace Diiage.Directory.Core.Interfaces.Services
{
    /// <summary>
    /// Mail sending service interface.
    /// </summary>
    public interface IMailService
    {
        Task Send<T>(Models.Mail<T> mail);
    }
}
