namespace Exceptions
{
    class Excecoes
    {
        static void Main(string[] args)
        {
            int dividendo = 5000, divisor = 0;

            try
            {
                Console.WriteLine(Dividir(dividendo, divisor));
            }
            catch (Exception excecao)
            {
                Console.WriteLine(excecao.Message);
                Console.WriteLine(excecao.StackTrace);
            }
            finally
            {
                Console.WriteLine("Essa linha será executada tendo ocorrido uma exceção ou não!");
                // como substituir essa estrutura toda por um using (syntax sugar):
                // https://cursos.alura.com.br/course/c-sharp-entendendo-excecoes/task/108035
            }

            Console.ReadKey();
        }

        public static double Dividir(int dividendo, int divisor)
        {
            if (divisor == 0)
            {
                throw new MinhaException("O divisor é 0. Divisão impossível de ser realizada!");
            }
            return dividendo / divisor;
        }
    }
}