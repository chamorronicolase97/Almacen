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
    public class Venta
    {
        private int _id;
        private DateTime _fechaVenta;
        private Usuario _usuario;
        private Cliente _cliente;
        private decimal? _total;


        #region Constantes
        const string Tabla = "dbo.Ventas";
        public const string NombreClase = "Venta";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public DateTime FechaVenta { get { return _fechaVenta; } set { _fechaVenta = value; } }   
        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }
        public decimal? Total { get { return _total; } set { _total = value; } }
        #endregion

        public Venta() { }
        public Venta(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Venta(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where VentaID = {ID}";

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
            ID = Convert.ToInt32(dr["VentaID"]);
            _fechaVenta = Convert.ToDateTime(dr["FechaVenta"]);

            _usuario = null;
            if (dr["CodUsuarioCaja"] != DBNull.Value) _usuario =  Usuario.GetUsuario(Convert.ToString(dr["CodUsuarioCaja"]));

            _cliente = null;
            if (dr["NroCliente"] != DBNull.Value) _cliente = new Cliente(Convert.ToInt32(dr["NroCliente"]));

            _total = null;
            if (dr["Total"] != DBNull.Value) _total = Convert.ToDecimal(dr["Total"]);
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (NroCliente, FechaVenta, CodUsuarioCaja, Total)
                        Values(@NroCliente, @fecha, @CodUsuarioCaja, @Total);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroCliente", SqlDbType.Int).Value = Cliente.ID;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaVenta;
            cmd.Parameters.Add("@CodUsuarioCaja", SqlDbType.VarChar).Value = Usuario.CodUsuario;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = DBNull.Value;
            if (Total != null) cmd.Parameters["@Total"].Value = Total;

            ID = CalcularNroVenta();

            cn.Ejecutar(cmd);
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET NroCliente = @NroCliente,
                                         FechaVenta = @FechaVenta,
                                         CodUsuarioCaja = @CodUsuarioCaja,
                                         Total = @Total
              
                                             WHERE VentaID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroCliente", SqlDbType.Int).Value = Cliente.ID;
            cmd.Parameters.Add("@FechaVenta", SqlDbType.DateTime).Value = FechaVenta;
            cmd.Parameters.Add("@CodUsuarioCaja", SqlDbType.VarChar).Value = Usuario.CodUsuario;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = DBNull.Value;
            if (Total != null) cmd.Parameters["@Total"].Value = Total;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);
        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE VentaID = @ID;";
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

        public static List<Venta> ListarVentas()
        {
            DataTable dt = Listar();
            List<Venta> lista = new List<Venta>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Venta(dr));
            }

            return lista;
        } 
        
        public static List<Venta> ListarVentasEnEldia(Usuario usuario)
        {
            string q = $@"SELECT *
                FROM dbo.Ventas
            where CONVERT(DATE, FechaVenta) = CONVERT(DATE, '{DateTime.Now.ToString("yyyyMMdd")}')
            and CodUsuarioCaja = @CodUsuario;";

            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar).Value = usuario.CodUsuario;
            Conexion cn = new Conexion();
            DataTable dt = cn.Consultar(cmd);
            List<Venta> ventas = new List<Venta>();
            foreach (DataRow dr in dt.Rows) 
            {
                ventas.Add(new Venta(dr));
            }
            return ventas;
        }

        public static int CalcularNroVenta()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT VentaID FROM dbo.Ventas order by 1 desc";
            SqlCommand cmd = new SqlCommand(q);
            DataTable dt = cn.Consultar(cmd);
            if (dt.Rows.Count > 0) { return Convert.ToInt32(dt.Rows[0]["VentaID"]); }
            else { return 1; }
        }
    }
}
