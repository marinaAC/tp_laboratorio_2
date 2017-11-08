using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += ;
                cliente.DownloadStringCompleted += ;

                cliente.DownloadStringAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Realizar un hilo, que se va encargar de ejecutar el iniciar
        //el otro van en paralelo, uno para ver la descarga, y el otro para obtener el html

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
        }
    }
}
