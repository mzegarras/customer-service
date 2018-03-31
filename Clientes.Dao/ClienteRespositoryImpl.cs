using System;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Clientes.Dao
{
    public class ClienteRespositoryImpl : ClienteRespository
    {


        private readonly ILogger<ClienteRespositoryImpl> log;

        public ClienteRespositoryImpl(ILogger<ClienteRespositoryImpl> logger){
            this.log= logger;


        }

        void ClienteRespository.connect()
        {
            String connectionString = "Server=dbinstance.ciwrnxkiyug1.us-east-1.rds.amazonaws.com;Database=dbname;Uid=admin;Pwd=Password;";

            var connection = new MySqlConnection(connectionString); 

            try{

                connection.Open();

                log.LogTrace("Open");
                log.LogDebug("Open");
                log.LogInformation("Open");
                log.LogWarning("Open");
                log.LogCritical("Open");

            }catch(Exception ex){
                log.LogError("Open",ex);
            }finally{
                connection.Close();
            }
            

           
        
            

        }
    }
}
