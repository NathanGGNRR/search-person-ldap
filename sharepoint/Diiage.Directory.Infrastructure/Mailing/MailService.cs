using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Core.Interfaces.Services.Models;
using Diiage.Directory.Infrastructure.Database;

using System.Reflection;
using System.Threading.Tasks;

namespace Diiage.Directory.Infrastructure.Mailing
{
    /// <summary>
    /// Mail sending service.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.Services.IMailService" />
    public class MailService : IMailService
    {
        private readonly AppDbContext _dbContext;

        public MailService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Send<T>(Mail<T> mail)
        {
            _dbContext.Mails.Add(new Mail
            {
                Recipient = mail.Recipient,
                Subject = ReplacePlaceHolders(mail.SubjectTemplate, mail.Parameters),
                Body = ReplacePlaceHolders(mail.BodyTemplate, mail.Parameters)
            });
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Replace the placeHolders inside the template by the properties inside the object parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string ReplacePlaceHolders<T>(string template, T parameters)
        {
            var res = template;
            var props = parameters.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in props)
            {
                var oldSubString = "{" + propertyInfo.Name + "}";
                var newSubString = propertyInfo.GetValue(parameters, null) != null ? propertyInfo.GetValue(parameters, null).ToString() : "";
                res = res.Replace(oldSubString, System.Web.HttpUtility.HtmlEncode(newSubString));
            }
            return res;
        }
    }
}
