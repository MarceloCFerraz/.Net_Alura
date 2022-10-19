using ByteBank;

class Programa
{
    public static void Main(string[] args)
    {
        SistemaInterno sistemaInterno = new SistemaInterno();

        //Código omitido.

        Diretor bernardo = new Diretor("André Silva", "000.000.000-00", 5000);
        bernardo.Nome = "Bernardo";
        bernardo.Login = "bernardo@email.com";
        bernardo.Senha = "flaflu2019";

        sistemaInterno.Logar(bernardo, bernardo.Senha, bernardo.Login);
    }
}