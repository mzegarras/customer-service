using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Clientes.Model;
using Microsoft.Extensions.Logging;

namespace Clientes.Services
{

    public class ClienteServiceImpl : ClienteService
    {

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ClienteServiceImpl));
        private readonly ILogger<ClienteServiceImpl> log;


        public ClienteServiceImpl(ILogger<ClienteServiceImpl> log){
            this.log=log;
        }

        public void save(Customer customer)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient();
            sendMessage(snsClient);
        }

        int ClienteService.sumar(int n1, int n2)
        {
            return n1 + n2;
        }


        void sendMessage(IAmazonSimpleNotificationService snsClient){
            var request = new PublishRequest
            {
                TopicArn = "arn:aws:sns:us-east-1:081255659930:CustomerCreated",
                Message = "Test Message"
            };

            PublishResponse publishResponse = snsClient.PublishAsync(request).GetAwaiter().GetResult();

            log.LogDebug(publishResponse.MessageId);
            log.LogDebug(publishResponse.ResponseMetadata.ToString());
            log.LogDebug(publishResponse.ToString());
        }
    } 
}
