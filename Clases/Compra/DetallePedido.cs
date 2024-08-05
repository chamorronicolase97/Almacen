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
    public class DetallePedido
    {
        private Pedido pedido;
        private Producto producto;
        private Proveedor proveedor;
        private int _cantidad;
        private decimal _costoUnitario;

        #region Constantes
        const string Tabla = "dbo.DetallesPedidos";
        public const string NombreClase = "DetallePedido";
        #endregion

        #region Propiedades
        public Pedido Pedido { get { return pedido; } set { pedido = value; } }
        public Producto Producto { get { return producto; } set { producto = value; } }
        public Proveedor Proveedor { get { return proveedor; } set { proveedor = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal CostoUnitario { get { return _costoUnitario; } set { _costoUnitario = value; } }
        #endregion

        public DetallePedido() { }
        //public DetallePedido(int nroPedido, int productoID, int proveedorID)
        //{
        //    this.Pedido = nroPedido;
        //    if (ID != 0) Abrir();
        //}
        public DetallePedido(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where NroPedido = @nroPedido
                                                and ProductoID = @productoID
                                                and ProveedorID = @proveedorID";

            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@nroPedido", SqlDbType.Int).Value = Pedido.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@proveedorID", SqlDbType.Int).Value = Proveedor.ID;

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
                throw new Exception($"Error al abrir el objeto {NombreClase}. Clave {Pedido.ID + Producto.ID + Proveedor.ID}", ex);
            }

        }

        private void CargaDatos(DataRow dr)
        {
            pedido = new Pedido(Convert.ToInt32(dr["NroPedido"]));
            producto = new Producto(Convert.ToInt32(dr["ProductoID"]));
            proveedor = new Proveedor(Convert.ToInt32(dr["ProveedorID"]));
            _cantidad = Convert.ToInt32(dr["Cantidad"]);
            _costoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
        }

        public void Insertar(int nroPedido, int productoID, int proveedorID)
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (NroPedido, ProductoID, ProveedorID, Cantidad, CostoUnitario)
                        Values(@NroPedido, @ProductoID, @ProveedorID, @cantidad, @costoUnitario);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = nroPedido;
            cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = productoID;
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = proveedorID;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@costoUnitario", SqlDbType.Decimal).Value = CostoUnitario;

            cn.Ejecutar(cmd);
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET Cantidad = @cantidad,
                                             CostoUnitario = @costoUnitario
                                             WHERE NroPedido = @nroPedido
                                             and ProductoID = @productoID
                                             and ProveedorID = @proveedorID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@costoUnitario", SqlDbType.Decimal).Value = CostoUnitario;
            cmd.Parameters.Add("@nroPedido", SqlDbType.Int).Value = Pedido.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@proveedorID", SqlDbType.Int).Value = Proveedor.ID;

            cn.Ejecutar(cmd);
        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE NroPedido = @nroPedido
                                              and ProductoID = @productoID
                                              and ProveedorID = @proveedorID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@nroPedido", SqlDbType.Int).Value = Pedido.ID;
            cmd.Parameters.Add("@productoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@proveedorID", SqlDbType.Int).Value = Proveedor.ID;

            cn.Ejecutar(cmd);

        }

        public static DataTable Listar()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }

        public static DataTable Listar(int NroPedido)
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where NroPedido = @NroPedido";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = NroPedido;
            return cn.Consultar(cmd);
        }

        public static List<DetallePedido> ListarDetallesPedidos(int NroPedido)
        { 
            DataTable dt = Listar(NroPedido);
            List<DetallePedido> lista = new List<DetallePedido>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new DetallePedido(dr));
            }

            return lista;
        }

    }
}
