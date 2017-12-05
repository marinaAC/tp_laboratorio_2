using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de Dulce, donde pasa todos los datos del producto utilizando el constructor base
        /// </summary>
        /// <param name="marca">marca a cargar</param>
        /// <param name="patente">patente es el codigo de barras</param>
        /// <param name="color">color a cargar</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                short calorias = 80;
                return calorias;
            }
        }

        /// <summary>
        /// Sobre escribe el metodo mostrar del base
        /// </summary>
        /// <returns>retorna un string con los datos del Dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("DULCE");
            sb.AppendLine();
            sb.AppendLine( base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
