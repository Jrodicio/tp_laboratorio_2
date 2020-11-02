using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
        }

        /// <summary>
        /// Contructor de Universitario con los datos suministrados por parámetro.
        /// </summary>
        /// <param name="legajo"> numero de legajo </param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Retorna un string con los datos de un Universitario
        /// </summary>
        /// <returns> String de Universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString()+"\n");
            stringBuilder.AppendFormat("LEGAJO NÚMERO: {0}\n", this.legajo);

            return stringBuilder.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara el tipo de dos objetos
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns> True si son del mismo tipo, caso contrario retorna false</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj.GetType() == this.GetType())
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Compara dos universitarios. Son iguales si son del mismo tipo y tienen el mismo DNI o legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.Equals(pg2))
            {
                if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara dos universitarios. Son distintos si no son del mismo tipo ó no tienen el mismo DNI o legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
