using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Clases_Instanciables.Universidad;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {
        }

        /// <summary>
        /// Constructor de alumno con paramétros
        /// </summary>
        /// <param name="id">ID Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">Clase que toma</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de alumno con paramétros
        /// </summary>
        /// <param name="id">ID Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">Clase que toma</param>
        /// <param name="estadoCuenta">Estado de la cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna string con la clase que toma el alumno.
        /// </summary>
        /// <returns>"TOMA CLASES DE "+ Clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compara alumno con clase
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase">Clase</param>
        /// <returns> Retorna true si toma la clase y no es deudor, caso contrario retorna false </returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        /// Muestra los datos de un alumno
        /// </summary>
        /// <returns> String de alumno </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Muestra los datos de un alumno  como cadena de texto
        /// </summary>
        /// <returns>String de alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.MostrarDatos()+"\n");
            stringBuilder.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            stringBuilder.AppendLine(this.ParticiparEnClase() + "\n");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Lista los estados de cuenta posibles
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
