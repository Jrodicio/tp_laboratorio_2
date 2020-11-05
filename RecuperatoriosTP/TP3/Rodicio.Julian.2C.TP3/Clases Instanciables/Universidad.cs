using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// GET y SET de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.Alumnos = value;
            }
        }

        /// <summary>
        /// GET y SET de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.Instructores = value;
            }
        }

        /// <summary>
        /// GET y SET de jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// GET y SET de jornada indexada
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Jornada del index</returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada retorno;

                if (i > 0 && i < this.Jornadas.Count)
                {
                    retorno = this.Jornadas.ElementAt(i);
                }
                else if (i >= this.Jornadas.Count)
                {
                    retorno = this.Jornadas.Last();
                }
                else
                {
                    retorno = this.Jornadas.FirstOrDefault();
                }

                return retorno;
            }

            set
            {
                this.jornada.Insert(i, value);
            }
        }

        /// <summary>
        /// Constructor de universidad por defecto
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Guarda la universidad en XML
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True si pudo guardarlo, en caso contrario false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno;

            IArchivo<Universidad> archivo = new Xml<Universidad>();

            retorno = archivo.Guardar("Universidad.xml", uni);

            return retorno;
        }

        /// <summary>
        /// Lee Universidad.xml
        /// </summary>
        /// <returns>String de Universidad</returns>
        public string Leer()
        {
            IArchivo<Universidad> archivo = new Xml<Universidad>();
            Universidad datos;
            archivo.Leer("Universidad.xml", out datos);

            return datos.ToString();
        }

        /// <summary>
        /// Publica los datos de Universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>String de Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();

            foreach (Jornada jornada in uni.Jornadas)
            {
                retorno.AppendLine(jornada.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Compara universidad y alumno
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno estudia en la universidad, caso contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumnoAux in g.Alumnos)
            {
                if (alumnoAux == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara universidad y alumno
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno no estudia en la universidad, caso contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Agrega un alumno a la universidad en caso.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con alumno agregado</returns>
        /// <exception cref="AlumnoRepetidoException"></exception>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            Universidad retorno = g;

            if (g != a)
            {
                retorno.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return retorno;
        }

        /// <summary>
        /// Compara universidad con profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si el profesor dicta clases en la universidad, caso contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara universidad con profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si el profesor no dicta clases en la universidad, caso contrario false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega un profesor a la universidad en caso.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con alumno agregado</returns>
                public static Universidad operator +(Universidad g, Profesor i)
        {
            Universidad retorno = g;

            if (g != i)
            {
                retorno.Instructores.Add(i);
            }

            return retorno;
        }

        /// <summary>
        /// Compara universidad con clase y busca profesor que pueda dictarla
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Si existe: Profesor que dicta la clase. Caso contrario: null</returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if (retorno is null)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        /// <summary>
        /// Compara universidad con clase y busca profesor que no pueda dictarla
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Si existe: null. Caso contrario: Profesor que no puede dictar la clase</returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if (retorno is null)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        /// <summary>
        /// Agrega clase a universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Universidad con clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Universidad retorno = g;
            Jornada jornada;

            jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }

            retorno.Jornadas.Add(jornada);

            return retorno;
        }

        /// <summary>
        /// Convierte a string los datos de la universidad
        /// </summary>
        /// <returns>String de universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Lista de clases disponibles
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
