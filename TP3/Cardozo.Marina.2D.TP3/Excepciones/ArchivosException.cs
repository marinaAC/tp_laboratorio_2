using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: FileNotFoundException
    {
       
        #region Constructores
        /// <summary>
        /// Constructor que recibe la excepcion
        /// </summary>
        /// <param name="innerException">exception</param>
        public ArchivosException(Exception innerException){}    

        /// <summary>
        /// Constructor que recibe un mensaje por param
        /// </summary>
        /// <param name="men">string mensaje a cargar</param>
        public ArchivosException(string men):base(men) { }
        #endregion
    }
}
