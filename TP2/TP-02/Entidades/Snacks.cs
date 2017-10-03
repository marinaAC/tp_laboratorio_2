using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks:Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor de snack, donde pasa todos los datos del producto utilizando el constructor base
        /// </summary>
        /// <param name="marca">marca a cargar</param>
        /// <param name="patente">patente es el codigo de barras</param>
        /// <param name="color">color a cargar</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                short calorias = 104;
                return calorias;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Sobre escribe el metodo mostrar del base
        /// </summary>
        /// <returns>retorna un string con los datos de los snacks</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("SNACKS");
            sb.AppendLine();
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
