using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exeptions;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal _limiteDeDescubierto { get; init; }
        public decimal _comision { get; init; }


        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
                  : base(numero, saldo)
        {
            InicializarCuenta(TipoCuenta.CuentaCorriente, titulares);

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

            decimal neto = monto - (monto * _comision);
            AumentarSaldo(neto);
            Console.WriteLine("Deposito realizado con exito\n");
            Console.WriteLine($"Saldo actual: {_saldo:c}\n");
        }

        public void Retirar(decimal monto)
        {
            if (!EstaActiva())
                throw new CuentaNoActivaException(_estado);

            if (monto <= 0)
                throw new MontoNoValidoException();

            if ((_saldo - monto) >= -_limiteDeDescubierto)
            {
                DisminuirSaldo(monto);
                Console.WriteLine("Retiro realizado con éxito \n");
                Console.WriteLine($"Saldo actual: {_saldo:c} \n");

                if (_saldo < 0)
                {
                    Console.WriteLine("La cuenta ha entrado en descubierto. Será suspendida. \n");
                    Suspender();
                }
            }
            else
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
        }
    }
}
