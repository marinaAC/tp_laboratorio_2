using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NavegadorException :Exception
    {
        /// <summary>
        /// Constructor de excepcion que recibe solo un mensaje
        /// </summary>
        /// <param name="mens"></param>
        public NavegadorException(string mens) : base(mens) { }

        /// <summary>
        /// Constructor de excepcion que recibe mensaje + la excepcion
        /// </summary>
        /// <param name="mens"></param>
        /// <param name="innerException"></param>
        public NavegadorException(string mens, Exception innerException) : base(mens, innerException) { }
    }
}
