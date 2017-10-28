using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase sealed, que hereda de Universitario
    /// </summary>
    public sealed class Profesor :Universitario
    {
        #region Atributos
        protected Queue<Universidad.EClases> _clasesDelDia;
        protected static Random _random;
        #endregion 

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor() 
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor que recibira por parametro todos los datos para poder cargar el profesor
        /// Inicializara la lista de clases
        /// </summary>
        /// <param name="id">legajo de tipo int</param>
        /// <param name="nombre">nombre a cargar de tipo string</param>
        /// <param name="apellido">apellido a cargar de tipo string</param>
        /// <param name="dni">dni a cargar de tipo string</param>
        /// <param name="nacionalidad">enum de tipo nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            for (int i = 0; i <= 2; i++ )
            {
                this._randomClases();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescribe el metodo abstracto ParticiparEnClase, completandolo con los datos de las clases que da el profesor
        /// </summary>
        /// <returns></returns>
        public override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nCLASES DEL DIA ");
            sb.AppendLine();
            foreach(Universidad.EClases element in this._clasesDelDia)
            {
                sb.AppendLine(element.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribe el metodo MostrarDato para pasar por parametro todos los datos del profesor
        /// </summary>
        /// <returns>Retorna un string con los datos del profesor mas las clases que da</returns>
        protected override string MostrarDato()
        {
            string aux = base.MostrarDato();
            string returnAux = string.Format("{0} {1}", aux, this.ParticiparEnClase());
            
            return returnAux;
        }

        /// <summary>
        /// Metodo privado en el cual asignara un numero random, y lo convertira en un enum de la clase, para luego agregarlo
        /// en la lista
        /// </summary>
        private void _randomClases()
        {
            int randomClass = _random.Next(0, Enum.GetNames(typeof(Universidad.EClases)).Length - 1);

            this._clasesDelDia.Enqueue((Universidad.EClases)randomClass);

        }

        /// <summary>
        /// Chequea que un objeto Profesor, contenga la clase pasada por parametro
        /// </summary>
        /// <param name="p">Objeto profesor</param>
        /// <param name="c">Clase a chequear</param>
        /// <returns>retorna true si la clase se encuentra en la lista del profesor de clases, false sino se encuentra alli</returns>
        public static bool operator ==(Profesor p, Universidad.EClases c)
        {
            bool returnAux = false;
            if (!object.ReferenceEquals(p,null) && !object.ReferenceEquals(c,null))
            {
                foreach (Universidad.EClases element in p._clasesDelDia)
                {
                    if (element == c)
                    {
                        returnAux = true;
                    }
                }
            }
            else 
            {
                throw new Exception("No puedo verificar el equals entre Profesor y Clase, un objeto es null");
            }

            return returnAux;
        }

        /// <summary>
        /// Chequea que un objeto Profesor no contenga la clase pasada por parametro 
        /// </summary>
        /// <param name="p">Objeto de tipo profesor</param>
        /// <param name="c">clase</param>
        /// <returns>Retorna true si es verdad que no se encuentra la clase, false si es que no</returns>
        public static bool operator !=(Profesor p, Universidad.EClases c)
        {
            bool returnAux = true;
            if(p==c)
            {
                returnAux = false;
            }
            return returnAux;
        }

        /// <summary>
        /// Retorna todos los datos del profesor, utilizando el metodo mostrardatos.
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public override string ToString()
        {
            string returnAux = this.MostrarDato();
            return returnAux;
        }
        #endregion

    }
}
