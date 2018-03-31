using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Clientes.Model;

namespace Clientes.Services
{

    public class ClienteServiceImpl : ClienteService
    {

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ClienteServiceImpl));

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
        }
    } 
}
