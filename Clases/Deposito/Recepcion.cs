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
    public class Recepcion
    {
        private int _id;
        private Pedido? _pedido;
        private DateTime _fechaEntrega;

        #region Constantes
        const string Tabla = "dbo.Recepciones";
        public const string NombreClase = "Recepcion";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public Pedido? Pedido { get { return _pedido; } set { _pedido = value; } }
        public DateTime FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }
        #endregion

        public Recepcion() { }
        public Recepcion(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Recepcion(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where RecepcionID = {ID}";

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
            ID = Convert.ToInt32(dr["RecepcionID"]);

            _pedido = null;

            if (dr["NroPedido"] != DBNull.Value) { _pedido = new Pedido(Convert.ToInt32(dr["NroPedido"])); }

            _fechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (NroPedido, FechaEntrega)
                        Values(@NroPedido, @fecha);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Pedido.ID;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;

            cn.Ejecutar(cmd);

            ID = CalcularNroRecepcion();
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET NroPedido = @NroPedido,
                                             FechaEntrega = @fecha 
                                             WHERE RecepcionID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@NroPedido", SqlDbType.Int).Value = Pedido.ID;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE RecepcionID = @ID;";
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

        public static List<Recepcion> ListarRecepcions()
        {
            DataTable dt = Listar();
            List<Recepcion> lista = new List<Recepcion>();
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Recepcion(dr));
            }

            return lista;
        }

        public bool TieneRecepcion()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Recepciones WHERE RecepcionID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            DataTable dt = cn.Consultar(cmd);
            
            if(dt.Rows.Count > 0) { return true; }
            else { return false; }
        }

        public static Recepcion GetRecepcion(int RecepcionID)
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Recepciones WHERE RecepcionID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = RecepcionID;

            DataTable dt = cn.Consultar(cmd);

            if (dt.Rows.Count > 0) { return new Recepcion(dt.Rows[0]); }
            else { return null;}         
        }

        public static int CalcularNroRecepcion()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT RecepcionID FROM dbo.Recepciones order by 1 desc";
            SqlCommand cmd = new SqlCommand(q);
            DataTable dt = cn.Consultar(cmd);
            if (dt.Rows.Count > 0) { return Convert.ToInt32(dt.Rows[0]["RecepcionID"]) + 1; }
            else { return 1; }
        }
    }
}
