using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Entidades
{
    public sealed class MateriaPrima : Producto
    {
        #region Campos
        private float pesoKG;
        private ETipo tipo;
        #endregion

        #region Propiedades
        
        /// <summary>
        /// Setea o retorna el peso de la materia prima
        /// </summary>
        public float PesoKG
        {
            get
            {
                return this.pesoKG;
            }

            set
            {
                this.pesoKG = value;
            }
        }

        /// <summary>
        /// Setea o retorna el tipo de la materia prima
        /// </summary>
        public ETipo Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        [XmlIgnore]
        /// <summary>
        /// Setea o retorna un string del tipo de la materia prima
        /// </summary>
        public string StringTipo
        {
            get
            {
                return this.Tipo.ToString();
            }
            set
            {
                switch (value)
                {
                    case "Cebada":
                        this.Tipo = ETipo.Cebada;
                        break;
                    case "Levadura":
                        this.Tipo = ETipo.Levadura;
                        break;
                    case "Lúpulo":
                        this.Tipo = ETipo.Lúpulo;
                        break;
                    case "Malta":
                        this.Tipo = ETipo.Malta;
                        break;
                    case "Trigo":
                        this.Tipo = ETipo.Trigo;
                        break;
                    default:
                        throw new InvalidCastException();
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor sin parámetros necesario para serialización
        /// </summary>
        public MateriaPrima()
        {
        }

        /// <summary>
        /// Constructor paramétrizado
        /// </summary>
        /// <param name="idProducto">Id producto</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="tipo">Tipo</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        /// <param name="pesoKG">Peso en KG</param>
        public MateriaPrima(int idProducto, string descripcion, ETipo tipo, string marca, float precio, float pesoKG)
            : base(idProducto, descripcion, marca, precio)
        {
            this.Tipo = tipo;
            this.PesoKG = pesoKG;
        }

        /// <summary>
        /// Constructor parametrizado con string de Tipo
        /// </summary>
        /// <param name="idProducto">Id producto</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="tipo">Tipo en string</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        /// <param name="pesoKG">Peso</param>
        public MateriaPrima(int idProducto, string descripcion, string tipo, string marca, float precio, float pesoKG)
            : base(idProducto, descripcion, marca, precio)
        {
            this.StringTipo = tipo;
            this.PesoKG = pesoKG;
        }

        /// <summary>
        /// Forma un string con los datos de la materia prima.
        /// </summary>
        /// <returns>String de materia prima</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Tipo: {this.StringTipo}");
            sb.AppendLine();
            sb.AppendFormat(base.ToString());
            sb.AppendLine();
            sb.AppendFormat("Peso en KG: {0}", this.PesoKG);

            return sb.ToString();
        }
        #endregion

        #region enum
        /// <summary>
        /// Tipos de materia prima válidos
        /// </summary>
        public enum ETipo
        {
            Cebada,
            Levadura,
            Lúpulo,
            Malta,
            Trigo
        }
        #endregion
    }
}