using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases
{
    public class Proveedor
    {
        private int _id;
        private string _cuit; 
        private string _razonSocial;
        private string _direccion;
        private string _telefono;

        #region Constantes
        const string Tabla = "dbo.Proveedores";
        const string NombreClase = "Proveedor";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string RazonSocial { get { return _razonSocial; } set { _razonSocial = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        #endregion

        public static DataTable Listar()
        {
            Conexion cn = new Conexion();        
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }
    }
}
