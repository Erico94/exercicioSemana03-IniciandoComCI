using M1S3_SistemaBanco.Interfaces;
using M1S3_SistemaBanco.Model;
using Microsoft.AspNetCore.Mvc;

namespace Banco_Api.Controllers
{
    [ApiController]
    [Route("clientes")]

    public class ClientesController : Controller
    {
        IClienteService _clienteService ;

        public ClientesController (IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

    //Listar todos clientes 
        [HttpGet]
        public ActionResult listarClientes()
        {
             return Ok(_clienteService.ExibirClientes());
        }

    //Adicionar cliente PF
        [Route ("adicionar/pf")]
        [HttpPost]
        public ActionResult cadastrarClientepf([FromBody] ClientePF cliente)
        {
            _clienteService.CriarContaPF(cliente);
            return Ok("Cliente pessoa física cadastrado(a) com sucesso");
        }

    //Adicionar cliente PJ
        [Route("adicionar/pj")]
        [HttpPost]
        public ActionResult cadastrarClientepj([FromBody] ClientePJ cliente)
        {
            _clienteService.CriarContaPJ(cliente);
            return Ok("Cliente pessoa jurídica cadastrado(a) com sucesso");
        }

    //Buscar cliente por numero de conta
        [Route("buscarconta/{conta}")]
        [HttpGet]
        public ActionResult buscarPorConta([FromRoute]int conta)
        {
            Cliente busca = _clienteService.BuscarClientePorNumeroDeConta(conta);
            if (busca != null)
            {
                return Ok(_clienteService.BuscarClientePorNumeroDeConta(conta));
            } else { return BadRequest("Cliente não encontrado"); }
        }

    //Atualizar PF pelo Id 
        [Route ("atualizar-conta-pf/{numeroConta}")]
        [HttpPatch]
        public ActionResult atualizarPF_PorId([FromRoute] int numeroConta, [FromBody] ClientePF atualRegistro)
        {
            Cliente antigoRegistro = _clienteService.BuscarClientePorNumeroDeConta(numeroConta);
            if (antigoRegistro != null)
            {
                return Ok(_clienteService.EditarContaPF(atualRegistro, numeroConta, antigoRegistro));
            } else { return BadRequest("Cliente não  encontrado"); }
        }

    //Atualizar PJ pelo Id
        [Route("atualizar-conta-pj/{numeroConta}")]
        [HttpPatch]
        public ActionResult atualizarPJ_PorId([FromRoute] int numeroConta, [FromBody] ClientePJ novoRegistro)
        {
            Cliente antigoRegistro = _clienteService.BuscarClientePorNumeroDeConta(numeroConta);
            if (antigoRegistro != null)
            {
                return Ok(_clienteService.EditarContaPJ(novoRegistro, numeroConta, antigoRegistro));
            } else { return BadRequest("Cliente não encontrado."); }
        }

     //Deletar uma conta
        [Route ("deletar-conta/{numeroConta}")]
        [HttpGet]
        public ActionResult deletarConta([FromRoute] int numeroConta)
        {
           Cliente busca= _clienteService.BuscarClientePorNumeroDeConta(numeroConta);
            if (busca != null)
            {
                if (busca.Saldo == 0)
                {
                    return Ok(_clienteService.DeletarConta(numeroConta, busca));
                }
                else { return BadRequest("Só é permitido deletar contas com saldo igual a R$00,00."); }
            }else { BadRequest("Cliente não encontrado."); }
            return Ok();
        }
    }
}