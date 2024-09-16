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
    public class PermisoGrupo
    {
        private Permiso _permiso;
        private Grupo _grupo;

        #region Constantes
        const string Tabla = "dbo.PermisosPermisoGrupos";
        public const string NombreClase = "PermisoGrupo";
        #endregion

        #region Propiedades
        public Permiso Permiso { get { return _permiso; } set { _permiso = value; } }
        public Grupo Grupo { get { return _grupo; }set { _grupo = value; } }
        #endregion

        public PermisoGrupo() { }
        public PermisoGrupo(int GrupoID, string CodPermiso)
        {
            this.Grupo = new Grupo(GrupoID);
            this.Permiso = Permiso.GetPermiso(CodPermiso);
            if (GrupoID != 0 && CodPermiso.Length > 0) Abrir();
        }
        public PermisoGrupo(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where GrupoID = {Grupo.GrupoID} and CodPermiso = {Permiso.CodPermiso} ";

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
                throw new Exception($"Error al abrir el objeto {NombreClase}. Clave {Grupo.GrupoID} {Permiso.CodPermiso}", ex);
            }

        }



        private void CargaDatos(DataRow dr)
        {
            _grupo = null;
            if (dr["GrupoID"] != DBNull.Value) _grupo = new Grupo(Convert.ToInt32(dr["GrupoID"]));

            _permiso = null;
            if (dr["CodPermiso"] != DBNull.Value) _permiso = Permiso.GetPermiso(dr["CodPermiso"].ToString()); ;
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (GrupoID, CodPermiso)
                        Values(@GrupoID, @CodPermiso);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@GrupoID", SqlDbType.Int).Value = Grupo.GrupoID;
            cmd.Parameters.Add("@CodPermiso", SqlDbType.VarChar).Value = Permiso.CodPermiso;

            cn.Ejecutar(cmd);

        }


        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE GrupoID = @GrupoID and CodPermiso = @CodPermiso ;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@GrupoID", SqlDbType.Int).Value = Grupo.GrupoID;
            cmd.Parameters.Add("@CodPermiso", SqlDbType.Int).Value = Permiso.CodPermiso;

            cn.Ejecutar(cmd);

        }

        public static DataTable Listar()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }

        public static List<PermisoGrupo> ListarPermisosPermisoGrupos()
        {
            DataTable dt = Listar();
            List<PermisoGrupo> lista = new List<PermisoGrupo>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new PermisoGrupo(dr));
            }

            return lista;
        }
    }
}
