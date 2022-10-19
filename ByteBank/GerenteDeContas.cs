using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class GerenteDeContas : FuncionarioAutenticavel
    {
        public GerenteDeContas (string nome, string cpf, double salario) : base(nome, cpf, salario) { }

        public override void AumentarSalario()
        {
            this.Salario *= 1.35;
        }

        // override é para reescrever o método para a classe filha
        public override double getBonificacao()
        {
            double bonificacao = this.Salario;

            // "base.getBonificacao();"
            // base é para invocar a implementação de algum método ou algum campo da classe pai
            return bonificacao * 0.1;
        }
    }
}
