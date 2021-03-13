using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();//conforme eu for cadastrando as contas novas elas vão ser inseridas na lista Conta
        static void Main(string[] args)
        {  
            /*//Criando minha conta    //|        enum     |   saldo|crédito| nome  
           Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Ralf Prezia");

           Console.WriteLine(minhaConta.ToString());*/

           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                    break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                    break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
               }  

               opcaoUsuario = ObterOpcaoUsuario(); 

           }

           Console.WriteLine("Obrigado por utilizar nossos serviços.\nCENTRAL DE ATENDIMENTO 24h\nLigue para 0800 xxx xxxx");
           
        }

        

        private static void Depositar()
        {
            Console.WriteLine("DEPÓSITOS REALIZADOS APÓS O HORÁRIO DE EXPEDIENTE BANCÁRIO\nOU AOS SÁBADOS, DOMINGOS E FERIADOS/nESTÃO SUJEITOS A EFETIVAÇÃO SOMENTE\nNO DECORRER DO PRÓXIMO DIA ÚTIL.\n");
          
             Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor para deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor para saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);//pega uma conta do índice digitado e saca um valor do objeto
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor para saque: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Cadastrar nova conta");
            
            Console.WriteLine("Digite 1 para Conta Físisca\nDigite 2 para Conta Juridica");//enum
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,//criando
                                                              saldo: entradaSaldo,    //um
                                                              credito: entradaCredito,   //novo
                                                              nome: entradaNome);            //objeto com conversão explicita para o enum
            
            listContas.Add(novaConta);

        }

         private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            //Se a conta não existir no cadastro, mensagem será enviada
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            //Tendo conta cadastrada entra no for
            for (int i = 0; i < listContas.Count; i++)
            { 
                Conta conta = listContas[1];// cria obj & "popula" obj
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);//executa o ToString
            }
        }

        private static string ObterOpcaoUsuario()//método para mostrar as opções do switch
        {
            Console.WriteLine();
            Console.WriteLine("Dev Bank com você, 24 horas por dia e 7 dias por semana!");
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferências de valores");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Depositos");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
