using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco.Model
{
    public class ClientePJ : Cliente
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataInauguracao { get; set; }

        public ClientePJ()
        {

        }
        public ClientePJ(string razaoSocial, string cnpj, DateTime dataInauguracao,
            string email, string telefone, string end, int numeroConta, string tipoDeConta)
            : base(email, telefone, end, numeroConta, tipoDeConta)
        {
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            DataInauguracao = dataInauguracao;
        }
        public override void ResumoCliente()
        {
            Console.WriteLine($"Razão social: {RazaoSocial}");
            Console.WriteLine($"Número de conta: {NumeroConta}");
            Console.WriteLine($"CNPJ: {CNPJ}");
            Console.WriteLine($"Tipo de conta: {TipoDeConta}");
        }
    }
}
