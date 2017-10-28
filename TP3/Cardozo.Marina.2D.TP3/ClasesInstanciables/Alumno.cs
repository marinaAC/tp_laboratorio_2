using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase que no podra heredar, si recibe una herencia de Universitario
    /// </summary>
    public sealed class Alumno:Universitario
    {
        #region Atributos
        public enum EEstadoCuenta { Deudor, AlDia, Becado}
        protected Universidad.EClases _queClasesToma;
        protected EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor que recibira por parametro todos los datos del alumno
        /// </summary>
        /// <param name="id">legajo de tipo int</param>
        /// <param name="nombre">nombre a cargar de tipo string</param>
        /// <param name="apellido">apellido a cargar de tipo string</param>
        /// <param name="dni">dni a cargar de tipo string</param>
        /// <param name="nacionalidad">enum del tipo nacionalidad</param>
        /// <param name="clasesQueToma">enum de las clases, que se encuentran en la clase universidad</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) 
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._queClasesToma = clasesQueToma;
        }

        /// <summary>
        /// Construstor que reutiliza el constructor anterior
        /// </summary>
        /// <param name="id">legajo de tipo int</param>
        /// <param name="nombre">nombre a cargar de tipo string</param>
        /// <param name="apellido">apellido a cargar de tipo string</param>
        /// <param name="dni">dni a cargar de tipo string</param>
        /// <param name="nacionalidad">enum del tipo nacionalidad</param>
        /// <param name="clasesQueToma">enum de las clases, que se encuentran en la clase universidad</param>
        /// <param name="estadoCuenta">enum del estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que el alumno sea igual a una clase, si la tiene cargada y su estado no es deudor
        /// </summary>
        /// <param name="a">objeto tipo alumno</param>
        /// <param name="c">enum de la clase</param>
        /// <returns>true: si es que el alumno tiene la clase cargada y no es deudor, 
        /// False, si es deudor o no tiene la clase cargada. 
        /// Contempla la excepcion de que algun objeto recibido sea null</returns>
        public static bool operator ==(Alumno a, Universidad.EClases c)
        {
            bool returnAux = false;
            if (!object.ReferenceEquals(a,null) && !object.ReferenceEquals(c,null))
            {
                if (a._queClasesToma == c && a._estadoCuenta != EEstadoCuenta.Deudor)
                {
                    returnAux = true;
                }
            }
            else 
            {
                throw new NullReferenceException("No puedo realizar la comparacion entre Alumno y Clase, ya que hay un elemento que es null");
            }
            return returnAux;
        }

        /// <summary>
        /// Verifica que el alumno no sea igual a una clase, reutilizando el operador ==, 
        /// si este retorna true, el resultado de esta operacion es false
        /// </summary>
        /// <param name="a">objeto tipo alumno</param>
        /// <param name="c">enum de la clase</param>
        /// <returns>true si son distintos, false si son iguales</returns>
        public static bool operator !=(Alumno a, Universidad.EClases c)
        {
            bool returnAux = true;
            if(a == c)
            {
                returnAux = false;
            }
            return returnAux;
        }

        /// <summary>
        /// Implementa la clase abstracta ParticiparEnClase, donde retoranara un string con la clase que toma
        /// </summary>
        /// <returns>STRING</returns>
        public override string ParticiparEnClase()
        {
            string returnAux = string.Format("TOMA CLASE DE {0}", this._queClasesToma);
            return returnAux;
        }

        /// <summary>
        /// Sobreescritura del metodo MostrarDato, en el cual llamara al base de universatario y le agregara
        /// los datos de participa en clase
        /// </summary>
        /// <returns>STRING</returns>
        protected override string MostrarDato()
        {
            string aux = base.MostrarDato();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(aux);
            sb.AppendFormat("{0}", this.ParticiparEnClase());
            sb.AppendLine();
            sb.AppendFormat("Estado de cuenta: {0}", this._estadoCuenta);
            return sb.ToString();
        }

        /// <summary>
        /// Hace publico todos los datos de MostrarDato, retornando un string
        /// </summary>
        /// <returns>STRING</returns>
        public override string ToString()
        {
            string returnAux = this.MostrarDato();
            return returnAux;
        }
        #endregion

    }
}
