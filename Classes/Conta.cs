using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipo, double saldo, double credito, string nome)
        {
            this.TipoConta = tipo;
            this.Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Verifica se tem saldo e credito suficiente para sacar
            if ((Saldo - valorSaque) < Credito * (-1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");

            return true;
        }

        public void Depositar(double valorDepositado)
        {
            Saldo += valorDepositado;

            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + TipoConta + " | ";
            retorno += "Nome: " + Nome + " | ";
            retorno += "Saldo: " + Saldo + " | ";
            retorno += "Crédito: " + Credito;
            return retorno;
        }
    }
}
