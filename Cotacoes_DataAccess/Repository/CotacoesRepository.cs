using Cotacoes_DataAccess.Config;
using Cotacoes_DataAccess.Interface;
using Cotacoes_Entity;
using Cotacoes_Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacoes_DataAccess.Repository
{
    public class CotacoesRepository : ICotacoesRepository
    {
        public List<CotacoesEntity> GetCotacoes (double valor, string? dataInicioInvestimento, string? dataTerminoInvestimento)
        {
            try 
            {
                ConfigDB configDB = new ConfigDB();
                ConvertDataTableObject convertDataTableObject = new ConvertDataTableObject();

                using (SqlConnection connection = new SqlConnection(configDB._connection)) 
                {
                    using (var cmd = connection.CreateCommand()) 
                    { 
                        connection.Open();

                        cmd.Parameters.AddWithValue("@Valor", valor);
                        cmd.Parameters.AddWithValue("@DataInicioInvestimento", dataInicioInvestimento);
                        cmd.Parameters.AddWithValue("@DataTerminoInvestimento", dataTerminoInvestimento);
                        cmd.CommandText = "PRC_CalculaInvestimento";

                        var dt = configDB.ExecuteQuery(cmd);



                        return convertDataTableObject.ConvertDataTable<CotacoesEntity>(dt);
                    }
                }
            }
            catch 
            { 
                return new List<CotacoesEntity> ();
            }
        }
    }
}
