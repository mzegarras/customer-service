using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Clientes.Dao;
using Clientes.Model;
using Microsoft.Extensions.Logging;

namespace Clientes.Services
{

    public class ClienteServiceImpl : ClienteService
    {

        private readonly ILogger<ClienteServiceImpl> log;
        private readonly NotificationService notificationService;

        private readonly ClienteRespository clienteRespository;

        public ClienteServiceImpl(ILogger<ClienteServiceImpl> log,
                                NotificationService notificationService,
                                ClienteRespository clienteRespository){
            this.notificationService=notificationService;
            this.log=log;
            this.clienteRespository = clienteRespository;
        }

        public string list()
        {
            
            /*log.LogTrace(message);
            log.LogDebug(message);
            log.LogInformation(message);
            log.LogWarning(message);
            log.LogCritical(message);

            return message;*/

            return string.Empty;

        }

        public void save(Customer customer)
        {
            
            this.clienteRespository.connect();
            
            this.notificationService.sendMessage();

           
        }

        int ClienteService.sumar(int n1, int n2)
        {
            return n1 + n2;
        }


    } 
}
