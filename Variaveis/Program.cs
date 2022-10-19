using System;

class Programa
{
    static void Main(string[] args)
    {
        float pontoFlutuante = 3.14f;

        double salario = 3000.10;
        int valor = (int)salario;

        double valor1 = 0.2;
        double valor2 = 0.1;
        double total = valor1 + valor2;

        Console.WriteLine(total);

        char letra = 'a';
        Console.WriteLine(letra);

        letra = (char)(65 + 1);
        Console.WriteLine(letra);

        letra = (char)(86 + 1);
        Console.WriteLine(letra);

        Console.WriteLine("Tecle enter para fechar ...");

        string primeiraFrase = "Alura - Cursos de tecnologia ";
        Console.WriteLine(primeiraFrase + 2022);

        string vazia = "";
        Console.WriteLine(vazia);

        string cursos = @"Cursos disponíveis:
- Go
- C#
- Python
- Java";
        Console.WriteLine(cursos);
        
        
        Console.ReadLine();
    }
}