using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.Write("Digite um número inteiro: ");
        int numero = Convert.ToInt32(Console.ReadLine()); // converter string para inteiro
        int fatorial = numero;

        for (; numero > 1; numero--)
        {
            if (numero - 1 >= 2)
            
                Console.Write(numero + " * ");
            else
                Console.Write(numero + " * 1 = ");

            fatorial = fatorial * (numero - 1);
        }
        Console.WriteLine(fatorial);

        Console.ReadKey();
    }
}