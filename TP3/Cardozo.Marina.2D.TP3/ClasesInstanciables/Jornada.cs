﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase Jornada
    /// </summary>
    public class Jornada
    {
        #region Atributos
        protected List<Alumno> _alumno;
        protected Universidad.EClases _clase;
        protected Profesor _instructor;
        #endregion

        #region Properties

        /// <summary>
        /// Propiedades del tipo alumnos, donde retorna o setea una lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get 
            { 
                return _alumno; 
            }
            set 
            { 
                _alumno = value; 
            }
        }

        /// <summary>
        /// Propiedade de EClases, donde retorna o seatea clase
        /// </summary>
        public Universidad.EClases Clase 
        {
            get 
            {
                return _clase;
            }
            set 
            {
                _clase = value;
            } 
        }

        /// <summary>
        /// Propiedades de tipo Profesor, retorna o setea el profesor
        /// </summary>
        public Profesor Instructor 
        {
            get 
            {
                return _instructor;
            }
            set 
            {
                _instructor = value;
            } 
        }
        
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado, que iniciara la lista de alumnos
        /// </summary>
        public Jornada() 
        {
            this._alumno = new List<Alumno>();
        }

        /// <summary>
        /// Constructor publico, que inicializa la jornada
        /// </summary>
        /// <param name="clase">Clase por parametro</param>
        /// <param name="instructor">Objeto de tipo profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this() 
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Si el alumno, tiene la misma clase que la jornada seran iguales
        /// </summary>
        /// <param name="j">objeto jornada</param>
        /// <param name="a">alumno a chequear</param>
        /// <returns>retorna true si la igualdad de la clase y el alumno es verdadera o falsa, sino se cumple</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool returnAux = false;
            if(a==j._clase)
            {
                returnAux = true;
            }
            return returnAux;
        }

        /// <summary>
        /// Si el alumno, tiene la misma clase que la jornada no son iguales
        /// </summary>
        /// <param name="j">objeto jornada</param>
        /// <param name="a">alumno a chequear</param>
        /// <returns>Retorna true si es verdad que son distintos, false si son iguales</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            bool returnAux = false;
            if(a!=j._clase)
            {
                returnAux = true;
            }
            return returnAux;
        }

        /// <summary>
        /// Agrego al alumno si es que el alumno no se encuentra en la lista, chequeando que el alumno a agregar sea distinto de null
        /// </summary>
        /// <param name="j">Objeto Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la misma jornada, si es que Alumno ya esta agregado, si es que no retorna una copia de la jornada, con el alumno agregado a su lista</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada aux = j;
            int flag = 0;
            if (!object.ReferenceEquals(a,null) && !object.ReferenceEquals(j,null))
            {
                foreach (Alumno element in j._alumno)
                {
                    if (element == a)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    aux._alumno.Add(a);
                }
            }
            else 
            {
                throw new Exception("No puede realizarse la suma entre Jornada y alumno, ya que un objeto es null");
            }
           
            return aux;

        }

        /// <summary>
        /// Retornara todos los datos de la jornada, junto al instructor y a los alumnos que pertenecen a ella
        /// </summary>
        /// <returns>STRING</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Clase del dia {0}, {1}", this._clase,this._instructor.ToString());
            sb.AppendLine();
            sb.AppendFormat("ALUMNOS: \n");
            foreach(Alumno element in this._alumno)
            {
                sb.AppendLine(element.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Realiza un objeto de tipo texto y reutiliza su metodo Guardar, se le pasa un objeto de tipo jornada
        /// que sera convertido a toString y como debera llamarse el archivo
        /// </summary>
        /// <param name="jornada">objeto jornada</param>
        /// <returns>true si pudo ser guardado extiosamente, false si es que no pudo guardarse</returns>
        public static bool Guardar(Jornada jornada) 
        {
            Texto txt = new Texto();
            string fileNamej = "Jornada.txt";
            bool returnAux = txt.Guardar(fileNamej, jornada.ToString());
            return returnAux;
        }

        /// <summary>
        /// Utilizo un objeto de la clase texto para poderr leer el archivo, lanzando una excepcion en el caso de que no se pueda leer 
        /// </summary>
        /// <returns>STRING</returns>
        public static string Leer() 
        {
            Texto txt = new Texto();
            string returnAux = "";
            string fileNamej = "Jornada.txt";
            if(txt.Leer(fileNamej,out returnAux))
            {
                throw new Exception(); 
            }

            return returnAux;
        }
        #endregion

    }
}
