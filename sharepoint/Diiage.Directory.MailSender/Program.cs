using Diiage.Directory.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Diiage.Directory.MailSender
{
    static class Program
    {
        static async Task Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var smtpConfig = config.GetSection("Smtp").Get<SmtpConfiguration>();

            var dbContextOptionBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("Application"));


            IList<Mail> mails = null;
            using (var dbContext = new AppDbContext(dbContextOptionBuilder.Options))
            {
                mails = await dbContext.Mails.AsNoTracking().ToListAsync();
            }

            int i = 0;
            foreach(var mail in mails)
            {
                i++;
                System.Console.WriteLine($"Sending mail #{mail.Id} ({i}/{mails.Count})...");
                await Send(mail, smtpConfig);
                
                System.Console.WriteLine($"Mail sent.");
                using (var dbContext = new AppDbContext(dbContextOptionBuilder.Options))
                {
                    dbContext.Remove(mail);
                    await dbContext.SaveChangesAsync();
                }

                System.Console.WriteLine($"Mail deleted.");
            }

            System.Console.WriteLine($"Done.");
        }

        /// <summary>
        /// Sends the specified mail.
        /// </summary>
        /// <param name="mail">The mail.</param>
        private static async Task Send(Mail mail, SmtpConfiguration smtpConfig)
        {
            // Create SMTP client
            var client = new SmtpClient
            {
                Port = smtpConfig.Port,
                Host = smtpConfig.Host,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                    smtpConfig.Login,
                    smtpConfig.Password),
                EnableSsl = smtpConfig.EnableSsl
            };

            // Create message
            var message = new MailMessage
            {
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = true,
                From = new MailAddress(smtpConfig.SenderMail, smtpConfig.SenderName)
            };

            message.To.Add(new MailAddress(mail.Recipient));

            // Send it
            await client.SendMailAsync(message);
        }
    }
}
