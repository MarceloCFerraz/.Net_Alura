public class SistemaInterno
{
    public bool Logar(FuncionarioAutenticavel funcionario, string senha, string login)
    {
        bool usuarioAutenticado = funcionario.Autenticar(senha);

        if (usuarioAutenticado)
        {
            Console.WriteLine("Bem-vindo ao sistema!");
            Console.WriteLine(funcionario.getBonificacao()); ;
        }
        else
            Console.WriteLine("Senha incorreta!");
        return usuarioAutenticado;
    }
}