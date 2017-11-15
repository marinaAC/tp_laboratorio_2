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
        #region Constructor
        /// <summary>
        /// Constructor de descargador, se le pasa por parametro una direccion de tipo URI
        /// </summary>
        /// <param name="direccion">link tipo uri</param>
        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = "";
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Realiza la comunicacion, generando dos eventos cuando mientras se realiza la carga y otro cuando termina
        /// </summary>
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
        /// <summary>
        /// Delegado que tendra el puntero del progreso
        /// </summary>
        /// <param name="progreso"></param>
        public delegate void ProgressChangedEvent(int progreso);

        /// <summary>
        /// Evento cargaPorcentaje
        /// </summary>
        public event ProgressChangedEvent cargaPorcentaje;

        /// <summary>
        /// Se realiza la invocacion del evento anterior, dentro del metodo. Este va tomando el valor a medida que se va cargando el progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            cargaPorcentaje(e.ProgressPercentage);
        }

        /// <summary>
        /// Delegado que dira cuando es el final de la carga
        /// </summary>
        /// <param name="url">string de url, que sera el html al cual accedio</param>
        public delegate void FinalDeCarga(string url);
        public event FinalDeCarga htmlFinalizado;

        /// <summary>
        /// Invoca al evento anterior, avisando cual es el resultado final, una vez obtenido, en este caso obtiene el html al cual accedio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string aux =(string)e.Result;
            
            if(aux != "")
            {
                this.html = aux;
                htmlFinalizado(this.html);
            }
        }
        #endregion
    }
}
