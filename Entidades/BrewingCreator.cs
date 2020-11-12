using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;

namespace Entidades
{
    public sealed class BrewingCreator
    {
        private static BrewingCreator singleton;
        private Usuario usuarioLogueado;
        private List<Usuario> listaUsuarios;
        private SqlConnection sqlConnection;

        public Usuario UsuarioLogueado
        {
            get
            {
                return this.usuarioLogueado;
            }
            set
            {
                if (this.ComprobarCredenciales(value))
                {
                    this.usuarioLogueado = value;
                }
                else
                {
                    throw new UsuarioInvalidoException("El usuario o la clave son incorrectos.");
                }
            }
        }

        public SqlConnection GetSqlConnection
        {
            get
            {
                return this.sqlConnection;
            }
        }

        public List<Usuario> ListaUsuarios
        {
            get
            {
                return this.listaUsuarios;
            }
            set
            {
                this.listaUsuarios = value;
            }
        }


        private BrewingCreator()
        {
            this.sqlConnection = new SqlConnection("Server=.;Database=BrewingCreators;Trusted_Connection=True;");
            this.ListaUsuarios = this.LeerUsuariosDB();
        }

        

        public static BrewingCreator GetBrewingCreatorsSystem()
        {
            if (BrewingCreator.singleton is null)
            {
                BrewingCreator.singleton = new BrewingCreator();
            }

            return BrewingCreator.singleton;
        }

        public List<Usuario> LeerUsuariosDB()
        {
            SqlDataReader reader;
            SqlCommand sqlCommand;
            string textCommand;            
            string nombre;
            string apellido;
            string usuario;
            string contraseña;
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                textCommand = @"SELECT   
                                        [Nombre] = name, 
                                        [Apellido] = lastname,
                                        [Usuario] = username, 
                                        [Contrasena] = password
                               FROM dbo.Usuarios
                               ORDER BY id_usuario";

                this.sqlConnection.Open();
                sqlCommand = new SqlCommand(textCommand, this.sqlConnection);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    nombre = reader.GetString(0);
                    apellido = reader.GetString(1);
                    usuario = reader.GetString(2);
                    contraseña = reader.GetString(3);

                    this.AddUsuario(new Usuario(nombre, apellido, usuario, contraseña), listaUsuarios);
                }
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }

            return listaUsuarios;
        }

        public void InsertUsuarioDB(Usuario nuevoUsuario)
        {
            try
            {
                string textCommand = "INSERT INTO dbo.Usuarios"+
                                    " VALUES (@usuario, @clave, @nombre, @apellido)";

                SqlCommand sqlCommand = new SqlCommand(textCommand, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("usuario", nuevoUsuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("clave", nuevoUsuario.Contraseña);
                sqlCommand.Parameters.AddWithValue("nombre", nuevoUsuario.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", nuevoUsuario.Apellido);
                
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }

        public bool AddUsuario(Usuario nuevoUsuario, List<Usuario> listaUsuarios)
        {
            if(nuevoUsuario == listaUsuarios)
            {
                throw new UsuarioDuplicadoException("El usuario <{0}> ya existe en la instancia.", nuevoUsuario.NombreUsuario);
            }
            else
            {
                listaUsuarios.Add(nuevoUsuario);
                return true;
            }
        }

        public bool ComprobarCredenciales(Usuario usuario)
        {
            foreach (Usuario u in listaUsuarios)
            {
                if (usuario.NombreUsuario == u.NombreUsuario && usuario.Contraseña == u.Contraseña)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
