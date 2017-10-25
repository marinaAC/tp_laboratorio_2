using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool returnAux = false;
            StreamWriter text = new StreamWriter(archivo);
            if (!object.ReferenceEquals(text, null))
            {
                text.Write(datos);
                returnAux = true;
            }
            else
            {
                throw new ArchivoException(new FileNotFoundException());
            }

            return returnAux;
        }

        public bool Leer(string archivo, out string datos)
        {

            throw new NotImplementedException();
        }
    }
}
