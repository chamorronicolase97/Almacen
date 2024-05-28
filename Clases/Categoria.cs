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
    public class Categoria
    {
        private int _id;
        private string _descripcion;
        private decimal _utilidad;

        #region Constantes
        const string Tabla = "dbo.Categorias";
        const string NombreClase = "Categoria";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal Utilidad { get { return _utilidad; } set { _utilidad = value; } }
        #endregion



        public static DataTable Listar()
        {
            Conexion cn = new Conexion();        
            string q = @$"Select * from {Tabla}";
            return cn.Consultar(q);
        }
    }
}
