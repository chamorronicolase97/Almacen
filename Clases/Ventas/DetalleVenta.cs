using Almacen.Clases.Administracion;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Venta
{
    public class DetalleVenta
    {
        private int _id;
        private Venta _venta;
        private Producto _producto;
        private int _cantidad;
        private decimal _subtotal;


        #region Constantes
        const string Tabla = "dbo.DetallesVentas";
        public const string NombreClase = "DetalleVenta";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }

        public Venta Venta { get { return _venta; } set { _venta = value; } }
        public Producto Producto { get { return _producto; } set { _producto = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal SubTotal { get { return _subtotal; } set { _subtotal = value; } }

        public decimal CalcularSubTotal => Producto.ValorVenta * Cantidad;
        #endregion

        public DetalleVenta() { }
        public DetalleVenta(int ID, int VentaID)
        {
            this.ID = ID;
            this.Venta = new Venta(VentaID);
            if (ID != 0) Abrir();
        }
        public DetalleVenta(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where DetalleVentaID = {ID} and VentaID = {Venta.ID}";

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
            ID = Convert.ToInt32(dr["DetalleVentaID"]);
            
            if (dr["VentaID"] != DBNull.Value) _venta = new Venta(Convert.ToInt32(dr["VentaID"]));
            
            if (dr["ProductoID"] != DBNull.Value) _producto = new Producto(Convert.ToInt32(dr["ProductoID"]));

            _cantidad = Convert.ToInt32(dr["Cantidad"]);
            _subtotal = Convert.ToDecimal(dr["SubTotal"]);
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (VentaID, ProductoID, Cantidad, SubTotal)
                        Values(@VentaID, @ProductoID, @Cantidad, @SubTotal);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@VentaID", SqlDbType.Int).Value = Venta.ID;
            cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = SubTotal;

            cn.Ejecutar(cmd);

            ID = CalcularUltimoNumeroDetalleVenta();
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET ProductoID = @ProductoID,
                                         Cantidad = @Cantidad,
                                         Subtotal = @Subtotal,                                         
              
                                         WHERE DetalleVentaID = @ID
                                         AND VentaID = @VentaID;";
            SqlCommand cmd = new SqlCommand(q);            
            cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = Producto.ID;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = SubTotal;
            cmd.Parameters.Add("@VentaID", SqlDbType.Int).Value = Venta.ID;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);
        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE DetalleVentaID = @ID and VentaID = @VentaID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@VentaID", SqlDbType.Int).Value = Venta.ID;

            cn.Ejecutar(cmd);

        }

        private int CalcularUltimoNumeroDetalleVenta()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT DetalleVentaID FROM dbo.DetallesVentas
            WHERE VentaID ={Venta.ID} order by 1 desc";
            SqlCommand cmd = new SqlCommand(q);
            DataTable dt = cn.Consultar(cmd);
            if (dt.Rows.Count > 0) { return Convert.ToInt32(dt.Rows[0]["DetalleVentaID"]); }
            else { return 1; }
        }
       
    }
}
