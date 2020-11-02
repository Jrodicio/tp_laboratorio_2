using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion


        #region Propiedades
        /// <summary>
        /// GET y SET del atributo apellido de la persona validado.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                if (value == this.ValidarNombreApellido(value) && !string.IsNullOrEmpty(value))
                {
                    this.apellido = value;
                }

            }
        }

        /// <summary>
        /// GET y SET de atributo dni de la persona, validado por nacionalidad.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// GET y SET de atributo nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// GET y SET de atributo nombre de la persona, validado.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (value == this.ValidarNombreApellido(value) && !string.IsNullOrEmpty(value))
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// GET y SET de atributo dni de la persona, validado por nacionalidad.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Métodos

        public Persona()
        {
        }
        /// <summary>
        /// Contructor de Persona con los datos suministrados por parámetro.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Contructor de Persona con los datos suministrados por parámetro.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Contructor de Persona con los datos suministrados por parámetro.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Convierte la información de una persona a String.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            stringBuilder.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Valida que el DNI suministrado corresponda con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>DNI validado</returns>
        /// <exception cref="NacionalidadInvalidaException"></exception>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (((dato < 1 || dato > 89999999) && nacionalidad == ENacionalidad.Argentino) || ((dato < 90000000 || dato > 99999999) && nacionalidad == ENacionalidad.Extranjero))
            {
                throw new NacionalidadInvalidaException();
            }
            
            return dato;
        }

        /// <summary>
        /// Valida que el DNI suministrado corresponda con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>DNI validado</returns>
        /// <exception cref="NacionalidadInvalidaException"></exception>
        /// <exception cref="DniInvalidoException"></exception>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad,int.Parse(dato));
            }
            catch(NacionalidadInvalidaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new DniInvalidoException(ex);
            }

        }

        /// <summary>
        /// Valida que el string sea un nombre o apellido valido.
        /// </summary>
        /// <param name="dato">Nombre o apellido</param>
        /// <returns>Nombre o apellido validado ó string vacío si es inválido</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char caracter in dato)
            {
                if(!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                {
                    dato = "";
                    break;
                }
            }
            return dato;
        }
        #endregion

        #region Tipos Anidados
        /// <summary>
        /// Nacionalidades posibles
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
