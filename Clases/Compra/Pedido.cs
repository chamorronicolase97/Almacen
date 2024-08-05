﻿using Sistema;
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

        #region Constantes
        const string Tabla = "dbo.Pedidos";
        public const string NombreClase = "Pedido";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public DateTime FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }
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
        }

        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (FechaEntrega)
                        Values(@fecha);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;

            cn.Ejecutar(cmd);
        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET FechaEntrega = @fecha, 
                                             WHERE NroPedido = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FechaEntrega;
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
    }
}
