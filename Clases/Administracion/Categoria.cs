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
    public class Categoria
    {
        private int _id;
        private string _descripcion;
        private decimal _utilidad;

        #region Constantes
        const string Tabla = "dbo.Categorias";
        public const string NombreClase = "Categoria";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal Utilidad { get { return _utilidad; } set { _utilidad = value; } }
        #endregion

        public Categoria() { }
        public Categoria(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Categoria(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where CategoriaID = {ID}";

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
            ID = Convert.ToInt32(dr["CategoriaID"]);
            _descripcion = Convert.ToString(dr["Descripcion"]);
            _utilidad = Convert.ToDecimal(dr["Utilidad"]);
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (Descripcion, Utilidad)
                        Values(@Descripcion, @Utilidad);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@Utilidad", SqlDbType.Decimal).Value = Utilidad;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET Descripcion = @Descripcion, 
                                             Utilidad = @Utilidad
                                             WHERE CategoriaID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@Utilidad", SqlDbType.Decimal).Value = Utilidad;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE CategoriaID = @ID;";
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

        public static List<Categoria> ListarCategorias()
        {
            DataTable dt = Listar();
            List<Categoria> lista = new List<Categoria>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Categoria(dr));
            }

            return lista;
        }
    }
}
