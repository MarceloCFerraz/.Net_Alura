using ByteBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    // Classes abstratas não podem ser instanciadas.
    public abstract class Funcionario
    {
        public string Login { get; set; }
        public string Senha { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }
        public static int Id { get; set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Salario = salario;
            Id += 1;
        }

        // virtual é para dizer ao compilador que esse método PODE ser reescrito na classe filha e ignorado o original
        // Métodos abstratos só podem existir em classes abstratas
        public abstract void AumentarSalario();
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
