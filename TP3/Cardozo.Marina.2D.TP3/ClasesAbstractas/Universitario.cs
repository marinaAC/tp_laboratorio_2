using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        protected int legajo;

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base(nombre,apellido, dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retornara que un universitario es igual, si son del mismo tipo, y su dni o legajo son iguales
        /// </summary>
        /// <param name="pg1">Objeto de tipo universitario para comparar</param>
        /// <param name="pg2">Objeto de tipo universitario para comparar</param>
        /// <returns>Retorna true, si son iguales y false si no son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool returnAux = false;
            if(pg1.Equals(pg2))
            {
                returnAux = true;
            }
            return returnAux;
        }

        /// <summary>
        /// Sobreescritura de distinto para saber si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Objeto de tipo universitario para comparar</param>
        /// <param name="pg2">Objeto de tipo universitario para comparar</param>
        /// <returns>True si son distintos, False si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            bool returnAux = true;
            if(pg1==pg2)
            {
                returnAux = false;
            }
            return returnAux;
        }

        /// <summary>
        /// Sobreescritura de Equals para saber si dos objetos son del mismo tipo
        /// CHEQUEAR!
        /// </summary>
        /// <param name="obj">Objeto de tipo universitario</param>
        /// <returns>True si son iguales, False si son distintos</returns>
        public override bool Equals(object obj)
        {
            bool returnAux = false;
            if(obj == null)
            {
                //Esto deberia lanzar una excepcion! Preguntar
                returnAux = false;
            }
            if (obj.GetType() == this.GetType() && ((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo)
            {
                returnAux = true;
            }
            return returnAux;
        }

        /// <summary>
        /// Chequear
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDato() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0},{1}",this._apellido,this._nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}",this._nacionalidad);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendFormat("Legajo: {0}",this.legajo);

            return sb.ToString();
        }

        public abstract string ParticiparEnClase();
        #endregion
    }
}
