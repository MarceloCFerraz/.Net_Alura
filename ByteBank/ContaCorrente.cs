namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular{ get; set; }
        public string Conta { get; } // deixando somente o get torna o atributo readonly, podendo ser alterado somente no construtor
        public int Numero_agencia { get; }// deixando somente o get torna o atributo readonly, podendo ser alterado somente no construtor
        public string Nome_agencia { get; set; }
        
        private double saldo;
        public double Saldo // Só é necessário separar um campo private de uma propriedade auto implementada quando for colocar alguma condição no set ou no get
        {
            get { return saldo; }  
            set { if (value > 0) saldo = value; }
        } // Declarando a "propriedade" Saldo

        public static int Id { get; set; } 
        // este é um campo da classe (global). Não pode ser acessado ou alterado por objetos da classe.

        public ContaCorrente(Cliente titular, string conta, int num_agencia, string nome_agencia, double saldo)
        {
            this.Saldo = saldo;
            this.Nome_agencia = nome_agencia;
            this.Numero_agencia = num_agencia;
            this.Conta = conta;
            this.Titular = titular;
            Id += 1;
        }

        public bool Sacar(double dinheiro)
        {
            double aux = this.saldo;

            if (this.saldo >= dinheiro)
                this.saldo -= dinheiro;

            return (aux >= dinheiro);
        }

        public void Depositar(double dinheiro)
        {
            if (dinheiro > 0)
                this.saldo += dinheiro;
        }

        public bool Transferir(double dinheiro, ContaCorrente contaDestino)
        {
            bool retorno = true;

            if (dinheiro > this.saldo)
                retorno = false;
            // não possui saldo suficiente
            else
            {
                this.saldo -= dinheiro;
                contaDestino.Depositar(dinheiro);
            }

            return retorno;
        }
    }
}