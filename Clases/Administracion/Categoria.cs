using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Clases.Administracion
{
    public class Categoria
    {
        private int _categoriaID;
        private string _descripcion;
        private decimal _utilidad;

        #region Constantes
        const string Tabla = "dbo.Categorias";
        public const string NombreClase = "Categoria";
        #endregion

        #region Propiedades
        public int CategoriaID { get { return _categoriaID; } set { _categoriaID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public decimal Utilidad { get { return _utilidad; } set { _utilidad = value; } }
        #endregion

        public Categoria() { }
        public Categoria(int ID)
        {
            this.CategoriaID = ID;
            if (ID != 0) Consultar(ID);
        }
        
        public void Insertar()
        {
            using (var context = new AlmacenContext())
            {
                context.Categorias.Add(this);
                context.SaveChanges();
            }
        }

        public void Modificar()
        {
            Categoria categoria = new Categoria();
            using (var context = new AlmacenContext())
            {
                categoria = context.Categorias.Find(this.CategoriaID);
                categoria.Utilidad = this.Utilidad;
                categoria.Descripcion = this.Descripcion;
                context.SaveChanges();
            }
        }

        public void Eliminar()
        {
            using (var context = new AlmacenContext())
            {
                context.Categorias.Remove(this);
                context.SaveChanges();
            }
        }

        public static DataTable ListarGrilla()
        {
            Conexion cn = new Conexion();
            string q = @$"select cat.CategoriaID, cat.Descripcion, cat.Utilidad 
                            from {Tabla} cat";
            return cn.Consultar(q);
        }

        public static List<Categoria> ListarCategorias()
        {
           
            List<Categoria> lista = new List<Categoria>();
            using (var context = new AlmacenContext())
            {
                lista = context.Categorias.ToList();
            }

                return lista;
        }

        public bool EsVacia()
        {
            Conexion cn = new Conexion();
            string q = $@"SELECT TOP 1 * FROM dbo.Productos WHERE CategoriaID = @ID";
            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = CategoriaID;

            DataTable dt = cn.Consultar(cmd);
            
            if(dt.Rows.Count > 0) { return false; }
            else { return true; }
        }

        public Categoria Consultar(int ID)
        {
            Categoria categoria;
            using (var context = new AlmacenContext())
            {
                categoria = context.Categorias.Find(ID);
            }
            if (categoria != null)
            {
                _categoriaID = categoria.CategoriaID;
                _descripcion = categoria.Descripcion;
                _utilidad = categoria.Utilidad;
                return categoria; 
            }
            else
            {
                return null;
            }
        }
    }
}
