using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public abstract class Persona
    {
        #region Campos
        private string nombre;
        private string apellido;
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea o retorna nombre de una persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (value == Persona.ValidarNombreApellido(value) && !string.IsNullOrEmpty(value))
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Setea o retorna apellido de una persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                if (value == Persona.ValidarNombreApellido(value) && !string.IsNullOrEmpty(value))
                {
                    this.apellido = value;
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor de persona con nombre.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Constructor de persona con nombre y apellido.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        public Persona(string nombre, string apellido)
            : this(nombre)
        {
            this.Apellido = apellido;
        }

        /// <summary>
        /// Valida nombre y apellido de una persona no contenga caracteres inválidos.
        /// </summary>
        /// <param name="dato">Nombre o apellido</param>
        /// <returns>Nombre o apellido validado</returns>
        private static string ValidarNombreApellido(string dato)
        {
            foreach (char caracter in dato)
            {
                if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                {
                    throw new NombreApellidoPersonaException();
                }
            }
            return dato;
        }
        #endregion
    }
}