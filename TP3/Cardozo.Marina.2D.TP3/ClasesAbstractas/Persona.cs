using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;

        #region Propiedades
        /// <summary>
        /// Propiedades para editar o traer el apellido
        /// </summary>
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        /// <summary>
        /// Propiedades para editar o traer el DNI
        /// </summary>
        public int DNI
        {
            get 
            { 
                return _dni; 
            }
            set 
            { 
                int aux = Persona.ValidarDni(this._nacionalidad,value);
                if (aux != 0) 
                {
                    _dni = value; 
                }
            }
        }

        /// <summary>
        /// Propiedades para editar o traer la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        /// <summary>
        /// Propiedades para editar o traer el nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Propiedades para editar el dni parseandolo de ToString
        /// </summary>
        public string StringToDNI
        {
            set 
            {
                int aux = Persona.ValidarDni(this._nacionalidad, value);
                if (aux == 0 || !int.TryParse(value, out this._dni))
                {
                      string error = "No pudo cargarse el DNI";
                      throw new DniInvalidoException(error);
                }
                
            }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor publico por defecto
        /// </summary>
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
            this._nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad) 
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            if (!int.TryParse(dni, out this._dni))
            {
                string error = "No pudo cargarse el DNI";
                throw new DniInvalidoException(error);
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            int returnAux = 0;
            if(nacionalidad != ENacionalidad.Argentina)
            {
                throw new DniInvalidoException("Se requiere que sea Argentino");
            }
            else if (dato < 1 || dato > 89999999)
            {
                throw new DniInvalidoException("Largo invalido de DNI");
            }
            else 
            {
                returnAux = dato;
            }
            return returnAux;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            int returnAux = 0;
            if (!int.TryParse(dato, out returnAux))
            {
                string error = "No pudo cargarse el DNI";
                throw new DniInvalidoException(error);
            }
            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato) 
        {
            string returnAux = "";
            Regex rgx = new Regex("^([a-zA-Z])$");
            bool aux = rgx.IsMatch(dato);
            if (aux == true)
            {
                returnAux = dato;
            }
            return dato;

        }

        public override string ToString()
        {

           // string returnAux = string.Format("{0},{1},{2},{3}", this._apellido, this._nombre,this._nacionalidad,this._dni);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0},{1}",this._apellido,this._nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}",this._nacionalidad);
            
            return sb.ToString();
        }
        #endregion
    }
}
