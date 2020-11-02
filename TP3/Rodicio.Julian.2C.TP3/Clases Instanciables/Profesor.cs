using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Se genera el Random del objeto Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Se inicializa Profesor por defecto.
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Se inicializa profesor con parámetros
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nomre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Setea clase aleatoria
        /// </summary>
        private void _randomClases()
        {
            var array = Enum.GetValues(typeof(EClases));
            this.clasesDelDia.Enqueue((EClases)array.GetValue(random.Next(array.Length)));
            this.clasesDelDia.Enqueue((EClases)array.GetValue(random.Next(array.Length)));
        }

        /// <summary>
        /// Muestra datos de profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("{0}{1} \n", base.MostrarDatos(), this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Compara profesor y clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor dicta dicha clase, en caso contrario false</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;

            foreach (EClases auxClase in i.clasesDelDia)
            {
                if (auxClase == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara profesor y clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor no dicta dicha clase, en caso contrario false</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Publica las clases que dicta el profesor
        /// </summary>
        /// <returns>String con clases del día</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DIA");

            foreach (EClases clase in clasesDelDia)
            {
                retorno.AppendLine(clase.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Convierte a String los datos del profesor
        /// </summary>
        /// <returns>String de profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
