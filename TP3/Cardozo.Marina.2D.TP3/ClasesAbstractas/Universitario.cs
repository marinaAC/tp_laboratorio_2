using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase universitario, hereda de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region Atributos
        protected int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto publico
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor que llamara al base, pasando todos sus datos por parametros, mas el legajo para poder construir el objeto
        /// </summary>
        /// <param name="legajo">Tipo int, id de la persona</param>
        /// <param name="nombre">string con el nombre de la persona a cargar</param>
        /// <param name="apellido">string con el apellido de la persona a cargar</param>
        /// <param name="dni">string con el dni de la persona a cargar</param>
        /// <param name="nacionalidad">enum de tipo nacionalidad</param>
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
            if(object.ReferenceEquals(obj,null))
            {
                throw new ArgumentNullException();
            }
            else if(obj.GetType() == this.GetType() && ((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo)
            {
                returnAux = true;
            }
            return returnAux;
        }

        /// <summary>
        /// Metodo virtual en el cual traera los datos de base de toString, sumandole la propiedad de la clase
        /// </summary>
        /// <returns>STRING</returns>
        protected virtual string MostrarDato() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Legajo: {0}",this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Clase abstracta donde las clases que hereden de esta, deberan implementar
        /// </summary>
        /// <returns>retornara un string</returns>
        public abstract string ParticiparEnClase();
        #endregion
    }
}
