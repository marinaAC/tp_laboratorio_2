using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase que implementara la interfaz pero esta, sera de tipo generic
    /// </summary>
    /// <typeparam name="T">Generic, tipo que se envie por param</typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Genera un archivo si no existe, o lo guarda en el lugar correspondiente. Utilizando el encondign utf-8
        /// Si el archivo no es null grabara los datos pasados en un xml
        /// </summary>
        /// <param name="archivo">Path y nombre del archivo</param>
        /// <param name="datos">Objeto a guardar</param>
        /// <returns>True: si pudo ser guardado, false: si no pudo ser guardado</returns>
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
                throw new ArchivosException("No pudo abrirse el archivo, no pudo ser guardado");
            }

            return returnAux;
        }

        /// <summary>
        /// Lee el archivo xml y lo serializa en el tipo que se le pase.
        /// </summary>
        /// <param name="archivo">Path y nombre del archivo</param>
        /// <param name="datos">objeto en el cual se serializala</param>
        /// <returns>True si pudo leer y serealizar el objeto, false sino pudo acceder al archivo</returns>
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
