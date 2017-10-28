using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion DNIINVALIDO
    /// </summary>
    public class DniInvalidoException: Exception
    {
        protected string mensajeBase;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DniInvalidoException() { }

        /// <summary>
        /// recibe una excepcion por parametro
        /// </summary>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(Exception e)
            :base(e.Message,e)
        {
            
        }

        /// <summary>
        /// Recibe un mensaje por parametro
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            :base(message)
        { }

        /// <summary>
        ///  Recibe un mensaje por parametro
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base(message,e) 
        { }
        #endregion
    }
}
