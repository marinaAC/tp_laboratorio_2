using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;

        #region Constructor
        /// <summary>
        /// Constructor publico, que recibira los atributos por parametro para la construccion del objeto
        /// </summary>
        /// <param name="marca">Marca a guardar</param>
        /// <param name="codigoBarras">Codigo de barras a guardar</param>
        /// <param name="colorPrimario">Color primario a guardar</param>
        public Producto(EMarca marca, string codigoBarras, ConsoleColor colorPrimario) 
        {
            this._marca = marca;
            this._codigoDeBarras = codigoBarras;
            this._colorPrimarioEmpaque = colorPrimario;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Retornara la cantidad de calorias del producto, sera solo de tipo lectura
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public virtual string Mostrar()
        {          
            string aux = (string)this;
            return aux;
        }

        /// <summary>
        /// Se sobrecargar el operador string, traera en formato string todos los datos del producto
        /// todos los datos del objeto para imprimir
        /// </summary>
        /// <param name="p">producto a imprimir</param>
        /// <returns>string</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">producto 1 a comparar</param>
        /// <param name="v2">producto 2 a comparar</param>
        /// <returns>retorna false si no son iguales, true si son iguales</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool returnAux = false;
            if (v1._codigoDeBarras == v2._codigoDeBarras) 
            {
                returnAux = true;
            }
            return returnAux;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">producto 1 a comparar</param>
        /// <param name="v2">producto 2 a comparar</param>
        /// <returns>retorna false si son iguales, true si son distintos</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            bool returnAux = true;
            if(v1 == v2)
            {
                returnAux = false;
            }
            return returnAux;
        }
        #endregion 
    }
}
