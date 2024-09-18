using Almacen.Clases.Sistema;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Administracion
{
    public class Usuario
    {
        private int _usuarioID;
        private string _nombreApellido;
        private string _codUsuario;
        private string  _contraseña;
        private Grupo _grupo;

        #region Constantes
        const string Tabla = "dbo.Usuarios";
        public const string NombreClase = "Usuario";
        #endregion

        #region Propiedades
        public int UsuarioID { get { return _usuarioID; } set { _usuarioID = value; } }
        public string NombreApellido { get { return _nombreApellido; } set { _nombreApellido = value; } }
        public string CodUsuario { get { return _codUsuario; } set { _codUsuario = value; } }
        public string Contraseña { get { return _contraseña; } set { _contraseña = value; } }
        public Grupo Grupo { get { return _grupo; } set { _grupo = value; } }
        #endregion

        public Usuario() { }
        public Usuario(int ID)
        {
            this.UsuarioID = ID;
            if (ID != 0) Consultar(ID);
        }

        public void Insertar()
        {
            using (var context = new AlmacenContext())
            {
                context.Usuarios.Add(this);
                context.SaveChanges();
            }
        }

        public void Modificar()
        {
            Usuario usuario = new Usuario();
            using (var context = new AlmacenContext())
            {
                usuario = context.Usuarios.Find(this.UsuarioID);
                usuario.NombreApellido = this.NombreApellido;
                usuario.CodUsuario = this.CodUsuario;
                usuario.Contraseña = this.Contraseña;
                usuario.Grupo = this.Grupo;
                context.SaveChanges();
            }
        }

        public void Eliminar()
        {
            using (var context = new AlmacenContext())
            {
                context.Usuarios.Remove(this);
                context.SaveChanges();
            }
        }

        public static DataTable ListarGrilla()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} usu left join dbo.Grupos gru on usu.GrupoID = gru.GrupoID";
            return cn.Consultar(q);
        }

        public static List<Usuario> Listar()
        {

            List<Usuario> lista = new List<Usuario>();
            using (var context = new AlmacenContext())
            {
                lista = context.Usuarios.ToList();
            }

            return lista;
        }

        public static Usuario GetUsuario(string User)
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where CodUsuario = @User";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = User;

            DataTable dt = new DataTable();


            try
            {
                dt = cn.Consultar(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception($"Usuario no Encontrado", ex);
            }
            if (dt.Rows.Count > 0)
            {
                return new Usuario(Convert.ToInt32(dt.Rows[0]));
            }
            else
            {
                return null;
            }
        }

        public static Usuario? GetUsuario(string User, string Password)
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where CodUsuario = @User
                        and Contraseña = @Password";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = User;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Encrypt.HashString(Password);

            DataTable dt = new DataTable();

           
            try
            {
              dt = cn.Consultar(cmd);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Usuario no Encontrado", ex);
            }
            if (dt.Rows.Count > 0)
            {
                return new Usuario(Convert.ToInt32(dt.Rows[0]["UsuarioID"]));
            }
            else
            {
                return null;
            }

        }

        public Usuario Consultar(int ID)
        {
            Usuario usuario;
            using (var context = new AlmacenContext())
            {
                usuario = context.Usuarios.Find(ID);
            }
            if (usuario != null)
            {
                _usuarioID = usuario.UsuarioID;
                _nombreApellido = usuario.NombreApellido;
                _codUsuario = usuario.CodUsuario;
                _contraseña = usuario.Contraseña;
                _grupo = usuario.Grupo;
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}


