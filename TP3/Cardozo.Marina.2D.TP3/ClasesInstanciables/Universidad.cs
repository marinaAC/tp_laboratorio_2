using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Natacion, Pilates, Legislacion, Laboratorio }
        protected List<Alumno> alumnos;
        protected List<Profesor> profesores;
        protected List<Jornada> jornada;

        #region Properties
        public List<Alumno> Alumnos 
        { 
            get
            {
                return alumnos;
            }
            set 
            {
                alumnos = value;
            }
        }
        public List<Profesor> Instructores 
        {
            get 
            {
                return profesores;
            }
            set 
            {
                profesores = value;
            }
        }

        public List<Jornada> Jornadas 
        { 
            get
            {
                return jornada;
            }
            set 
            {
                jornada = value;
            }
        }

        public Jornada this[int i] { get; set; }
        #endregion
        #region Constructores
        public Universidad() { }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool returnAux = false;
            if (a != null)
            {
                foreach (Alumno element in g.alumnos)
                {
                    if (element == a)
                    {
                        returnAux = true;
                    }
                }
            }
            else 
            {
                throw new Exception();
            }

            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases c)
        {
            Profesor aux = null;
            if (c != null && g != null)
            {
                foreach (Profesor element in g.profesores)
                {
                    if (element == c)
                    {
                        aux = element;
                    }
                }

                if (aux == null) 
                {
                    //Exception del profesor cambiar!!
                    throw new Exception("");
                }
            }
            else 
            {
                throw new Exception();
            }

            return aux;
        }

        /// <summary>
        /// Preguntar por estos errores
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool returnAux = false;
            if (i != null || g != null)
            {
                foreach (Profesor element in g.profesores)
                {
                    if (element == i)
                    {
                        returnAux = true;
                    }
                }
            }
            else 
            {
                throw new Exception("No puede realizarse la igualacion, el obj universidad o profesor es nulo");
            }
            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            bool returnAux = true;
            if(g==a)
            {
                returnAux = false;
            }

            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            bool returnAux = true;
            if(g==i)
            {
                returnAux = false;
            }

            return returnAux;
        }

        public static Profesor operator !=(Universidad g, EClases c)
        {
            bool returnAux = true;
            Profesor aux = null;
            return aux;
        }


        //Sospecho que esta mal
        private string MostrarDatos(Universidad gim)
        {
           StringBuilder sb = new StringBuilder();
           foreach(Jornada element in gim.jornada)
           {
               sb.AppendLine(element.ToString());
               sb.AppendFormat("<------------------------------------------------>");
           }
           return sb.ToString();
        }

        /*Preguntar!!!
        public override string ToString()
        {
            string returnAux = string.Format("{0}",this.MostrarDatos());
            return base.ToString();
        }
        */


        #endregion 
    }
}
