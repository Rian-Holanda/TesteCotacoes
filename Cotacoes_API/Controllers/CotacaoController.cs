using Cotacoes_API.Model;
using Cotacoes_BusinessCase.Interface;
using Cotacoes_DataAccess.Interface;
using Cotacoes_Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cotacoes_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CotacaoController : ControllerBase
    {

        private readonly ICotacoesRepository _cotacoesRepository;
        private readonly IValidaCotacaoBusinessCase _validaCotacaoBusinessCase;

        public CotacaoController(ICotacoesRepository cotacoesRepository, IValidaCotacaoBusinessCase validaCotacaoBusinessCase)
        {
            this._cotacoesRepository = cotacoesRepository;
            this._validaCotacaoBusinessCase = validaCotacaoBusinessCase;
        }


        [HttpGet("cotacoes")]
        public ActionResult<IEnumerable<CotacoesEntity>> GetCotacoes([FromQuery] CotacaoModel cotacaoModel)
        {
            try 
            {
                List<CotacoesEntity> cotacoes = new List<CotacoesEntity>();

                if(_validaCotacaoBusinessCase.ValidaDataInicioCotacao(cotacaoModel.DataInicioInvestimento) &&
                   _validaCotacaoBusinessCase.ValidaDataFimCotacao(cotacaoModel.DataTerminoInvestimento)) 
                {

                    cotacoes = _cotacoesRepository.GetCotacoes(cotacaoModel.Valor,
                                                               cotacaoModel.DataInicioInvestimento,
                                                               cotacaoModel.DataTerminoInvestimento);

                    return Ok(cotacoes);
                }

                else 
                {
                    throw new Exception("Data inválida");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensagem = "Ocorreu um erro ao buscar as cotações.",
                    Detalhes = ex.Message
                });
            }
        }

        [HttpGet("ultimaCotacao")]
        public ActionResult<CotacoesEntity> GetUltimaCotacao([FromQuery] CotacaoModel cotacaoModel)
        {
            try
            {
                if (_validaCotacaoBusinessCase.ValidaDataInicioCotacao(cotacaoModel.DataInicioInvestimento) &&
                   _validaCotacaoBusinessCase.ValidaDataFimCotacao(cotacaoModel.DataTerminoInvestimento))
                {

                    var cotacoes = _cotacoesRepository.GetCotacoes(cotacaoModel.Valor,
                                                               cotacaoModel.DataInicioInvestimento,
                                                               cotacaoModel.DataTerminoInvestimento);
                    var ultimaCotacao = cotacoes.Last();
                    return Ok(ultimaCotacao);
                }

                else
                {
                    throw new Exception("Data inválida");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensagem = "Ocorreu um erro ao buscar as cotações.",
                    Detalhes = ex.Message
                });
            }
        }
    }
}
