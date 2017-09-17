using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {
        /// <summary>
        /// Este metodo recibe dos objetos de tipo numero y un string operador. Llama al metodo validarOperador
        /// para poder corroborar que es un operador valido. Una vez que este es valido, chequea que 
        /// cuando sea una division no este diviendo por cero.
        /// Se hace un get de cada numero, para poder obtener el valor.
        /// Retorna el resultado de la operacion correspondiente que haga
        /// </summary>
        /// <param name="numero1">es el primer numero ingresado por el formulario</param>
        /// <param name="numero2">es el segundo numero ingresado por formulario</param>
        /// <param name="operador">operador con el que se desea laburar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public double Operar(Numero numero1, Numero numero2, string operador) 
        {

            double returnAux=0;

            switch(ValidarOperador(operador))
            {
                case "+":
                    returnAux = numero1.GetNumero() + numero2.GetNumero();
                    break;
                case "-":
                    returnAux = numero1.GetNumero() - numero2.GetNumero();
                    break;
                case "*":
                    returnAux = numero1.GetNumero() * numero2.GetNumero();
                    break;
                case "/":
                    if (numero2.GetNumero() > 0)
                    {
                        returnAux = numero1.GetNumero() / numero2.GetNumero();
                    }
                    else 
                    {
                        returnAux = 0;
                    }
                    break;
            }
            
            return returnAux;
        }

        /// <summary>
        ///Recibe un string que corrobora que si es un string invalido devolvera +, sino no sucedera nada. 
        /// </summary>
        /// <param name="operador">el operador en formato string</param>
        /// <returns>retorna un operador valido</returns>
        private string ValidarOperador(string operador) 
        {
            
            if(operador != "+" && operador != "-"  && operador != "/" && operador != "*")
            {
                operador = "+";
            }

            return operador;
        }

        

    }
}
