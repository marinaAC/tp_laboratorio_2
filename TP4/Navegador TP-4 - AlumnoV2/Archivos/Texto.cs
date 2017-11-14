using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        protected FileStream archivo;

        #region Propiedades
        /// <summary>
        /// Realizo la validacion de que el string pasado por parametro sea una direccion valida y pueda generar
        /// o abrir el archivo correctamente, si es que no se puede, lanzo una execpcion
        /// </summary>
        public string Archivo 
        {
            set 
            {
                FileStream fp = new FileStream(value, FileMode.Append);
                if (!ReferenceEquals(null, fp))
                {
                    throw new FileNotFoundException("No pudo encontrarse el archivo");
                }
                else
                {
                    archivo = fp;
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Utilizo la propiedad Archivo con el constructor
        /// </summary>
        /// <param name="archivo">string recibido por parametro</param>
        public Texto(string archivo)
        {
            this.Archivo = archivo;
        }
        #endregion

        #region Metodos
        public bool guardar(string datos)
        {
            bool returnAux = false;
            BinaryFormatter ser = new BinaryFormatter();
            if(datos != "")
            {
                ser.Serialize(this.archivo, datos);
                returnAux = true;
            }
            this.archivo.Close();
            return returnAux;
        }

        /*
         ver con fede
         */
        public bool leer(out List<string> datos)
        {
            bool returnAux = false;
            BinaryFormatter ser = new BinaryFormatter();
            byte[] bytes = new byte[this.archivo.Length];
            int numBytesALeer = (int)this.archivo.Length;
            int numBytesLeidos= 0;
            while(numBytesALeer > 0)
            {
                //Leo los bytes del archivo
                int n = this.archivo.Read(bytes, numBytesLeidos, numBytesALeer);

                //Cuando es igual a 0 se que termino
                if (n == 0) 
                {
                    break;
                }
                string linea = (string)ser.Deserialize(this.archivo);


                numBytesLeidos += n;
                numBytesALeer -= n;
            }



            //datos = ser.Deserialize(this.archivo);
            this.archivo.Close();
            return returnAux;
        }
        #endregion
    }
}
