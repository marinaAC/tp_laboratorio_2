using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Exepcion de si hay un alumno repetido
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        #region Constructores
        public AlumnoRepetidoException() { }
        #endregion
    }
}
