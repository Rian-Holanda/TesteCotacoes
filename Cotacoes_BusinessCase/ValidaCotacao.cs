using Cotacoes_BusinessCase.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cotacoes_BusinessCase
{
    public class ValidaCotacao : IValidaCotacaoBusinessCase
    {
        public bool ValidaDataInicioCotacao (string? DataInicioCotacao)
        {
            try 
            {
                return ValidaData(DataInicioCotacao);
            }
            catch 
            { 
                return false;
            }
        }

        public bool ValidaDataFimCotacao(string? DataFimCotacao)
        {
            try
            {
                return ValidaData(DataFimCotacao);
            }
            catch
            {
                return false;
            }
        }

        private bool ValidaData(string? data)
        {
            try 
            {
                string formato = "yyyy-MM-dd"; 
                CultureInfo cultura = CultureInfo.InvariantCulture; 

                if (DateTime.TryParseExact(data, formato, cultura, DateTimeStyles.None, out DateTime dataValida))
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch 
            { 
                return false;
            }

        }
    }
}
