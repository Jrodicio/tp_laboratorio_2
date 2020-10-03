using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Los SUV son "Grande".
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Métodos

        #region Constructor
        /// <summary>
        /// Constructor de Vehiculo.SUV
        /// </summary>
        /// <param name="marca">Marca de SUV</param>
        /// <param name="chasis">Chasis de SUV</param>
        /// <param name="color">Color de SUV</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion


        /// <summary>
        /// Muestra los datos de un SUV
        /// </summary>
        /// <returns>String con los datos del SUV</returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SUV");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }

        #endregion
    }
}
