using M1S3_SistemaBanco.Interfaces;
using M1S3_SistemaBanco.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco.Model
{
    public class ClientePF : Cliente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public int Idade { get { return (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25); } private set { } }
        
        public ClientePF()

        {
            IClienteService clienteService = new ClienteService();
        }
        public ClientePF(string nome, DateTime dataNascimento, string cpf,
            int idade, string email, string telefone, string end, int numeroConta, string tipoDeConta)
             : base(email, telefone, end, numeroConta, tipoDeConta)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
            Idade = idade;
        }
        public bool EhMaior()
        {
            if (Idade >= 18)
            {
                return true;
            }
            else { return false; }

        }
    }
}
