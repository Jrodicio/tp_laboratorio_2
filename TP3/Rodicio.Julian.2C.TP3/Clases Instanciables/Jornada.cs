using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        /// <summary>
        /// GET y SET de lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// GET y SET de clase
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// GET y SET de profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Se inicializa Jornada.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Se inicializa Jornada con clase e instructor.
        /// </summary>
        /// <param name="clase">Clase</param>
        /// <param name="instructor">Instructor</param>
        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"> Jornada </param>
        /// <returns> True si se pudo guardar, caso contrario retorna false </returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            IArchivo<string> archivo = new Texto();

            if (archivo.Guardar("Jornada.txt", jornada.ToString()))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de una jornada de un archivo de texto
        /// </summary>
        /// <returns> Los datos en un string </returns>
        public string Leer()
        {
            IArchivo<string> archivo = new Texto();
            string datos;
            archivo.Leer("Jornada.txt", out datos);

            return datos;
        }

        /// <summary>
        /// Una jornada y un alumno son iguales si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si participa, caso contrario false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            if (a == j.clase)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        ///  Una jornada y un alumno son distintos si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno </param>
        /// <returns>True si no participa, caso contrario false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Inscribe a un alumno a la jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Jornada con alumno inscripto</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada jornadaRetorno = j;

            if (j != a)
            {
                jornadaRetorno.alumnos.Add(a);
            }

            return jornadaRetorno;
        }

        /// <summary>
        /// Retorna los datos de una jornada en string
        /// </summary>
        /// <returns>String de Jornada</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("JORNADA: ");

            stringBuilder.AppendFormat("CLASE DE {0} POR {1} ", this.Clase.ToString(), this.Instructor.ToString());

            stringBuilder.AppendLine("ALUMNOS: ");

            foreach (Alumno alumno in this.alumnos)
            {
                stringBuilder.AppendLine(alumno.ToString());
            }

            stringBuilder.AppendLine("<----------------------------------------->\n");

            return stringBuilder.ToString();
        }
    }
}
