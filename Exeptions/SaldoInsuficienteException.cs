using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exeptions
{
    internal class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.\n") {}
    }
}
