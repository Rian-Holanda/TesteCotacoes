using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacoes_BusinessCase.Interface
{
    public interface IValidaCotacaoBusinessCase
    {
        bool ValidaDataInicioCotacao(string? DataInicioCotacao);
        bool ValidaDataFimCotacao(string? DataFimCotacao);
    }
}
