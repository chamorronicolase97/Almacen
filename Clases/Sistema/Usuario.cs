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
        private int _id;
        private string _nombreApellido;
        private string _codUsuario;
        private string  _contraseña;
        private Grupo _grupo;

        #region Constantes
        const string Tabla = "dbo.Usuarios";
        public const string NombreClase = "Usuario";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string NombreApellido { get { return _nombreApellido; } set { _nombreApellido = value; } }
        public string CodUsuario { get { return _codUsuario; } set { _codUsuario = value; } }
        public string Contraseña { get { return _contraseña; } set { _contraseña = value; } }
        public Grupo Grupo { get { return _grupo; } set { _grupo = value; } }
        #endregion

        public Usuario() { }
        public Usuario(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Usuario(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where UsuarioID = {ID}";

            DataTable dt = cn.Consultar(q);
            try
            {

                if (dt.Rows.Count > 0)
                {
                    CargaDatos(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al abrir el objeto {NombreClase}. Clave {ID}", ex);
            }

        }



        private void CargaDatos(DataRow dr)
        {
            ID = Convert.ToInt32(dr["UsuarioID"]);
            _nombreApellido = Convert.ToString(dr["NombreApellido"]);
            _codUsuario = Convert.ToString(dr["CodUsuario"]);
           // _contraseña = HASHEAR
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (NombreApellido, CodUsuario, Contraseña, GrupoID)
                        Values(@NombreApellido, @CodUsuario, @Contraseña, @GrupoID);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NombreApellido", SqlDbType.VarChar).Value = NombreApellido;
            cmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar).Value = CodUsuario;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarBinary).Value = Contraseña;
            cmd.Parameters.Add("@GrupoID", SqlDbType.Int).Value = Grupo.ID;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET NombreApellido = @Descripcion, 
                                             CodUsuario = @Utilidad,
                                             Contraseña = @Contraseña,
                                             GrupoID = @GrupoID
                                             WHERE UsuarioID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NombreApellido", SqlDbType.VarChar).Value = NombreApellido;
            cmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar).Value = CodUsuario;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarBinary).Value = Encrypt.HashString(Contraseña);
            cmd.Parameters.Add("@GrupoID", SqlDbType.Int).Value = Grupo.ID;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE UsuarioID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public static DataTable Listar()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }

        public static List<Usuario> ListarUsuarios()
        {
            DataTable dt = Listar();
            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Usuario(dr));
            }

            return lista;
        }

        public static Usuario? GetUsuario(string User, string Password)
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where CodUsuario = @User
                        and Contraseña = @Password";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = User;
            cmd.Parameters.Add("@Password", SqlDbType.VarBinary).Value = Encrypt.HashString(Password);

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
                return new Usuario((dt.Rows[0]));
            }
            else
            {
                return null;
            }

        }
    }
}


