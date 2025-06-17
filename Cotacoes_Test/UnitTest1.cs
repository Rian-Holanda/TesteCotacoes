using Cotacoes_DataAccess.Config;
using Cotacoes_DataAccess.Repository;

namespace Cotacoes_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ConfigDB configDB = new ConfigDB();
            CotacoesRepository cotacoesRepository = new CotacoesRepository();

            var cotacoes = cotacoesRepository.GetCotacoes(10000, "2025-01-01", "2025-01-02");
            var primeiraCotacao = cotacoes.First();


            Assert.Equal(1, Convert.ToInt32(primeiraCotacao.taxa_acumulada));
        }
    }
}