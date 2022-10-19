using ByteBank;
using ByteBank.Util;
using bytebank_ADM.SistemaInterno;

public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel, IBonificavel
{
    protected FuncionarioAutenticavel(string nome, string cpf, double salario) : base(nome, cpf, salario)
    {
    }

    public string Senha { get; set; }
    
    public bool Autenticar(string senha)
    {
        return Senha == senha;
    }

    public abstract double getBonificacao();
}