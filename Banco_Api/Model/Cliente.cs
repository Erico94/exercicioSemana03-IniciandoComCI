using System.Text.Json.Serialization;


namespace M1S3_SistemaBanco.Model
{
    [JsonDerivedType(typeof(ClientePF))]
    [JsonDerivedType(typeof(ClientePJ))]
    public abstract class Cliente
    {
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int NumeroConta { get; set; }
        public string TipoDeConta { get; set; }
        public double Saldo { get { return GetSaldo(); } private set { } }
        public List<Transacao> Extrato { get; set; }

        
        public Cliente()
        {
            Extrato = new List<Transacao>();
        }
        public Cliente(string email, string telefone,
                       string end, int numeroConta, string tipoDeConta) : this()
        {
            Email = email;
            Telefone = telefone;
            Endereco = end;
            NumeroConta = numeroConta;
            TipoDeConta = TipoDeConta;

        }
        private double GetSaldo()
        {
            double saldo = 0;
            foreach (Transacao transacao in Extrato)
            {
                saldo += transacao.Valor;
            }
            return saldo;
        }
        public virtual void ResumoCliente()
        {

        }
    }
}