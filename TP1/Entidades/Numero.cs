using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value.Trim());
            }
        }
        public Numero()
        {
            new Numero("0");
        }

        public Numero(double numero)
        {
            new Numero(numero.ToString());
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }

        private static double ValidarNumero(string strNumero)
        {
            double numeroRetorno;
            if (!double.TryParse(strNumero,out numeroRetorno))
            {
                numeroRetorno = 0d;
            }
            return numeroRetorno;
        }
        
        private static bool EsBinario (string binario)
        {
            char[] auxArrayBinario = new char[binario.Length];
            bool retorno = true;

            auxArrayBinario = binario.Trim().ToCharArray();

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

        public static string BinarioDecimal(string binario)
        {
            string resultado = "Valor inválido";
            
            if (EsBinario(binario) && binario.Length <= DecimalBinario(2147483647).Length)
            {
                resultado = Convert.ToInt32(binario, 2).ToString();
            }

            return resultado;
        }

        public static string DecimalBinario(double numero)
        {
            double numeroAbsoluto = Math.Abs(numero);
            string numeroBinario = "";
            while (numeroAbsoluto >= 1)
            {
                numeroBinario = (Math.Truncate(numeroAbsoluto % 2)).ToString()+numeroBinario;
                numeroAbsoluto /= 2;
            }

            return numeroBinario;
        }

        public static string DecimalBinario(string numero)
        {
            double doubleNumero;
            string retorno = "Valor inválido";
            if (double.TryParse(numero,out doubleNumero))
            {
                retorno = DecimalBinario(doubleNumero);
            }
            return retorno;
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
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
