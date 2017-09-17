using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    /// <summary>
    /// Clase Numero, esta clase podra guardar y validar un numero.
    /// Tiene como atributo un numero double, getters y setters
    /// </summary>
    class Numero
    {
        /// <summary>
        /// Atributo de tipo double
        /// </summary>
        public double numero;


        /// <summary>
        /// Metodo para poder traer el numero que este cargado en este objeto
        /// </summary>
        /// <returns>Devuelve el numero cargado en el objeto de la clase Numero</returns>
        public double GetNumero() {
            return this.numero;
        }

        /// <summary>
        /// Constructor del metodo numero, lo inicializa en 0 cuando no recibe ningun parametro
        /// </summary>
        public Numero() {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe por parametro el numero de tipo double que le queremos cargar
        /// </summary>
        /// <param name="num">numero que va a parar en la propiedad del objeto de esa clase</param>
        public Numero(double num) {
            this.numero = num;
        }

        /// <summary>
        /// Conatructor que recibe por parametro un string con el numero que iremos a cargar, este valida
        /// el numero y luego lo carga
        /// </summary>
        /// <param name="num">numero de forma string</param>
        public Numero(string num) {
            this.numero = ValidarNumero(num);
        }

        /// <summary>
        /// Setea el nuevo valor al numero del objeto, validando que sea un numero valido
        /// </summary>
        /// <param name="numeroString">recibe un string con un numero</param>
        private void SetNumero(string numeroString) {
            this.numero = ValidarNumero(numeroString);
        }

        /// <summary>
        /// Valida que se pueda realizar la conversion de string a double, sino se puede, retornara 0
        /// </summary>
        /// <param name="numeroString">string que deseamos convertir a numero de tipo double</param>
        /// <returns>retorna un double o un 0</returns>
        private double ValidarNumero(string numeroString) {

            double returnAux;

            while (!double.TryParse(numeroString, out returnAux)){
                returnAux = 0;
            }

            return returnAux;
        }

    }
}
