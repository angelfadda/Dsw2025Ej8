using System.Security.Cryptography.X509Certificates;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exeptions;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] titulares1 = { "Ana", "Luis" };
            string[] titulares2 = { "Carlos", "Maria" };

            var caja1 = new CajaDeAhorro("CA001", 1000, titulares1) { tasaDeInteres = 0.05m };
            var caja2 = new CajaDeAhorro("CA002", 500, titulares2) { tasaDeInteres = 0.03m };

            var corriente1 = new CuentaCorriente("CC001", 100, titulares1)
            {
                _limiteDeDescubierto = 100,
                _comision = 0.02m
            };

            var corriente2 = new CuentaCorriente("CC002", 300, titulares2)
            {
                _limiteDeDescubierto = 150,
                _comision = 0.01m
            };

            void EjecutarOperacion(Action operacion)
            {
                try
                {
                    operacion();
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine($"Error de monto: {ex.Message}");
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine($"Error de estado: {ex.Message}");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine($"Error de saldo: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }

            }
            EjecutarOperacion(() => caja1.Depositar(200));           //OK
            EjecutarOperacion(() => caja1.Retirar(300));             //OK
            EjecutarOperacion(() => caja1.AplicarIntereses());       //OK

            EjecutarOperacion(() => caja1.Depositar(0));             //EX Monto no valido(OK)
            EjecutarOperacion(() => caja2.Retirar(600));             //EX Saldo insuficiente(OK)
            EjecutarOperacion(() => caja2.Depositar(200));           //EX Cuenta no activa (OK)

            EjecutarOperacion(() => corriente1.Depositar(500));      //OK
            EjecutarOperacion(() => corriente1.Retirar(690));        //OK  pero queda en descubirto y la cuenta se suspende
            EjecutarOperacion(() => corriente2.Retirar(500));        //EX saldo insuficiente (Ok)
        }

    }
}
