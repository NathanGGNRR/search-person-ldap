using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AzureFunctionProject4
{
    public static class MailSender
    {
        [FunctionName("MailSender")]
        public static void Run([QueueTrigger("mailsender", Connection = "AccessKey")]string myQueueItem, ILogger log)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(myQueueItem);

            Execute(employee).Wait();

        }

        static async Task Execute(Employee employee)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("clemgon2121@hotmail.fr", "clement");
            var subject = "Fiche personnelle";
            var to = new EmailAddress(employee.Email, employee.Surname);
            var plainTextContent = "information personnelle";

             
            var htmlContent = "<strong>Voici votre fiche récapitulative</strong>" +
                " </br> " +
                " </br> " +
                " </br> " +
                " Nom :  " + employee.Firstname + "  " + employee.Surname + "</br>" +
                " Poste :  " + employee.Position + "</br>" +
                " Date d'entrée :  " + employee.StartDate + "</br>" +
                " Salaire brut annuel :  " + employee.AnnualGrossIncome + "</br>" +
                " Adresse :  " + " - "+ employee.Address.Country +" / "+ employee.Address.City + "-" + employee.Address.PostCode + "  " + employee.Address.Street+ " " + "</br>" +
                " Téléphone / Email :  " + employee.Phone + " / " + employee.Email + "</br>" +
                " Adresse personnelle :  " + employee.PersonalAddress + "</br>" +
                " Téléphone / Email personnels :  " + employee.PersonalPhone + " / " + employee.PersonalEmail + "</br>" +
                " Commentaires :  " + employee.Comments;





            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
