using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta, de la cual heredaran el resto de las clases
    /// </summary>
    public abstract class Persona
    {
        #region Atributos
        public enum ENacionalidad { Argentino, Extranjero }
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedades para editar o traer el apellido
        /// </summary>
        public string Apellido
        {
            get 
            { 
                return _apellido; 
            }
            set 
            { 
                _apellido = ValidarNombreApellido(value); 
            }
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
            get 
            {
                return _nacionalidad; 
            }
            set 
            {
                _nacionalidad = value; 
            }
        }

        /// <summary>
        /// Propiedades para editar o traer el nombre
        /// </summary>
        public string Nombre
        {
            get 
            { 
                return _nombre; 
            }
            set 
            { 
                _nombre = ValidarNombreApellido(value); 
            }
        }

        /// <summary>
        /// Propiedades para editar el dni parseandolo de ToString
        /// </summary>
        public string StringToDNI
        {
            set 
            {
                int aux = Persona.ValidarDni(this._nacionalidad, value);
                if (aux == 0 )
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

        /// <summary>
        /// Constructor que recibira por parametros los datos a cargar
        /// </summary>
        /// <param name="nombre">nombre de la persona, tipo string</param>
        /// <param name="apellido">apellido de la persona, tipo string</param>
        /// <param name="nacionalidad">enum con los datos de la nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
            this._nombre = nombre;
        }

        /// <summary>
        /// Constructor que utiliza el anterior, pero, ademas recibiendo por parametro el dni de tipo entero
        /// </summary>
        /// <param name="nombre">nombre de la persona, tipo string</param>
        /// <param name="apellido">apellido de la persona, tipo string</param>
        /// <param name="dni">dni a cargar, tipo int</param>
        /// <param name="nacionalidad">enum con los datos de la nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad) 
        {
            this._dni = dni;
        }

        /// <summary>
        /// Constructor que utiliza el anterior, pero, ademas recibiendo por parametro el dni de tipo string
        /// </summary>
        /// <param name="nombre">nombre de la persona, tipo string</param>
        /// <param name="apellido">apellido de la persona, tipo string</param>
        /// <param name="dni">dni a cargar, tipo string</param>
        /// <param name="nacionalidad">enum con los datos de la nacionalidad</param>
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
        /// Valida que el numero de DNI sea mayor a 1 y menor de 89999999, para la nacionalidad Argentina, si es extranjero 
        /// enviara una excepcion
        /// </summary>
        /// <param name="nacionalidad">enum del tipo nacionalidad</param>
        /// <param name="dato">numero de tipo int</param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            int returnAux = 0;

            if (dato < 1 || dato > 89999999 && nacionalidad == ENacionalidad.Argentino)
            {
                throw new DniInvalidoException("Largo invalido de DNI");
            }
            else if (dato > 1 && dato < 89999999 && nacionalidad != ENacionalidad.Argentino)
            {
                throw new NacionalidadInvalidaException("El largo de DNI no corresponde con la nacionalidad");
            }
            else 
            {
                returnAux = dato;
            }
            return returnAux;
        }


        /// <summary>
        /// Valida que el string enviado por parametro se pueda convertir a entero 
        /// y luego verifico que sea un dni valido por su rango
        /// </summary>
        /// <param name="nacionalidad">enum con la nacionalidad</param>
        /// <param name="dato">dato de tipo string</param>
        /// <returns>retonara una excepcion en el caso de que no pueda ser cargado, sino retornara el dato verificado convertido a entero</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            int returnAux = 0;
            if (!int.TryParse(dato, out returnAux))
            {
                string error = "No pudo cargarse el DNI";
                throw new DniInvalidoException(error);
            }
            returnAux = ValidarDni(nacionalidad,returnAux);
            return returnAux ;
        }

        /// <summary>
        /// Validara que no tenga caracteres especiales, si lo tiene retornara un ""
        /// </summary>
        /// <param name="dato">string a verificar</param>
        /// <returns>retornara el string si es correcto, sino ""</returns>
        private static string ValidarNombreApellido(string dato) 
        {
            string returnAux = "";
            Regex rgx = new Regex("^([a-zA-Z])$");
            bool aux = rgx.IsMatch(dato);
            if (aux == true)
            {
                returnAux = dato;
            }
            return returnAux;

        }

        /// <summary>
        /// Sobreescritura de toString, donde retornara los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0},{1}",this._apellido,this._nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}",this._nacionalidad);
            
            return sb.ToString();
        }
        #endregion
    }
}
