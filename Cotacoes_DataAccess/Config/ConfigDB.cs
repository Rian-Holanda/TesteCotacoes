using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacoes_DataAccess.Config
{
    public class ConfigDB
    {
        public string? _connection;

        public ConfigDB() 
        {
            _connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=COTACOES;Integrated Security=True";
        }


        public DataTable ExecuteQuery (SqlCommand command)
        {
            try 
            { 
                DataTable dt = new DataTable();
                
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                dt.Load(reader);

                return dt;
            }
            catch 
            { 
                return new DataTable();
            }
        }
        

        
    }
}
