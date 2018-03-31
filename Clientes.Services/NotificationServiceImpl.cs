using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Clientes.Model;
using Microsoft.Extensions.Logging;

namespace Clientes.Services
{

    public class NotificationServiceImpl : NotificationService
    {
        
        private readonly ILogger<NotificationServiceImpl> log;
        private readonly IAmazonSimpleNotificationService snsClient;

        public NotificationServiceImpl(ILogger<NotificationServiceImpl> log,IAmazonSimpleNotificationService snsClient){
            this.log=log;
            this.snsClient = snsClient;
        }

        public void sendMessage()
        {
             var request = new PublishRequest
            {
                TopicArn = "arn:aws:sns:us-east-1:081255659930:CustomerCreated",
                Message = "Test Message"
            };

            PublishResponse publishResponse = snsClient.PublishAsync(request).GetAwaiter().GetResult();

        

            log.LogError(publishResponse.MessageId);
            log.LogError(publishResponse.ResponseMetadata.ToString());
            log.LogError(publishResponse.ToString());

            log.LogDebug(publishResponse.MessageId);
            log.LogDebug(publishResponse.ResponseMetadata.ToString());
            log.LogDebug(publishResponse.ToString());

             log.LogInformation(publishResponse.MessageId);
            log.LogInformation(publishResponse.ResponseMetadata.ToString());
            log.LogInformation(publishResponse.ToString());

             log.LogTrace(publishResponse.MessageId);
            log.LogTrace(publishResponse.ResponseMetadata.ToString());
            log.LogTrace(publishResponse.ToString());

            log.LogWarning(publishResponse.MessageId);
            log.LogWarning(publishResponse.ResponseMetadata.ToString());
            log.LogWarning(publishResponse.ToString());
        }
    }
}