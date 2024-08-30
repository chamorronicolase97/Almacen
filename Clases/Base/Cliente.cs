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
    public class Cliente
    {
        private int _id;
        private string _cuit;
        private string _denominacion;
        private string _domicilio;
        private string _email;
        private string _telefono;
        private bool _empleado;
        private bool _preferencial;

        #region Constantes
        const string Tabla = "dbo.Clientes";
        public const string NombreClase = "Cliente";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public string Direccion { get { return _domicilio; } set { _domicilio = value; } }
        public string Mail { get { return _email; } set { _email = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public bool Empleado { get { return _empleado; } set { _empleado = value; } }
        public bool Preferencial { get { return _preferencial; } set { _preferencial = value; } }

        #endregion

        public Cliente(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }

        public Cliente(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where ClienteID = {ID}";

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
            ID = Convert.ToInt32(dr["ClienteID"]);
            _cuit = Convert.ToString(dr["CUIT"]);
            _denominacion = Convert.ToString(dr["Denominacion"]);
            _domicilio = Convert.ToString(dr["Domicilio"]);
            _email = Convert.ToString(dr["Email"]);
            _telefono = Convert.ToString(dr["Telefono"]);
            _empleado = Convert.ToBoolean(dr["Empleado"]);
            _preferencial = Convert.ToBoolean(dr["Preferencial"]);

        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (CUIT, Denominacion, Domicilio, Email, Telefono, Empleado, Preferencial)
                        Values(@CUIT, @Denominacion, @Domicilio, @Email, @Telefono, @Empleado, @Preferencial);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = Cuit;
            cmd.Parameters.Add("@Denominacion", SqlDbType.VarChar).Value = Denominacion;
            cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Mail;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@Empleado", SqlDbType.Bit).Value = Empleado;
            cmd.Parameters.Add("@Preferencial", SqlDbType.VarChar).Value = Preferencial;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET CUIT = @CUIT, 
                                             Denominacion = @Denominacion,
                                             Domicilio = @Domicilio,
                                             Email = @Email,
                                             Telefono = @Telefono,
                                             Empleado = @Empleado,
                                             Preferencial = @Preferencial
                                             WHERE ClienteID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = Cuit;
            cmd.Parameters.Add("@Denominacion", SqlDbType.VarChar).Value = Denominacion;
            cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Mail;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@Empleado", SqlDbType.Bit).Value = Empleado;
            cmd.Parameters.Add("@Preferencial", SqlDbType.VarChar).Value = Preferencial;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE ClienteID = @ID;";
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
