﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /*  Atributos   */

        /// <summary>
        /// Numero double
        /// </summary>
        private double numero;

        /*  Setters  */

        /// <summary>
        /// Setter de valor this.numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value.Trim());
            }
        }

        /*  Constructores   */

        /// <summary>
        /// Constructor default de Numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de Numero con parámetro Double.
        /// </summary>
        /// <param name="numero">Número</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de Numero con parámetro String
        /// </summary>
        /// <param name="numero">Número</param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }


        /*  Métodos */
        /// <summary>
        /// Valida si el número es válido
        /// </summary>
        /// <param name="strNumero">String con dato a validar</param>
        /// <returns>Double: strNumero o 0 en caso de error.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double numeroRetorno;
            if (!double.TryParse(strNumero,out numeroRetorno))
            { 
                numeroRetorno = 0d;
            }
            return numeroRetorno;
        }
        
        /// <summary>
        /// Valida si el string está compuesto solo por 1 y 0.
        /// </summary>
        /// <param name="binario">String a validar</param>
        /// <returns>True: Binario. False: No binario</returns>
        private static bool EsBinario (string binario)
        {
            bool retorno = true;
            char[] auxArrayBinario = binario.Trim().ToCharArray();

            foreach (char charNumero in auxArrayBinario)
            {
                if(charNumero != '0' && charNumero != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte de string binario a string decimal.
        /// </summary>
        /// <param name="binario">String en binario</param>
        /// <returns>ERROR: "Valor inválido";
        /// OK: String decimal</returns>
        public static string BinarioDecimal(string binario)
        {
            string resultado = binario;
            
            if (EsBinario(binario))
            {
                double acumulador = 0d;
                int potencia = (binario.Length) - 1;
                
                /* 
                 * El objetivo es acumular el resultado de 2^potencia*binario[i]. 
                 * Se contaba con funciones que hacían este proceso en Math pero solo con Int32.
                 * De esta forma, al utilizar un dato tipo double, ampliamos el rango de resultados.
                */

                for (int i = 0; i <= potencia; i++)
                {
                    acumulador += Math.Pow(2,potencia-i)*double.Parse(binario[i].ToString());
                }

                resultado = acumulador.ToString("N4");
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve un double decimal como un string binario
        /// </summary>
        /// <param name="numero">Número a convertir a binario</param>
        /// <returns>Error: "Valor inválido"; OK: String binario</returns>
        public static string DecimalBinario(double numero)
        {
            double numeroAbsoluto = Math.Abs(numero);
            string stringBinario = "0";
            
            while (numeroAbsoluto >= 1)
            {
                //Utilizamos una variable string para ir alojando los 1 y 0, de forma tal que no tengamos limitaciones de los tipo de datos númericos.
                stringBinario = (Math.Truncate(numeroAbsoluto % 2)).ToString()+stringBinario;
                numeroAbsoluto /= 2;
            }

            return stringBinario;
        }

        /// <summary>
        /// Devuelve un número string decimal como un string binario
        /// </summary>
        /// <param name="numero">String a convertir a binario</param>
        /// <returns>ERROR: Valor inválido; OK: String binario</returns>
        public static string DecimalBinario(string numero)
        {

            string retorno = "Valor inválido";
            if (double.TryParse(numero,out double doubleNumero) && !EsBinario(numero))
            {
                retorno = DecimalBinario(doubleNumero);
            }
            return retorno;
        }

        /*  Sobrecarga de operadores    */

        /// <summary>
        /// Realiza la resta entre dos datos tipo Numero.
        /// </summary>
        /// <param name="n1">Número 1er operando</param>
        /// <param name="n2">Número 2do operando</param>
        /// <returns>Resultado n1-n2</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre dos datos tipo Numero.
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>n1 + n2</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza multiplicación entre dos datos tipo Numero.
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>n1 * n2</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la división entre dos datos tipo Numero
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Si n2 es 0, retorna 0. Sino, retorna n1/n2</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            double resultado = double.MinValue;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

    }
}
