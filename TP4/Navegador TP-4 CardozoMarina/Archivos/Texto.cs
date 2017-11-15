using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        protected string archivo;

        #region Constructores
        /// <summary>
        /// Constructor de texto, recibe por parametro el nombre del archivo
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        public Texto(string archivo)
        {
            this.archivo = archivo;
        }
        #endregion
        //**************
        //NOTA: Por momentos no me toma la referencia del Archivo Excepciones y tengo que buildear para que sea asi
        #region Metodos
        /// <summary>
        /// Implemento los metodos de la interfaz, genero un nuevo archivo si es que no existe, sino lo guardo en el anterior
        /// </summary>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool returnAux = false;
            
            StreamWriter fl = File.AppendText(this.archivo);
            if (datos != "" && !ReferenceEquals(fl, null))
            {
                fl.WriteLine(datos);
                returnAux = true;
            }
            else 
            {
                throw new NavegadorException("No pudo abrirse el archivo");
            }
            fl.Close();
            return returnAux;
        }

        /// <summary>
        /// Implemento los metodos de la interfaz, leo todo el archivo, verifico que no sea null, y lo guardo en una lista
        /// </summary>
        /// <param name="datos">Lista donde sera guardado</param>
        /// <returns>False si no se ejecuto la accion, true si se ejecuto</returns>
        public bool leer(out List<string> datos)
        {
            bool returnAux = false;
            datos = new List<string>();
            StreamReader fl = new StreamReader(this.archivo);
            if (!ReferenceEquals(fl, null) && !ReferenceEquals(datos, null))
            {
                while (!fl.EndOfStream)
                {
                    datos.Add(fl.ReadLine());
                }
                returnAux = true;
            }
            else 
            {
                throw new NavegadorException("No pudo abrirse el archivo");
            }
            
            fl.Close();
            return returnAux;
        }
        #endregion
    }
}
