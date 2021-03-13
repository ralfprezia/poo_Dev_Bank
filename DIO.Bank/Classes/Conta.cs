using System;
namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }//propriedades

        private double Saldo { get; set; }//propriedades

        private double Credito { get; set; }//propriedades

        private string Nome { get; set; }//propriedades

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)//metodo CONSTRUTOR
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito*-1)){   //se este valor de saque for meaior que o saldo + o credito
                Console.WriteLine("Saldo insuficiente para saque.\nFaça um empréstimo, entre em contato na agência mais próxima de você!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)//método que transefere um valor uma conta para outra
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()//sobreescrevo as caracteristicas no objeto(USADO PARA SALVAR UM LOG" descobrir o que esta acontecendo com a minha aplicação)
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            return retorno;
        }
    }
}