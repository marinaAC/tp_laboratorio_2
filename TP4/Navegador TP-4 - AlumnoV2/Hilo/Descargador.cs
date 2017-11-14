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
            this.direccion = direccion;
            this.html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Realizar un hilo, que se va encargar de ejecutar el iniciar


        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

        }
    }
}
