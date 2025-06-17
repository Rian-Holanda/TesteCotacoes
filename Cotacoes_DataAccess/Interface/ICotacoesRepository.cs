using Cotacoes_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacoes_DataAccess.Interface
{
    public interface ICotacoesRepository
    {
        List<CotacoesEntity> GetCotacoes(double valor, string? dataInicioInvestimento, string? dataTerminoInvestimento);
    }
}
