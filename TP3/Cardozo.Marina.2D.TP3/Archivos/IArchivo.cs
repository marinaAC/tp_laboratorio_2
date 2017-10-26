using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interface generica
    /// </summary>
    /// <typeparam name="T">sera del tipo que se ponga en T</typeparam>
    interface IArchivo<T>
    {
        /// <summary>
        /// Guardara un archivo o texto, en donde sea implementado
        /// </summary>
        /// <param name="archivo">tipo string con la ruta</param>
        /// <param name="datos">objeto de tipo t</param>
        /// <returns>true si pudo ser posible, false sino lo es</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Leera un archivo o texto, en donde sea implementado
        /// </summary>
        /// <param name="archivo">tipo string con la ruta</param>
        /// <param name="datos">objeto generico con out para la salida</param>
        /// <returns>true si fue posible, false sino lo fue</returns>
        bool Leer(string archivo, out T datos);
    }
}
