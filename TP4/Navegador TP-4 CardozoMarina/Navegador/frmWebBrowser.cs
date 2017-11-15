using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;
        private Descargador desc;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
            
            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            { 
                tspbProgreso.Value = progreso;
            }

            
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            try
            {
                if (rtxtHtmlCode.InvokeRequired)
                {
                    FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                    this.Invoke(d, new object[] { html });
                }
                else
                {
                    rtxtHtmlCode.Text = html;
                    Uri aux;
                    this.checkUrl(out aux);
                    archivos.guardar(aux.ToString());
                }
            }
            catch (Exception e)
            {
                
                MessageBox.Show("PROBLEMAS" + e.ToString());
            }
            

        }
        /// <summary>
        /// Ejecuto el metodo descargar, para realizar la conexion, a este metodo
        /// se le asigan los dos eventos en descargador, para avisar cuando es que se finalizo de ejecutar los eventos
        /// A su vez, se ejecuta un hilo, para que vayan los dos procesos en paralelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {

            Uri aux;
            this.checkUrl(out aux);
            this.desc = new Descargador(aux);
            Thread hilo = new Thread(this.desc.IniciarDescarga);
            hilo.Start();
            this.desc.cargaPorcentaje += ProgresoDescarga;
            this.desc.htmlFinalizado += FinDescarga;
        }


        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmHistorial frmHistorial = new frmHistorial();
            frmHistorial.ShowDialog();
           
        }

        /// <summary>
        /// Chequeo que la url contenta http, sino lo contiene se lo agrego guardando en una variable de tipo URI
        /// </summary>
        /// <param name="url"></param>
        private void checkUrl(out Uri url)
        {
            string aux = this.txtUrl.Text;
            if (!aux.Contains("http://"))
            {
                string urlAux = string.Format("http://{0}", this.txtUrl.Text);
                url = new Uri(urlAux);
            }
            else 
            {
                url = new Uri(aux);
            }
        }

    }
}
