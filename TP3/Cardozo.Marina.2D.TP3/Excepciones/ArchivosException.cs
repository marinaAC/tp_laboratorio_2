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
        /// 
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
        { 
           
        }

        public ArchivosException(string men):base(men) { }
        #endregion
    }
}
