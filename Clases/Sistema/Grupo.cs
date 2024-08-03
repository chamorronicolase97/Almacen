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
        private int _id;
        private string _descripcion;

        #region Constantes
        const string Tabla = "dbo.Grupos";
        public const string NombreClase = "Grupo";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion

        public Grupo() { }
        public Grupo(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Grupo(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where GrupoID = {ID}";

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
            ID = Convert.ToInt32(dr["GrupoID"]);
            _descripcion = Convert.ToString(dr["Descripcion"]);
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (Descripcion)
                        Values(@Descripcion);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET Descripcion = @Descripcion, 
                                             Utilidad = @Utilidad
                                             WHERE GrupoID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE GrupoID = @ID;";
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

        public static List<Grupo> ListarGrupos()
        {
            DataTable dt = Listar();
            List<Grupo> lista = new List<Grupo>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Grupo(dr));
            }

            return lista;
        }

        public bool EsVacio()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Usuarios WHERE GrupoID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return false; }
            else { return true; }
        }
    }
}
