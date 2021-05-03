using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        public bool Sacar(double valorSaque)
        {
            //Validação para verifcar se o saque não ultrapassa o crédito disponível
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque;

            Console.WriteLine("Saque realizado com sucesso! Saldo atual da conta é de {0}", this.Saldo);

            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Depósito realizado com sucesso! Saldo atual da conta é de {0}", this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);

                Console.WriteLine("Transferência realizada com sucesso para a conta {0} no valor de {1}", contaDestino, valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}