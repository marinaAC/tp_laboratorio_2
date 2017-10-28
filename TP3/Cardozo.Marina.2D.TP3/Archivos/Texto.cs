using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase texto que implementa la interfaz archivo, dandole un tipo string
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo para guardar un archivo, confirmara que el archivo exista y no sea null, si es asi guardara los archivos
        /// alli, sino creara el archivo en la ruta pasada por parametro y guardara los datos pasados por parametros
        /// </summary>
        /// <param name="archivo">String con la ruta y nombre del archivo</param>
        /// <param name="datos">string datos a guardar</param>
        /// <returns>True: si pudo guardarse, lanzara una excepcion en el caso que el archivo sea null o no se haya podido ejecutar la primera
        /// instancia, false: en el caso que no pudo ser guardado</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool returnAux = false;
            StreamWriter text = new StreamWriter(archivo);
            if (!object.ReferenceEquals(text, null) && !object.ReferenceEquals(datos,null))
            {
                text.Write(datos);
                returnAux = true;
            }
            else
            {
                throw new ArchivosException("No pudo abrirse el archivo");
            }
            text.Close();

            return returnAux;
        }

        /// <summary>
        /// Leera un archivo en el cual se le pasan por parametro la ruta y el atributo donde debe ser guardado
        /// </summary>
        /// <param name="archivo">String con la ruta y nombre del archivo</param>
        /// <param name="datos">string datos a leer</param>
        /// <returns>True si pudo ingresarse y guardar el string leido en la variable pasa por param, lanzara una excepcion en el 
        /// caso de que no pueda ser posible la lectura, False: si fallo el if</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool returnAux = false;
            StreamReader fl = new StreamReader(archivo);
            if (!object.ReferenceEquals(fl, null))
            {
                datos = fl.ReadToEnd();
            }
            else 
            {
                throw new ArchivosException(new FileNotFoundException());
            }
            fl.Close();
            return returnAux;
        }
    }
}
