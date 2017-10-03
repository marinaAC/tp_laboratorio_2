using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo _tipo;

        #region Constructor
        /// <summary>
        /// Constructor que cargara por parametros los datos del producto y recibira el tipo
        /// que por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">marca a cargar</param>
        /// <param name="patente">patente es el codigo de barras</param>
        /// <param name="color">color a cargar</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
            this._tipo = ETipo.Entera;
        }

        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            : base(marca, patente, color)
        {
            this._tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                short calorias = 20;
                return calorias;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Sobre escribe el metodo mostrar del base
        /// </summary>
        /// <returns>retorna un string con los datos de la Leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("LECHE");
            sb.AppendLine();
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : " + this._tipo);
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
