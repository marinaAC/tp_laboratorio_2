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
        public Texto(string archivo)
        {
            FileStream fp = new FileStream(archivo, FileMode.Append);
            if (!ReferenceEquals(null, fp))
            {
                throw new FileNotFoundException("No pudo encontrarse el archivo");
            }
            else 
            {
                this.archivo = fp;
            }

        }


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

        public bool leer(out List<string> datos)
        {
            bool returnAux = false;
            BinaryFormatter ser = new BinaryFormatter();
            //datos = ser.Deserialize(this.archivo);
            this.archivo.Close();
        }
    }
}
