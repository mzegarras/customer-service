using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using Clientes.Services;

namespace Clientes.Microservice.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ClientesController));
        private readonly ClienteService clienteService;
        
        public ClientesController(ClienteService clienteService){
            this.clienteService=clienteService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ClienteTO> Get()
        {
            List<ClienteTO> clientes = new List<ClienteTO>();

            ClienteTO clienteTO1 = new ClienteTO();
            clienteTO1.Codigo="001";
            clienteTO1.Nombres="Nicole";
            clienteTO1.Paterno="Zegarra";
            clienteTO1.Materno="Monzón";
            clienteTO1.Edad=clienteService.sumar(1,3);
            clientes.Add(clienteTO1);

             ClienteTO clienteTO2 = new ClienteTO();
            clienteTO2.Codigo="002";
            clienteTO2.Nombres="Nicolas";
            clienteTO2.Paterno="Zegarra";
            clienteTO2.Materno="Monzón";
            clienteTO2.Edad=clienteService.sumar(1,9);
            clientes.Add(clienteTO2);

            log.Debug("1");
            log.Error("2");
            log.Fatal("3");
            log.Warn("4");
            return clientes;
        }


        // GET api/values/5
        [HttpGet("{id}",Name = "GetCliente")]
        public ClienteTO Get(int id)
        {

            ClienteTO clienteTO = new ClienteTO();
            clienteTO.Codigo="001";
            clienteTO.Nombres="Nicole";
            clienteTO.Paterno="Zegarra";
            clienteTO.Materno="Monzón";

            return clienteTO;
        }

         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ClienteTO cliente)
        {

            if (cliente == null)
            {
                return BadRequest();
            }

            Console.Write(cliente.Codigo);
            Console.Write(cliente.Nombres);

            return CreatedAtRoute("GetCliente", new { id = cliente.Codigo }, cliente);


        }


    }
}