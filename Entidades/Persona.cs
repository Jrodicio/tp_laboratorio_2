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
        private string nombre;
        private string apellido;

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
        
        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }
        public Persona(string nombre, string apellido)
            : this(nombre)
        {
            this.Apellido = apellido;
        }

        public Persona()
        {

        }

        private string ValidarNombreApellido(string dato)
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
    }
}
