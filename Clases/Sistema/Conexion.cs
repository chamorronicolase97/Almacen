using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.VisualBasic.Logging;

namespace Sistema
{
    public class Conexion
    {

        string connectionString = ConfigurationManager.ConnectionStrings["NicoConnectionString"].ConnectionString;
        string connectionString2 = ConfigurationManager.ConnectionStrings["MiltonConnectionString"].ConnectionString;

        public SqlConnection conectarbd = new SqlConnection();

        public  Conexion()
        {
            try
            {
                conectarbd.ConnectionString = connectionString2;
            }
            catch {}
            try
            {
                conectarbd.ConnectionString = connectionString;
            }
            catch { }
            
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

        public void Ejecutar(SqlCommand cmd)
        {
            try
            {
                conectarbd.Open();
                cmd.Connection = conectarbd;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable Consultar (SqlCommand cmd)
        {
            try
            {
                conectarbd.Open();
                cmd.Connection = conectarbd;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                return data;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
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
