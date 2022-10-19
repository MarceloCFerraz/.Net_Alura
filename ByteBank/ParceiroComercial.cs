using bytebank_ADM.SistemaInterno;

public class ParceiroComercial : IAutenticavel
{
    public string Senha { get; set; }

    public bool Autenticar(string senha)
    {
        return this.Senha == senha;
    }
}