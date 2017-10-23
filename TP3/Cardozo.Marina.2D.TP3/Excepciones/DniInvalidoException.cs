using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Chequear!
    /// </summary>
    public class DniInvalidoException: Exception
    {
        protected string mensajeBase;

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public DniInvalidoException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            :base ("",e)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            :base(message)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base(message,e) 
        { }
        #endregion
    }
}
