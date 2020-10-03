using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodos
        #region Constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        /// <summary>
        /// Muestra los datos de un Ciclomotor
        /// </summary>
        /// <returns>String con datos del Ciclomotor</returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CICLOMOTOR");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }


        #endregion





    }
}
