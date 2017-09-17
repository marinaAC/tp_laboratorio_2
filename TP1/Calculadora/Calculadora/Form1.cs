using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class formCaluladora : Form
    {
        static string numero1;
        static string numero2;
        static string operatorString;
        static double resultAux;
        
        public formCaluladora()
        {
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = null;
            this.txtNumero2.Text = null;
            this.cmbOperacion.Text = null;
            this.lblResultado.Text = null;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            numero1 = this.txtNumero1.Text;
            numero2 = this.txtNumero2.Text;
            operatorString = this.cmbOperacion.Text;
            Numero num = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculoOperar = new Calculadora();
            resultAux = calculoOperar.Operar(num, num2, operatorString);
            this.lblResultado.Text = resultAux.ToString();

        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
