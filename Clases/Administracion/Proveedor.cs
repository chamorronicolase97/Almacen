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
    public class Proveedor
    {
        private int _id;
        private string _cuit;
        private string _razonSocial;
        private string _direccion;
        private string _mail;
        private string _telefono;

        #region Constantes
        const string Tabla = "dbo.Proveedores";
        public const string NombreClase = "Proveedor";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string RazonSocial { get { return _razonSocial; } set { _razonSocial = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        #endregion

        public Proveedor(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }

        public Proveedor(DataRow dr) => CargaDatos(dr);

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
            ID = Convert.ToInt32(dr["ProveedorID"]);
            _cuit = Convert.ToString(dr["CUIT"]);
            _razonSocial = Convert.ToString(dr["RazonSocial"]);
            _direccion = Convert.ToString(dr["Direccion"]);
            _mail = Convert.ToString(dr["Mail"]);
            _telefono = Convert.ToString(dr["Telefono"]);
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (CUIT, RazonSocial, Direccion, Mail, Telefono)
                        Values(@CUIT, @RazonSocial, @Direccion, @Mail, @Telefono);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = Cuit;
            cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.Add("@Mail", SqlDbType.VarChar).Value = Mail;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET CUIT = @CUIT, 
                                             RazonSocial = @RazonSocial,
                                             Direccion = @Direccion,
                                             Mail = @Mail,
                                             Telefono = @Telefono
                                             WHERE ProveedorID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = Cuit;
            cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.Add("@Mail", SqlDbType.VarChar).Value = Mail;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE ProveedorID = @ID;";
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
    }
}
