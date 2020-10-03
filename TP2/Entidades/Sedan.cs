using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Campos
        private ETipo tipo;

        #endregion


        #region Propiedades
        /// <summary>
        /// Sedan son "Mediano"
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodos
        #region Constructores

        /// <summary>
        /// Constructor de vehiculo Sedan.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor de vehículo Sedan. Si no se especifica, el tipo será CuatroPuertas.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }

        #endregion

        /// <summary>
        /// Muestra datos de vehículo Sedan como string.
        /// </summary>
        /// <returns>String con datos de Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SEDAN");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            stringBuilder.AppendLine("TIPO : " + this.tipo);
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }

        #endregion

        #region Tipos anidados
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }

        #endregion
    }
}
