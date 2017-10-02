﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks:Producto
    {
        #region Constructores
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
