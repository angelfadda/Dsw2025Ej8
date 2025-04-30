using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exeptions;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        public decimal tasaDeInteres { get; init; }


        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
                 : base(numero, saldo)
        {
            InicializarCuenta(TipoCuenta.CajaDeAhorro, titulares);
            tasaDeInteres = tasaDeInteres;
        }




        public void Depositar(decimal monto)
        {
            if (!EstaActiva())
            {
                throw new CuentaNoActivaException(_estado);
            }
            if (monto <= 0)
            {
                throw new MontoNoValidoException();
            }
            else
            {
                AumentarSaldo(monto);
                Console.WriteLine("Deposito realizado con exito\n");
                Console.WriteLine($"Saldo actual: {_saldo:c}\n");
            }
        }
        public void Retirar(decimal monto)
        {
            if (!EstaActiva())
            {
                throw new CuentaNoActivaException(_estado);
            }
            if (monto <= 0)
            {
                throw new MontoNoValidoException();
            }
            if (monto < _saldo)
            {
                DisminuirSaldo(monto);
                Console.WriteLine("Retiro realizado con exito\n");
                Console.WriteLine($"Saldo actual: {_saldo:C}\n");
            }
            else
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
        }

        public void AplicarIntereses()
        {
            AumentarSaldo(_saldo * tasaDeInteres);
            Console.WriteLine("Interes aplicados\n");
            Console.WriteLine($"Saldo actual: {_saldo:c}\n");
        }
    }
}
