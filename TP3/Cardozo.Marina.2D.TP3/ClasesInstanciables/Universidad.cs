using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    /// <summary>
    /// Clase serializable
    /// </summary>
    [Serializable]
    public class Universidad
    {
        #region Atributos
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        protected List<Alumno> alumnos;
        protected List<Profesor> profesores;
        protected List<Jornada> jornada;
        #endregion

        #region Properties
        /// <summary>
        /// Retornara o seteara una lista de tipo alumnos
        /// </summary>
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

        /// <summary>
        /// Retornara o seteara una lista de tipo profesor
        /// </summary>
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

        /// <summary>
        /// Retornara o seteara una lista de tipo jornadas
        /// </summary>
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

        /// <summary>
        /// Retornara el indice de la lista de tipo jornada
        /// </summary>
        /// <param name="i">indice de tipo entero</param>
        /// <returns>Retornara o seteara una Jornada en la lista</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < jornada.Count)
                {
                    return jornada[i];
                }
                else 
                {
                    throw new Exception();
                }
            }


            set 
            {
                if (i > 0 && i < jornada.Count)
                {
                    jornada[i] = value;
                }
                else 
                {
                    throw new Exception();
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor donde instanciara las listas
        /// </summary>
        public Universidad() 
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verificara que los dos objetos por param no sean null, luego verificara si el alumno se encuentra en la lista
        /// de la universidad
        /// </summary>
        /// <param name="g">obj de universidad</param>
        /// <param name="a">obj de alumno</param>
        /// <returns>true si es que se encuentra, false si es que no</returns>
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
                throw new NullReferenceException();
            }

            return returnAux;
        }

        /// <summary>
        /// Verificara que los dos objetos por param no sean null, luego verificara si hay algun profesor que este dando esa clase
        /// </summary>
        /// <param name="g">obj de tipo Universidad</param>
        /// <param name="c">enum de clases</param>
        /// <returns>true: si encuentra profesor, false sino lo encuentra</returns>
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
                    
                    throw new SinProfesorException();
                }
            }
            else 
            {
                throw new NullReferenceException();
            }

            return aux;
        }

        /// <summary>
        /// Verificara que los dos objetos por param no sean null, luego verificara si el profesor se encuentra en la lista
        /// de la universidad
        /// </summary>
        /// <param name="g">obj de tipo universidad</param>
        /// <param name="i">obj de tipo profesor</param>
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
                throw new NullReferenceException("No puede realizarse la igualacion, el obj universidad o profesor es nulo");
            }
            return returnAux;
        }

        /// <summary>
        /// Verifica que el alumno no este en la lista de la universidad
        /// </summary>
        /// <param name="g">obj de tipo Universidad</param>
        /// <param name="a">obj de tipo Alumno</param>
        /// <returns>true si son distintos, false si son verdaderos</returns>
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
        /// Verifica que el profesor no este en la lista de la universidad
        /// </summary>
        /// <param name="g">obj de tipo Universidad</param>
        /// <param name="i">obj de tipo Profesor</param>
        /// <returns>true si son distintos, false si son verdaderos</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            bool returnAux = true;
            if(g==i)
            {
                returnAux = false;
            }

            return returnAux;
        }

        /// <summary>
        /// Verifica que no haya un profesor dando esa clase
        /// </summary>
        /// <param name="g">obj Universidad</param>
        /// <param name="c">enum de clases</param>
        /// <returns>Retorna el profesor que no pueda dar esa clase</returns>
        public static Profesor operator !=(Universidad g, EClases c)
        {
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
                throw new SinProfesorException();
            }
            else
            {
                throw new NullReferenceException();
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
            if (!object.ReferenceEquals(aux, null))
            {
                foreach (Profesor element in aux.profesores)
                {

                    if (((Profesor)element) == c)
                    {
                        p = element;
                        break;
                    }

                }
                if (object.ReferenceEquals(p,null))
                {
                    throw new SinProfesorException();
                }
                else
                {
                    jNew = new Jornada(c, p);
                }
                
                foreach (Alumno alumno in aux.alumnos)
                {
                    if (((Alumno)alumno) == c)
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
                
                throw new NullReferenceException();
            }

            return aux;
        }


        /// <summary>
        /// Verifica que ninguno de los obj recibidos por param sea null, luego chequea que el alumno pasado por param 
        /// no se encuentre el la lista, sino se encuentra o la lista es igual a 0, ya que es la primera vez que se inserta un alumno
        /// se agregara en un objeto de tipo universidad auxiliar, que es una copia del recibido por parametro, que luego se retorna
        /// </summary>
        /// <param name="g">obj Universidad</param>
        /// <param name="a">obj Alumno</param>
        /// <returns>Se retornara el mismo objeto sin el alumno si es que el alumno se encuentra en la universidad, sino se
        /// entregara una copia con el alumno incluido</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            Universidad returnAux = g;
            bool aux = false;
            if (!object.ReferenceEquals(returnAux, null))
            {
               if(returnAux.alumnos.Contains(a))
               {
                   aux = true;
               }
               if (aux == false || g.alumnos.Count() == 0)
               {
                   returnAux.alumnos.Add(a);
               }
               else 
               {
                   throw new AlumnoRepetidoException();
               }
            }
            else 
            {
                throw new Exception();
            }

            return returnAux;
        }

        /// <summary>
        /// Verifica que ninguno de los obj recibidos por param sea null, luego chequea que el profesor pasado por param 
        /// no se encuentre el la lista, sino se encuentra o la lista es igual a 0, ya que es la primera vez que se inserta un profesor
        /// se agregara en un objeto de tipo universidad auxiliar, que es una copia del recibido por parametro, que luego se retorna
        /// </summary>
        /// <param name="g">obj Universidad</param>
        /// <param name="a">obj Profesor</param>
        /// <returns>Se retornara el mismo objeto sin el alumno si es que el profesor se encuentra en la universidad, sino se
        /// entregara una copia con el profesor incluido</returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            Universidad returnAux = g;
            bool aux = false;
            if (!object.ReferenceEquals(returnAux, null))
            {
                if(returnAux.profesores.Contains(p))
                {
                    aux = true;
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


        /// <summary>
        /// Mostrara todos los datos de la universidad, imprimiendo la lista de Jornada
        /// </summary>
        /// <param name="gim">obj universidad</param>
        /// <returns>STRING</returns>
        private static string MostrarDatos(Universidad gim)
        {
           StringBuilder sb = new StringBuilder();
           foreach(Jornada element in gim.jornada)
           {
                if (!object.ReferenceEquals(element.Instructor, null))
                {
                    sb.AppendLine(element.ToString());
                    sb.AppendFormat("<------------------------------------------------>");
                    sb.AppendLine();
                }
                else
                {
                    continue;
                }
            }
           return sb.ToString();
        }

        /// <summary>
        /// Hara publico mostrardatos()
        /// </summary>
        /// <returns>STRING</returns>
        public override string ToString()
        {
            string returnAux = string.Format("{0}",Universidad.MostrarDatos(this));
            return returnAux;
        }


        /// <summary>
        /// Serializara los datos de la universidad pasada por param, utilizando un objeto de tipo XML, de la clase archivos
        /// </summary>
        /// <param name="gim">obj Universidad</param>
        /// <returns>True, si fue guardado, false sino pudo ser guardado</returns>
        public static bool Guardar(Universidad gim) 
        {
            string nomArchivo = "Universidad.xml";
            Xml<Universidad> fileXml = new Xml<Universidad>();
            bool returnAux = fileXml.Guardar(nomArchivo, gim);
            return returnAux;
        }

        /// <summary>
        /// Deserializara los datos de la universidad del archivo creado
        /// </summary>
        /// <param name="gim">obj Universidad</param>
        /// <returns>Objeto del archivo xml</returns>
        public static Universidad Leer() 
        {
            string nomArchivo = "Universidad.xml";
            Universidad aux = new Universidad();
            Xml<Universidad> fileXml = new Xml<Universidad>();
            if (!fileXml.Leer(nomArchivo,out aux)) 
            {
                throw new Exception();
            }
            return aux;
        }

        #endregion 
    }
}
