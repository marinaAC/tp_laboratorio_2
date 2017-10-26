using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    /// <summary>
    /// Clase que implementara la interfaz pero esta, sera de tipo generic
    /// </summary>
    /// <typeparam name="T">Generic, tipo que se envie por param</typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool returnAux = false;
            XmlTextWriter fl = new XmlTextWriter(archivo,System.Text.Encoding.UTF8);
            if (!object.ReferenceEquals(fl, null))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(fl, datos);
                returnAux = true;
            }
            else 
            {
                throw new Exception();
            }

            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool returnAux = false;
            XmlTextReader fl = new XmlTextReader(archivo);
            if (!object.ReferenceEquals(fl, null))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(fl);
                returnAux = true;
            }
            else 
            {
                throw new Exception();
            }

            return returnAux;
            
        }

       
    }
}
