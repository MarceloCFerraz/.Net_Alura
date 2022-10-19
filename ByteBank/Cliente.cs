using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank//.Titular para criar uma ramificação dentro do namespacee ByteBank
{
    public class Cliente
    {
        public string Nome{ get; set; } // propriedades auto implementadas
        public string CPF { get; set; }
        public string Profissao { get; set; }
        public static int Id { get; set; } 
        // este é um campo da classe (global). Não pode ser acessado ou alterado por objetos da classe.
        public Cliente(string nome, string cpf, string profissao)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Profissao = profissao;
            Id += 1;
        }
    }
}
