using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace RecuperatorioTp1
{
    public partial class LaCalculadora : Form
    {
        
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNum1.Text = null;
            this.txtNum2.Text = null;
            this.lblRta.Text = null;
            this.cmbOperator.Text = null;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNum1.Text;
            string numero2 = this.txtNum2.Text;
            string operador = this.cmbOperator.Text;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            Calculadora c = new Calculadora();
            double resultAux = c.Operar(n1, n2, operador);
            this.lblRta.Text = resultAux.ToString();
        }

        private void btnConvertDecimal_Click(object sender, EventArgs e)
        {
            if(this.lblRta.Text!= null)
            {
                double returnAux = Numero.DecimalBinario(this.lblRta.Text);
                this.lblRta.Text = returnAux.ToString();
            }
            
        }

        private void btnConvertBinario_Click(object sender, EventArgs e)
        {
            if (this.lblRta.Text != null)
            {
                this.lblRta.Text = Numero.BinarioDecimal(this.lblRta.Text);
            }
        }
    }
}
