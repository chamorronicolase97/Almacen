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
    public class PedidoEstado
    {
        private int _PedidoEstadoID;
        private string _descripcion;

        #region Constantes
        const string Tabla = "dbo.PedidosEstados";
        public const string NombreClase = "PedidoEstado";
        #endregion

        #region Propiedades
        public int PedidoEstadoID { get { return _PedidoEstadoID; } set { _PedidoEstadoID = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        #endregion

        public PedidoEstado EnEdicion => new PedidoEstado(1);
        public PedidoEstado Confirmado => new PedidoEstado(2);
        public PedidoEstado Cancelado => new PedidoEstado(3);

        public PedidoEstado() { }
        public PedidoEstado(int ID)
        {
            this.PedidoEstadoID = ID;
            if (ID != 0) Consultar(ID);
        }

        public void Insertar()
        {
            using (var context = new AlmacenContext())
            {
                context.PedidosEstados.Add(this);
                context.SaveChanges();
            }
        }

        public void Modificar()
        {
            PedidoEstado PedidoEstado = new PedidoEstado();
            using (var context = new AlmacenContext())
            {
                PedidoEstado = context.PedidosEstados.Find(this.PedidoEstadoID);
                PedidoEstado.Descripcion = this.Descripcion;
                context.SaveChanges();
            }
        }

        public void Eliminar()
        {
            using (var context = new AlmacenContext())
            {
                context.PedidosEstados.Remove(this);
                context.SaveChanges();
            }
        }

        public static DataTable ListarGrilla()
        {
            Conexion cn = new Conexion();
            string q = @$"select PedidoEstadoID, Descripcion 
                            from {Tabla}";
            return cn.Consultar(q);
        }    

        public PedidoEstado Consultar(int ID)
        {
            PedidoEstado PedidoEstado;
            using (var context = new AlmacenContext())
            {
                PedidoEstado = context.PedidosEstados.Find(ID);
            }
            if (PedidoEstado != null)
            {
                _PedidoEstadoID = PedidoEstado.PedidoEstadoID;
                _descripcion = PedidoEstado.Descripcion;
                return PedidoEstado;
            }
            else
            {
                return null;
            }
        }
    }
}
