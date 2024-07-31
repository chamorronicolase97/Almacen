using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Administracion
{
    public class Permiso
    {
        private int _id;
        private string _codPermiso;
        private string _descripcion;

        #region Constantes
        const string Tabla = "dbo.Permisos";
        public const string NombreClase = "Permiso";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string CodPermiso { get { return _codPermiso; } set { _codPermiso = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion

        public Permiso() { }
        public Permiso(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Permiso(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where PermisoID = {ID}";

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
            ID = Convert.ToInt32(dr["PermisoID"]);
            _codPermiso = Convert.ToString(dr["CodPermiso"]);
            _descripcion = Convert.ToString(dr["Descripcion"]);
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (CodPermiso, Descripcion)
                        Values(@CodPermiso, @Descripcion);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodPermiso", SqlDbType.VarChar, 50).Value = CodPermiso;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Descripcion;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET CodPermiso = @CodPermiso, 
                                             Descripcion = @Descripcion
                                             WHERE PermisoID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodPermiso", SqlDbType.VarChar, 50).Value = CodPermiso;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE PermisoID = @ID;";
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

        public static List<Permiso> ListarPermisos()
        {
            DataTable dt = Listar();
            List<Permiso> lista = new List<Permiso>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Permiso(dr));
            }

            return lista;
        }

        public static bool ExistePermiso(string CodPermiso)
        {
            Conexion cn = new Conexion(); 
            string q = $@"SELECT * FROM {Tabla}
            WHERE CodPermiso = @CodPermiso";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodPermiso", SqlDbType.VarChar, 50).Value = CodPermiso;
            DataTable dt = cn.Consultar(q);
            
            return dt.Rows.Count > 0;
        }

        public static Permiso GetPermiso(string CodPermiso)
        {
            Permiso permiso = new Permiso();
            Conexion cn = new Conexion();
            string q = $@"SELECT * FROM {Tabla}
            WHERE CodPermiso = @CodPermiso";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodPermiso", SqlDbType.VarChar, 50).Value = CodPermiso;
            DataTable dt = cn.Consultar(q);

            if (dt.Rows.Count > 0)
            {
                permiso = new Permiso(dt.Rows[1]);
            }
                return permiso;
        }
    }
}
