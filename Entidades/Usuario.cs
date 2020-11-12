using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public sealed class Usuario : Persona
    {
        private string nombreDeUsuario;
        private string contraseña;

        public string NombreUsuario
        {
            get
            {
                return this.nombreDeUsuario;
            }

            set
            {
                this.nombreDeUsuario = ValidarNombreUsuario(value);
            }
        }

        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }

            set
            {
                this.contraseña = ValidarContraseña(value);
            }
        }

        public Usuario(string cuenta, string contraseña)
        {
            this.NombreUsuario = cuenta;
            this.Contraseña = contraseña;
        }

        public Usuario(string nombre, string apellido, string cuenta, string contraseña)
            :base(nombre,apellido)
        {
            this.NombreUsuario = cuenta;
            this.Contraseña = contraseña;
        }
        
        private string ValidarNombreUsuario(string username)
        {
            if (username.Length > 0 && username.Length <= 32)
            {
                foreach (char c in username)
                {
                    if (char.IsWhiteSpace(c) || char.IsSymbol(c))
                    {
                        throw new UsuarioInvalidoException("El nombre de usuario posee un caracter inválido.");
                    }
                }
            }
            else
            {
                throw new UsuarioInvalidoException("El usuario debe tener entre 1 y 32 caracteres.");
            }
            return username;
        }

        private string ValidarContraseña(string contraseña)
        {
            if (contraseña.Length < 8 || contraseña.Length > 32)
            {
                throw new UsuarioInvalidoException("La contraseña debe tener entre 8 y 32 caracteres.");
            }
            return contraseña;
        }

        public static bool operator ==(Usuario u1, Usuario u2)
        {
            if (u1.NombreUsuario == u2.NombreUsuario)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Usuario u1, Usuario u2)
        {
            return !(u1 == u2);
        }

        public static bool operator ==(Usuario usuario, List<Usuario> listaUsuarios)
        {
            foreach (Usuario u in listaUsuarios)
            {
                if (usuario == u)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Usuario usuario, List<Usuario> listaUsuarios)
        {
            return !(usuario == listaUsuarios);
        }
    }
}
