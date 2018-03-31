using System;

namespace Clientes.Services
{
    public interface ClienteService
    {
        int sumar(int n1,int n2);
        void save(Model.Customer customer);
    } 
}
