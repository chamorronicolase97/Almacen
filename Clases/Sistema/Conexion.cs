using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistema
{
    public class Conexion
    {
        string cadena = "Data Source=HWNOTE163490\\SQLEXPRESS;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public SqlConnection conectarbd = new SqlConnection();

        public  Conexion()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void Abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Conectar con la BD",ex);  
            }
        }

        public DataTable Consultar(string consulta)
        {
            try 
            {
                SqlCommand cmd = new SqlCommand(consulta, conectarbd);
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                
                return data;

            }
            catch (Exception ex) {throw new Exception(ex.Message); } 
        }

        public void Cerrar()
        {
            conectarbd.Close();
            Console.WriteLine("Conexion Cerrada");
        }
    }
}
