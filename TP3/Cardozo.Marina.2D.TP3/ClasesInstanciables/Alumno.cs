using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta { Deudor, AlDia, Becado}
        protected Universidad.EClases _queClasesToma;
        protected EEstadoCuenta _estadoCuenta;

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) 
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._queClasesToma = clasesQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        /// <param name="estadoCuenta"></param>
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
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ParticiparEnClase()
        {
            string returnAux = string.Format("TOMA CLASE DE {0}", this._queClasesToma);
            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnAux = this.MostrarDato();
            return returnAux;
        }
        #endregion

    }
}
