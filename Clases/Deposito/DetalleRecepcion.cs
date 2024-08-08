using Almacen.Clases.Administracion;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Compra
{
    public class DetalleRecepcion
    {
        private Recepcion _recepcion;
        private Producto producto;
        private int _cantidad;
        private decimal _costoUnitario;
        public DateTime _fechaRecepcion;

        #region Constantes
        const string Tabla = "dbo.DetallesRecepciones";
        public const string NombreClase = "DetalleRecepcion";
        #endregion

        #region Propiedades
        public Recepcion Recepcion { get { return _recepcion; } set { _recepcion = value; } }
        public Producto Producto { get { return producto; } set { producto = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal CostoUnitario { get { return _costoUnitario; } set { _costoUnitario = value; } }
        public DateTime FechaRecepcion { get { return _fechaRecepcion; }set { _fechaRecepcion = value; } }
        #endregion

        public DetalleRecepcion() { }
        //public DetalleRecepcion(int RecepcionID, int productoID, int proveedorID)
        //{
        //    this.Recepcion = RecepcionID;
        //    if (ID != 0) Abrir();
        //}
        public DetalleRecepcion(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where RecepcionID = @RecepcionID
                                                and ProductoID = @productoID";

            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@RecepcionID", SqlDbType.Int).Value = Recepcion.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;

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
                throw new Exception($"Error al abrir el objeto {NombreClase}. Clave {Recepcion.ID + Producto.ID}", ex);
            }

        }

        private void CargaDatos(DataRow dr)
        {
            Recepcion = new Recepcion(Convert.ToInt32(dr["RecepcionID"]));
            producto = new Producto(Convert.ToInt32(dr["ProductoID"]));
            _cantidad = Convert.ToInt32(dr["Cantidad"]);
            _costoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
            _fechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]);
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (RecepcionID, ProductoID, Cantidad, CostoUnitario, FechaRecepcion)
                        Values(@RecepcionID, @ProductoID, @cantidad, @costoUnitario, @fechaRecepcion);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@RecepcionID", SqlDbType.Int).Value = Recepcion.ID;
            cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@costoUnitario", SqlDbType.Decimal).Value = CostoUnitario;
            cmd.Parameters.Add("@fechaRecepcion", SqlDbType.DateTime).Value = FechaRecepcion;
            cn.Ejecutar(cmd);
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET Cantidad = @cantidad,
                                             CostoUnitario = @costoUnitario
                                             WHERE RecepcionID = @RecepcionID
                                             and ProductoID = @productoID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@costoUnitario", SqlDbType.Decimal).Value = CostoUnitario;
            cmd.Parameters.Add("@RecepcionID", SqlDbType.Int).Value = Recepcion.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;

            cn.Ejecutar(cmd);
        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE RecepcionID = @RecepcionID
                                              and ProductoID = @productoID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@RecepcionID", SqlDbType.Int).Value = Recepcion.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;

            cn.Ejecutar(cmd);

        }

        public static DataTable Listar()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }

        public static DataTable Listar(int RecepcionID)
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where RecepcionID = @RecepcionID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@RecepcionID", SqlDbType.Int).Value = RecepcionID;
            return cn.Consultar(cmd);
        }

        public static List<DetalleRecepcion> ListarDetallesRecepciones(Recepcion Recepcion)
        {
            DataTable dt = Listar(Recepcion.ID);
            List<DetalleRecepcion> lista = new List<DetalleRecepcion>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new DetalleRecepcion(dr));
            }

            return lista;
        }

    }
}
