using Almacen.Clases.Sistema;
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
    public class Producto
    {
        private int _id;
        private string _descripcion;
        private decimal? _costo;
        private string _codigoDeBarra;
        private Categoria _categoria;
        private Proveedor _proveedor;
        private int? _stock;

        #region Constantes
        const string Tabla = "dbo.Productos";
        public const string NombreClase = "Producto";
        #endregion

        #region Propiedades
        public int ID { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal? Costo { get { return _costo; } set { _costo = value; } }
        public string CodigoDeBarra { get { return _codigoDeBarra; } set { _codigoDeBarra = value; } }
        public Categoria Categoria { get { return _categoria; } set { _categoria = value; } }
        public Proveedor Proveedor { get { return _proveedor; } set { _proveedor = value; } } 
        public int? Stock { get { return _stock; } set { _stock = value; } }
        
        public decimal ValorVenta => Costo.GetValueOrDefault(0) + ((Costo.GetValueOrDefault(0) * Categoria.Utilidad) / 100);
        #endregion

        public Producto() { }
        public Producto(int ID)
        {
            this.ID = ID;
            if (ID != 0) Abrir();
        }
        public Producto(DataRow dr) => CargaDatos(dr);

        public void Abrir()
        {
            Conexion cn = new Conexion();
            string q = @$"Select * from {Tabla} where ProductoID = {ID}";

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
            ID = Convert.ToInt32(dr["ProductoID"]);
            _descripcion = Convert.ToString(dr["Descripcion"]);
            _costo = FuncionesAuxiliares.ConvertToNDecimal(dr["Costo"].ToString());
            _codigoDeBarra = Convert.ToString(dr["CodigoDeBarra"]);

            if (dr["CategoriaID"] != DBNull.Value) _categoria = new Categoria(Convert.ToInt32(dr["CategoriaID"]));
            if (dr["ProveedorID"] != DBNull.Value) _proveedor = new Proveedor(Convert.ToInt32(dr["ProveedorID"]));
            _stock = FuncionesAuxiliares.ConvertToNInt(dr["Stock"].ToString());
        }


        public void Insertar()
        {
            Conexion cn = new Conexion();
            string q = $@"INSERT INTO {Tabla} (Descripcion, Costo, CodigoDeBarra, CategoriaID, ProveedorID, Stock)
                        Values(@Descripcion, @Costo, @CodigoDeBarra, @CategoriaID, @ProveedorID, @Stock);";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@Costo", SqlDbType.Decimal).Value = DBNull.Value;
            cmd.Parameters.Add("@CodigoDeBarra", SqlDbType.VarChar).Value = CodigoDeBarra;
            cmd.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = Categoria.CategoriaID;
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = Proveedor.ID;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;

            cn.Ejecutar(cmd);

        }

        public void Modificar()
        {
            Conexion cn = new Conexion();
            string q = $@"UPDATE {Tabla} SET Descripcion = @Descripcion, 
                                             Costo = @Costo,
                                             CodigoDeBarra = @CodigoDeBarra,
                                             CategoriaID = @CategoriaID,
                                             ProveedorID = @ProveedorID,
                                             Stock = @Stock
                                             WHERE ProductoID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("@Costo", SqlDbType.Decimal).Value = FuncionesAuxiliares.ConvertDBNullIfNull(Costo);
            cmd.Parameters.Add("@CodigoDeBarra", SqlDbType.VarChar).Value = CodigoDeBarra;
            cmd.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = Categoria.CategoriaID;
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = Proveedor.ID;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public void Eliminar()
        {
            Conexion cn = new Conexion();
            string q = $@"DELETE FROM {Tabla} WHERE ProductoID = @ID;";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cn.Ejecutar(cmd);

        }

        public static DataTable ListarGrilla()
        {
            Conexion cn = new Conexion();
            string q = @$"select prod.ProductoID, prod.Descripcion, prod.Costo, prod.CodigoDeBarra, cat.CategoriaID, cat.Descripcion as Categoria, prod.ProveedorID, prov.RazonSocial as Proveedor
                            from {Tabla} prod
                            left join dbo.Categorias cat on prod.CategoriaID = cat.CategoriaID
                            left join dbo.Proveedores prov on prod.ProveedorID = prov.ProveedorID
                            where 1=1";

            return cn.Consultar(q);
        }

        public static DataTable ListarPorProveedor(Proveedor Proveedor)
        {
            Conexion cn = new Conexion();
            string q = @$"select prod.ProductoID, prod.Descripcion, prod.Costo, prod.CodigoDeBarra, cat.CategoriaID, cat.Descripcion as Categoria, prod.ProveedorID, prov.RazonSocial as Proveedor
                            from {Tabla} prod
                            left join dbo.Categorias cat on prod.CategoriaID = cat.CategoriaID
                            left join dbo.Proveedores prov on prod.ProveedorID = prov.ProveedorID
                            where prod.ProveedorID = @ProveedorID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ProveedorID", SqlDbType.Int).Value = Proveedor.ID;

            return cn.Consultar(cmd);

        }

        public void ActualizarStock(int Cantidad)
        {            
            Stock = Cantidad;
            Modificar();
        }
    }
}
