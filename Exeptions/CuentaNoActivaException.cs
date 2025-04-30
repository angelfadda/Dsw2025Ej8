using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Exeptions
{
    internal class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estado) : base($"No se puede operar con la cuenta {estado} \n") { }
    }
}
