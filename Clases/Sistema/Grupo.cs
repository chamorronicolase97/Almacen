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
    public class Grupo
    {
        private int _grupoID;
        private string _descripcion;

        #region Constantes
        const string Tabla = "dbo.Grupos";
        public const string NombreClase = "Grupo";
        #endregion

        #region Propiedades
        public int GrupoID { get { return _grupoID; } set { _grupoID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion

        public Grupo() { }
        public Grupo(int ID)
        {
            this.GrupoID = ID;
            if (ID != 0) Consultar(ID);
        }

        public void Insertar()
        {
            using (var context = new AlmacenContext())
            {
                context.Grupos.Add(this);
                context.SaveChanges();
            }
        }

        public void Modificar()
        {
            Grupo grupo = new Grupo();
            using (var context = new AlmacenContext())
            {
                grupo = context.Grupos.Find(this.GrupoID);
                grupo.Descripcion = this.Descripcion;
                context.SaveChanges();
            }
        }

        public void Eliminar()
        {
            using (var context = new AlmacenContext())
            {
                context.Grupos.Remove(this);
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

        public bool EsVacio()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Usuarios WHERE GrupoID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = GrupoID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return false; }
            else { return true; }
        }

        public Grupo Consultar(int ID)
        {
            Grupo grupo;
            using (var context = new AlmacenContext())
            {
                grupo = context.Grupos.Find(ID);
            }
            if (grupo != null)
            {
                _grupoID = grupo.GrupoID;
                _descripcion = grupo.Descripcion;
                return grupo;
            }
            else
            {
                return null;
            }
        }
    }
}
