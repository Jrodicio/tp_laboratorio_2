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
        #region Campos
        private string nombreDeUsuario;
        private string contraseña;
        #endregion
        #region Propiedades
        /// <summary>
        /// Retorna o setea nombre de usuario validado
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return this.nombreDeUsuario;
            }

            set
            {
                this.nombreDeUsuario = Usuario.ValidarNombreUsuario(value);
            }
        }

        /// <summary>
        /// Retorna o setea contraseña de usuario validada
        /// </summary>
        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }

            set
            {
                this.contraseña = Usuario.ValidarContraseña(value);
            }
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Constructor de usuario sin nombre ni apellido.
        /// </summary>
        /// <param name="cuenta">Cuenta</param>
        /// <param name="contraseña">Contraseña</param>
        public Usuario(string cuenta, string contraseña)
            : this("Anonymous", "Anonymous",cuenta,contraseña)
        {
        }
        /// <summary>
        /// Constructor de usuario completo
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="cuenta">Cuenta</param>
        /// <param name="contraseña">Contraseña</param>
        public Usuario(string nombre, string apellido, string cuenta, string contraseña)
            : base(nombre, apellido)
        {
            this.NombreUsuario = cuenta;
            this.Contraseña = contraseña;
        }

        /// <summary>
        /// Valida el nombre de usuario sea válido
        /// </summary>
        /// <param name="username"></param>
        /// <returns>string con nombre de usuario validado</returns>
        private static string ValidarNombreUsuario(string username)
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

        /// <summary>
        /// Valida la contraseña sea válida
        /// </summary>
        /// <param name="contraseña">Contraseña</param>
        /// <returns>string con contraseña validada</returns>
        /// /// <exception cref="UsuarioInvalidoException"></exception>
        private static string ValidarContraseña(string contraseña)
        {
            if (contraseña.Length < 8 || contraseña.Length > 32)
            {
                throw new UsuarioInvalidoException("La contraseña debe tener entre 8 y 32 caracteres.");
            }
            return contraseña;
        }

        /// <summary>
        /// Agrega el usuario instanciado a la lista de usuarios en parámetro
        /// </summary>
        /// <param name="listaUsuarios">Lista de usuarios</param>
        /// <returns>True si se pudo agregar</returns>
        /// <exception cref="UsuarioDuplicadoException"></exception>
        public bool AddUsuario(List<Usuario> listaUsuarios)
        {
            if (this == listaUsuarios)
            {
                throw new UsuarioDuplicadoException("El usuario <{0}> ya existe en la instancia.", this.NombreUsuario);
            }
            else
            {
                listaUsuarios.Add(this);
                return true;
            }
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Comparación de usuario con string
        /// </summary>
        /// <param name="u1">Usuario</param>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>True si el usuario tiene la misma cuenta que el nombre de usuario facilitado, caso contrario false</returns>
        public static bool operator ==(Usuario u1, string username)
        {
            if (u1.NombreUsuario == username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comparación de usuario con string
        /// </summary>
        /// <param name="u1">Usuario</param>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>True si el usuario no tiene la misma cuenta que el nombre de usuario facilitado, caso contrario false</returns>
        public static bool operator !=(Usuario u1, string username)
        {
            return !(u1 == username);
        }

        /// <summary>
        /// Comparación de usuario contra usuario
        /// </summary>
        /// <param name="u1">Usuario 1</param>
        /// <param name="u2">Usuario 2</param>
        /// <returns>True si comparten el mismo nombre de usuario, caso contrario false</returns>
        public static bool operator ==(Usuario u1, Usuario u2)
        {
            if (u1 == u2.NombreUsuario)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comparación de usuario contra usuario
        /// </summary>
        /// <param name="u1">Usuario 1</param>
        /// <param name="u2">Usuario 2</param>
        /// <returns>True si no comparten el mismo nombre de usuario, caso contrario false</returns>
        public static bool operator !=(Usuario u1, Usuario u2)
        {
            return !(u1 == u2);
        }

        /// <summary>
        /// Comparación de usuario contra lista de usuarios
        /// </summary>
        /// <param name="usuario">Usuario 1</param>
        /// <param name="listaUsuarios">Usuario 2</param>
        /// <returns>True si el usuario esta contenido dentro de la lista de usuarios, caso contrario false</returns>
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

        /// <summary>
        /// Comparación de usuario contra lista de usuarios
        /// </summary>
        /// <param name="usuario">Usuario 1</param>
        /// <param name="listaUsuarios">Usuario 2</param>
        /// <returns>True si el usuario no esta contenido dentro de la lista de usuarios, caso contrario false</returns>
        public static bool operator !=(Usuario usuario, List<Usuario> listaUsuarios)
        {
            return !(usuario == listaUsuarios);
        }

        #endregion

        /// <summary>
        /// Retorna los datos del usuario en un string.
        /// </summary>
        /// <returns>String de usuario</returns>
        public override string ToString()
        {
            string strUsuario = string.Format("{0} - {1}, {2}.", this.NombreUsuario, base.Apellido, base.Nombre);

            return strUsuario;
        }
        #endregion
    }
}
