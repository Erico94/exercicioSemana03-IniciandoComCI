using M1S3_SistemaBanco.Interfaces;
using M1S3_SistemaBanco.Model;
using Microsoft.AspNetCore.Mvc;

namespace Banco_Api.Controllers
{
    [Route("transacao")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {

        IClienteService _clienteService;

        public TransacoesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //Adicinar transação
        [Route("{numeroconta}")]
        [HttpPost]
        public ActionResult adicionarTransacao([FromRoute] int numeroConta, [FromBody] Transacao transacao)
        {
            Cliente busca = _clienteService.BuscarClientePorNumeroDeConta(numeroConta);
            if (busca != null)
            {
                return Ok(_clienteService.AdicionarTransacao(numeroConta, transacao, busca));
            }
            else { return BadRequest("Cliente não encontrado."); }
        }


        //Visualizar saldo
        [Route("extrato/{numeroconta}")]
        [HttpGet]
        public ActionResult verificarExtrato([FromRoute] int numeroconta)
        {
            Cliente cliente = _clienteService.BuscarClientePorNumeroDeConta(numeroconta);
            if (cliente != null)
            {
                return Ok(_clienteService.Extrato(numeroconta));
            }
            else { return BadRequest("Cliente não encontrado."); }
        }


    }
}
