using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string escolhaUsuario = OpcaoUsuario();
            while (escolhaUsuario != "X")
            {
                switch (escolhaUsuario)
                {
                    case ("1"):
                        ListarContas();
                        break;
                    case ("2"):
                        InserirConta();
                        break;
                    case ("3"):
                        Transferir();
                        break;
                    case ("4"):
                        Sacar();
                        break;
                    case ("5"):
                        Depositar();
                        break;
                    case ("C"):
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                escolhaUsuario = OpcaoUsuario();

            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar:");
            Console.Write("Digite o número da Conta: ");
            int nConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine().Replace(',', '.'));

            listaContas[nConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Sacar");
            Console.Write("Digite o número da Conta: ");
            int nConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine().Replace(',', '.'));

            listaContas[nConta].Sacar(valorSaque);

        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir");
            Console.Write("Digite o número da Conta origem: ");
            int nContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da Conta destino: ");
            int nContadestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferir = double.Parse(Console.ReadLine().Replace(',', '.'));

            listaContas[nContaOrigem].Transferencia(valorTransferir,listaContas[nContadestino]);

        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }

        private static void ListarContas()
        {
            int n_conta = 0;
            Console.WriteLine("Listar Contas");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastada");
                return;
            }
            foreach (Conta conta in listaContas)
                Console.WriteLine($"#{n_conta++.ToString()} - {conta.ToString()}");
            
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica");
            int tipo_conta = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Digite o Nome do Cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Digite o Saldo Inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Digite o Credito: ");
            double creditoInicial = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            listaContas.Add(new Conta(tipo: (TipoConta)tipo_conta,saldo: saldoInicial,credito: creditoInicial,nome: nomeCliente));

        }
    }
}
