using System;
class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Executando o projeto 7 - Condicionais");

        int idadeJoao = 16;
        int quantidadePessoas = 2;
        bool acompanhado = quantidadePessoas > 1;

        if (idadeJoao >= 18 || acompanhado)
        {
            Console.WriteLine("Pode entrar!");
        }
        else
        {
            Console.WriteLine("Não pode entrar!");
        }

        int mes = 10;

        switch (mes)
        {
            case 1:
                Console.WriteLine("O mês é Janeiro");
                break;
            case 2:
                Console.WriteLine("O mês é Fevereiro");
                break;
            case 3:
                Console.WriteLine("O mês é Março");
                break;
            case 4:
                Console.WriteLine("O mês é Abril");
                break;
            case 5:
                Console.WriteLine("O mês é Maio");
                break;
            case 6:
                Console.WriteLine("O mês é Junho");
                break;
            case 7:
                Console.WriteLine("O mês é Julho");
                break;
            case 8:
                Console.WriteLine("O mês é Agosto");
                break;
            case 9:
                Console.WriteLine("O mês é Setembro");
                break;
            case 10:
                Console.WriteLine("O mês é Outubro");
                break;
            case 11:
                Console.WriteLine("O mês é Novembro");
                break;
            case 12:
                Console.WriteLine("O mês é Dezembro");
                break;
            default:
                Console.WriteLine("Mês inválido");
                break;
        }

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}