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
        private int _permisoID;
        private string _codPermiso;
        private string _descripcion;

        #region Constantes
        const string Tabla = "dbo.Permisos";
        public const string NombreClase = "Permiso";
        #endregion

        #region Propiedades
        public int PermisoID { get { return _permisoID; } set { _permisoID = value; } }
        public string CodPermiso { get { return _codPermiso; } set { _codPermiso = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion

        public Permiso() { }
        public Permiso(int ID)
        {
            this.PermisoID = ID;
            if (ID != 0) Consultar(ID);
        }

        public void Insertar()
        {
            using (var context = new AlmacenContext())
            {
                context.Permisos.Add(this);
                context.SaveChanges();
            }
        }

        public void Modificar()
        {
            Permiso permiso = new Permiso();
            using (var context = new AlmacenContext())
            {
                permiso = context.Permisos.Find(this.PermisoID);
                permiso.CodPermiso = this.CodPermiso;
                permiso.Descripcion = this.Descripcion;
                context.SaveChanges();
            }
        }

        public void Eliminar()
        {
            using (var context = new AlmacenContext())
            {
                context.Permisos.Remove(this);
                context.SaveChanges();
            }
        }

        public static DataTable ListarGrilla()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }

        public static List<Grupo> Listar()
        {

            List<Grupo> lista = new List<Grupo>();
            using (var context = new AlmacenContext())
            {
                lista = context.Grupos.ToList();
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
                permiso = new Permiso(Convert.ToInt32(dt.Rows[1]));
            }
                return permiso;
        }

        public Permiso Consultar(int ID)
        {
            Permiso permiso;
            using (var context = new AlmacenContext())
            {
                permiso= context.Permisos.Find(ID);
            }
            if (permiso != null)
            {
                _permisoID = permiso.PermisoID;
                _descripcion = permiso.Descripcion;
                _codPermiso = permiso.CodPermiso;
                return permiso;
            }
            else
            {
                return null;
            }
        }
    }
}
