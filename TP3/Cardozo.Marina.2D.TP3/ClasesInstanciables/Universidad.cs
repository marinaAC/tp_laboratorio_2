﻿using System;
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

        //subindice
        public Jornada this[int i]
        {
            get;


            set;
        }
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
            if (!object.ReferenceEquals(a,null) && !object.ReferenceEquals(g,null))
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
        /// Referenceequals (buscar)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases c)
        {
            Profesor aux = null;
            if (!object.ReferenceEquals(c,null) && !object.ReferenceEquals(g,null))
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
            if (!object.ReferenceEquals(i,null) && !object.ReferenceEquals(g,null))
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
            if(!object.ReferenceEquals(g,null))
            {
                foreach(Profesor element in g.profesores)
                {
                    if(element!=c)
                    {
                        aux = element;
                        break;
                    }
                }
            }
            else if (aux == null)
            {
                //Cambiar
                throw new Exception("No hay profesores para dar la clase");
            }
            else
            {
                //ver
                throw new Exception("objeto null");
            }
            return aux;
        }

        /// <summary>
        /// Creo un auxiliar copiando de la universidad original recibida por parametro, verifico que 
        /// no sea null, luego realizo la logica pedida, veo que la clase sea dada por un profesor
        /// si es asi con el profesor encontrado creo la nueva jornada, luego busco en la lista de alumnos
        /// lo que esten asignados a esa clase, para completar la jornada. Luego esta se la sumo al auxiliar
        /// y retorno el auxiliar
        /// </summary>
        /// <param name="g">Objeto universidad</param>
        /// <param name="c">enum de clase</param>
        /// <returns>Retorna una universidad</returns>
        public static Universidad operator +(Universidad g, EClases c)
        {
            Universidad aux = g;
            Jornada jNew = null;
            Profesor p = null;
            if (!object.ReferenceEquals(g, null))
            {
                foreach (Profesor element in g.profesores)
                {
                    if (p == c)
                    {
                        p = element;
                        break;
                    }
                }
                jNew = new Jornada(c, p);
                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno == c)
                    {
                        jNew.Alumnos.Add(alumno);
                    }
                }
                if(!object.ReferenceEquals(jNew,null))
                {
                    aux.jornada.Add(jNew);
                }
                
            }
            else 
            {
                //cambiar al generico
                throw new Exception("Objeto null");
            }

            return aux;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            Universidad returnAux = g;
            bool aux = false;
            if (!object.ReferenceEquals(returnAux, null))
            {
                foreach (Alumno element in g.alumnos)
                {
                    if (element == a)
                    {
                        aux = true;
                    }
                }
                if (aux == false || g.alumnos.Count() == 0)
                {
                    returnAux.alumnos.Add(a);
                }
            }
            else 
            {
                throw new Exception();
            }

            return returnAux;
        }

        public static Universidad operator +(Universidad g, Profesor p)
        {
            Universidad returnAux = g;
            bool aux = false;
            if (!object.ReferenceEquals(returnAux, null))
            {
                foreach (Profesor element in g.profesores)
                {
                    if (element == p)
                    {
                        aux = true;
                    }
                }
                if (aux == false || g.profesores.Count() == 0)
                {
                    returnAux.profesores.Add(p);
                }
            }
            else
            {
                throw new Exception();
            }

            return returnAux;
        }


        private static string MostrarDatos(Universidad gim)
        {
           StringBuilder sb = new StringBuilder();
           foreach(Jornada element in gim.jornada)
           {
               sb.AppendLine(element.ToString());
               sb.AppendFormat("<------------------------------------------------>");
           }
           return sb.ToString();
        }

        
        public override string ToString()
        {
            string returnAux = string.Format("{0}",Universidad.MostrarDatos(this));
            return returnAux;
        }
        


        #endregion 
    }
}
