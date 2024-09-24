using Almacen.Clases.Administracion;
using Almacen.Clases.Sistema;
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
    public class Pedido
    {
        private int _id;
        private DateTime _fechaEntrega;
        private Proveedor _proveedor;
        private PedidoEstado _pedidoEstado;

        #region Constantes
        const string Tabla = "dbo.Pedidos";
        public const string NombreClase = "Pedido";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public DateTime FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }
        public Proveedor Proveedor { get { return _proveedor; } set { _proveedor = value; } }
        public PedidoEstado PedidoEstado { get { return _pedidoEstado; } set { _pedidoEstado = value; } }
        #endregion

        public Pedido() { }
        public Pedido(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Pedido(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where NroPedido = {ID}";

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
            ID = Convert.ToInt32(dr["NroPedido"]);
            _fechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);

            if (dr["ProveedorID"] != DBNull.Value) _proveedor = new Proveedor(Convert.ToInt32(dr["ProveedorID"]));

            _pedidoEstado = null;
            if (dr["EstadoID"] != DBNull.Value) _pedidoEstado = new PedidoEstado(Convert.ToInt32(dr["EstadoID"]));
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (FechaEntrega, ProveedorID, EstadoID)
                        Values(@fecha, @ProveedorID, @EstadoID);";
            SqlCommand cmd = new SqlCommand(q);            
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = Proveedor.ID;
            cmd.Parameters.Add("@EstadoID", SqlDbType.Int).Value = FuncionesAuxiliares.ConvertDBNullIfNull(PedidoEstado.PedidoEstadoID);
            cn.Ejecutar(cmd);

            ID = CalcularNroPedido();
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET FechaEntrega = @fecha,
                                             ProveedorID = @ProveedorID,
                                             EstadoID = @EstadoID
                                             WHERE NroPedido = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = Proveedor.ID;
            cmd.Parameters.Add("@EstadoID", SqlDbType.Int).Value = FuncionesAuxiliares.ConvertDBNullIfNull(PedidoEstado.PedidoEstadoID);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);
        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE NroPedido = @ID;";
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

        public static List<Pedido> ListarPedidos()
        {
            DataTable dt = Listar();
            List<Pedido> lista = new List<Pedido>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Pedido(dr));
            }

            return lista;
        }

        public bool TieneRecepcion()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Recepciones WHERE NroPedido = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);
            
            if(dt.Rows.Count > 0) { return true; }
            else { return false; }
        }

        public static int CalcularNroPedido()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT NroPedido FROM dbo.Pedidos order by 1 desc";
            SqlCommand cmd = new SqlCommand(q);
            DataTable dt = cn.Consultar(cmd);
            if (dt.Rows.Count > 0) {return Convert.ToInt32(dt.Rows[0]["NroPedido"]); }
            else { return 1; }
        }
    }
}
