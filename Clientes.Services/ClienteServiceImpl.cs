using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Clientes.Model;
using Microsoft.Extensions.Logging;

namespace Clientes.Services
{

    public class ClienteServiceImpl : ClienteService
    {

        private readonly ILogger<ClienteServiceImpl> log;
        private readonly NotificationService notificationService;

        public ClienteServiceImpl(ILogger<ClienteServiceImpl> log,
                                NotificationService notificationService){
            this.notificationService=notificationService;
            this.log=log;
        }

        public void save(Customer customer)
        {
            notificationService.sendMessage();
        }

        int ClienteService.sumar(int n1, int n2)
        {
            return n1 + n2;
        }


    } 
}
