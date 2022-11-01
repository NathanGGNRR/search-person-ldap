using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models;
using ServiceModels = Diiage.Directory.Core.Interfaces.Services.Models;

using System.Threading.Tasks;
using System.Configuration;
using Azure.Storage.Queues.Models;
using System;
using Azure.Storage.Queues;
using Newtonsoft.Json;

namespace Diiage.Directory.Core.UseCases
{
    /// <summary>
    /// Sends the employee summary by mail use case.
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.UseCases.ISendEmployeeSummaryUseCase" />
    public class SendEmployeeSummaryUseCase : Base.VoidUseCaseBase<SingleEmployeeQuery>, ISendEmployeeSummaryUseCase
    {
        private readonly IMailService _mailService;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmployeeSummaryUseCase"/> class.
        /// </summary>
        /// <param name="mailService">The mail service.</param>
        /// <param name="employeesRepository">The employees repository.</param>
        /// <param name="appPrincipal">The application principal.</param>
        public SendEmployeeSummaryUseCase(IMailService mailService, IEmployeesRepository employeesRepository)
        {
            _mailService = mailService;
            _employeesRepository = employeesRepository;
            _connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountprojet4;AccountKey=T58M52UBHNea8fSiaglCC24xl3bteqFBr5Bv786tpGC9iN1AmHS2ufKGDORF7Sp7Kr+E1PgdrY/2PnDxGWgs4g==;EndpointSuffix=core.windows.net";
        }

        /// <summary>
        /// Executes the use case after permission checks.
        /// </summary>
        /// <param name="input">The input.</param>
        protected override async Task ExecuteInternal(SingleEmployeeQuery input)
        {
            var employee = await _employeesRepository.GetById(input.EmployeeId);
            var json = JsonConvert.SerializeObject(employee);
            InsertMessage("mailsender", Base64Encode(json));
        }


        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        //-------------------------------------------------
        // Create a message queue
        //-------------------------------------------------
        public bool CreateQueue(string queueName)
        {
            try
            {
                // Instantiate a QueueClient which will be used to create and manipulate the queue
                QueueClient queueClient = new QueueClient(_connectionString, queueName);

                // Create the queue
                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    Console.WriteLine($"Queue created: '{queueClient.Name}'");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n\n");
                Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        //-------------------------------------------------
        // Insert a message into a queue
        //-------------------------------------------------
        public void InsertMessage(string queueName, string message)
        {
            // Instantiate a QueueClient which will be used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage(message);
            }
        }

        //-------------------------------------------------
        // Peek at a message in the queue
        //-------------------------------------------------
        public void PeekMessage(string queueName)
        {
        
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            if (queueClient.Exists())
            {
                // Peek at the next message
                PeekedMessage[] peekedMessage = queueClient.PeekMessages();

            }
        }

        //-------------------------------------------------
        // Update an existing message in the queue
        //-------------------------------------------------
        public void UpdateMessage(string queueName)
        {          
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            if (queueClient.Exists())
            {
                // Get the message from the queue
                QueueMessage[] message = queueClient.ReceiveMessages();

                // Update the message contents
                queueClient.UpdateMessage(message[0].MessageId,
                        message[0].PopReceipt,
                        "Updated contents",
                       TimeSpan.FromSeconds(60.0)  // Make it invisible for another 60 seconds
                    );
            }
        }

        //-------------------------------------------------
        // Process and remove a message from the queue
        //-------------------------------------------------
        public void DequeueMessage(string queueName)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            if (queueClient.Exists())
            {
                // Get the next message
                QueueMessage[] retrievedMessage = queueClient.ReceiveMessages();

                // Process (i.e. print) the message in less than 30 seconds
                Console.WriteLine($"Dequeued message: '{retrievedMessage[0].MessageText}'");

                // Delete the message
                queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            }
        }

        //-----------------------------------------------------
        // Get the approximate number of messages in the queue
        //-----------------------------------------------------
        public void GetQueueLength(string queueName)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            if (queueClient.Exists())
            {
                QueueProperties properties = queueClient.GetProperties();

                // Retrieve the cached approximate message count.
                int cachedMessagesCount = properties.ApproximateMessagesCount;
            }
        }

        //-------------------------------------------------
        // Delete the queue
        //-------------------------------------------------
        public void DeleteQueue(string queueName)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(_connectionString, queueName);

            if (queueClient.Exists())
            {
                // Delete the queue
                queueClient.Delete();
            }
        }
    }
}
