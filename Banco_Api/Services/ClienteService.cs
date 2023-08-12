
using M1S3_SistemaBanco.Model;
using M1S3_SistemaBanco.Interfaces;

namespace M1S3_SistemaBanco.Services
{
    public class ClienteService : IClienteService
    {
        public static List<Cliente> clientes = new List<Cliente>();
        public ClienteService()
        {
            
        }

        public Cliente BuscarClientePorNumeroDeConta(int conta)
        {
          return clientes.Find ( x => x.NumeroConta == conta);
        }


        public List<Cliente>  ExibirClientes()
        {
                return clientes;
        }


        public void CriarContaPF(ClientePF cliente)
        {
            clientes.Add(cliente);
        }


        public void CriarContaPJ(ClientePJ cliente)
        {
            clientes.Add(cliente);
        }


        public string EditarContaPF(ClientePF novoRegistro, int numeroConta, Cliente antigoRegistro)
        {
            antigoRegistro.Email = novoRegistro.Email;
            antigoRegistro.Endereco = novoRegistro.Endereco;
            antigoRegistro.Telefone = novoRegistro.Telefone;
            return "Conta editada com sucesso.";
        }

        public string EditarContaPJ(ClientePJ novoRegistro, int numeroConta, Cliente antigoRegistro)
        {
            antigoRegistro.Email = novoRegistro.Email;
            antigoRegistro.Endereco = novoRegistro.Endereco;
            antigoRegistro.Telefone = novoRegistro.Telefone;
            return "Conta editada com sucesso.";
        }


        public string DeletarConta(int numeroConta, Cliente busca)
        {
                clientes.Remove(busca);
                return "Conta deletada com sucesso.";
        }


        public string AdicionarTransacao(int numeroconta, Transacao transacao, Cliente busca)
        {
           
            if (busca != null)
            {
                busca.Extrato.Add(transacao);
                return "Transação efetivada com sucesso.";
            }else { return "Cliente não encontrado."; }

        }


        public List<Transacao> Extrato(int numeroConta)
        {
            Cliente busca = BuscarClientePorNumeroDeConta(numeroConta);
            return busca.Extrato;
        }

        
    }
}
