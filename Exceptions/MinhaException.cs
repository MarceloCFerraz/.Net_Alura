using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class MinhaException : Exception
    {
        public MinhaException() { }
        public MinhaException(string mensagem) : base(mensagem){ }
        public MinhaException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
