using System;
class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Executando o projeto 10 - Calcula Poupança");

        double investimento = 1000;

        // trecho de código omitido

        int mes = 1;

        while (mes <= 12)
        {
            investimento = investimento + investimento * 0.005;
            Console.WriteLine("No mês " + mes + " você tem R$ " + investimento);

            // mes = mes + 1;
            // mes++;
            // ++mes;
            // Console.WriteLine(mes++) Printa e depois acrescenta
            // Console.WriteLine(++mes) Acrescenta e depois printa
            mes += 1;
        }

        for (mes = 1; mes <= 12; mes++)
        {
            investimento = investimento * 1.005;
            Console.WriteLine("No mês " + mes + " você tem R$ " + investimento);
        }

        for (int numero = 0; numero <= 100; numero += 1)
        {
            // numero % 3 == 0 -> mod
            // numero / 3 == 0 -> div
            // (double)numero / 3 == 0.0 -> divisao flutuante
            if (numero % 3 == 0) 
            {
                Console.WriteLine(numero);
            }
        }

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}