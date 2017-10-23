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
        public List<Alumno> Alumnos { get; set; }
        public List<Profesor> Instructores { get; set; }
        public List<Jornada> Jornadas { get; set; }
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
            if (c != null)
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
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool returnAux = false;
            if (i != null && g != null)
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
        #endregion 
    }
}
