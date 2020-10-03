using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Campos

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        #endregion

        #region Propiedades
        
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        #endregion


        #region Métodos

        #region Constructor

        /// <summary>
        /// Constructor de vehículo
        /// </summary>
        /// <param name="chasis">Chasis</param>
        /// <param name="marca">Marca</param>
        /// <param name="color">Color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        #endregion


        /// <summary>
        /// Retorna campos de vehículo como un string
        /// </summary>
        /// <param name="vehiculo">Vehiculo a convertir a string</param>
        public static explicit operator string(Vehiculo vehiculo)   
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("CHASIS: {0}\r\n", vehiculo.chasis);
            stringBuilder.AppendFormat("MARCA : {0}\r\n", vehiculo.marca.ToString());
            stringBuilder.AppendFormat("COLOR : {0}\r\n", vehiculo.color.ToString());
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>String de datos de vehículo</returns>
        public virtual string Mostrar()
        {
            return (string) this;
        }


        /// <summary>
        /// Compara dos vehiculos por su chasis.
        /// </summary>
        /// <param name="vehiculo1">Primer vehículo</param>
        /// <param name="vehiculo2">Segundo vehículo</param>
        /// <returns>Da true si vehiculo1.chasis == vehiculo2.chasis</returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return (vehiculo1.chasis == vehiculo2.chasis);
        }

        /// <summary>
        /// Compara dos vehiculos por su chasis.
        /// </summary>
        /// <param name="vehiculo1">Primer vehículo</param>
        /// <param name="vehiculo2">Segundo vehículo</param>
        /// <returns>Da true si vehiculo1.chasis != vehiculo2.chasis</returns>
        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }

        

        #endregion

        #region Tipos_Anidados

        /// <summary>
        /// Marcas posibles de un vehículo
        /// </summary>
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }

        /// <summary>
        /// Tamaños posibles de un vehiculo
        /// </summary>
        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }

        #endregion
    }
}
