
using M1S3_SistemaBanco.Model;

namespace M1S3_SistemaBanco.Interfaces
{
    public interface IClienteService
    {
        void CriarContaPF(ClientePF cliente);
        void CriarContaPJ(ClientePJ cliente);
        List<Cliente> ExibirClientes();
        public Cliente BuscarClientePorNumeroDeConta(int conta);
        public string EditarContaPF(ClientePF atualRegistro, int numeroConta, Cliente antigoRegistro);
        public string EditarContaPJ(ClientePJ novoRegistro, int numeroConta, Cliente antigoRegistro );
        public string DeletarConta(int numeroConta, Cliente busca);
        public string AdicionarTransacao(int numeroConta, Transacao transacao, Cliente busca);
        public List<Transacao> Extrato(int numeroConta);


    }
}
