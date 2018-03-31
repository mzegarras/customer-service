using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Clientes.Models
{
    public class ClienteTO {
        public String Codigo{get;set;}
        public String Nombres{get;set;}

        public String Paterno{get;set;}

        public String Materno{get;set;}

        public int Edad{get;set;}
    }
}
