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
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
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
