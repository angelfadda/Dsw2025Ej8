using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exeptions
{
    internal class MontoNoValidoException : Exception
    {
        
    public MontoNoValidoException() : base("El monto ingresado no es válido para la operación solicitada \n") { }
    }
}

