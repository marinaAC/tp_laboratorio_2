using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException() { }

        /// <summary>
        /// Constructor que utiliza el base
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje):base(mensaje) { }
        #endregion
    }
}
