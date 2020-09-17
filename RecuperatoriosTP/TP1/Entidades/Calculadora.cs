using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Valida el operador. En caso de no ser válido, retorna "+".
        /// </summary>
        /// <param name="operador">Operador a analizar</param>
        /// <returns>ERROR: "+"; OK: Operador validado</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Realiza el calculo especificado en $operador entre dos datos tipo Numero.
        /// </summary>
        /// <param name="num1">Numero 1er operando</param>
        /// <param name="num2">Numero 2do operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>OK: Resultado; ERROR: 0</returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "+":
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }
    }
}
