using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConsultasMVC.Models.Dto;

using System.Windows.Forms;

namespace ConsultasMVC.Models.Dao
{
    class ClienteDao : DbContext
    {
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();
        //Consulta de articulos completa o con filtro
        public List<Producto> VerRegistros(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "VerRegistros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            //DTO

            List<Producto> ListaGenerica = new List<Producto>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Producto
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Descripcion = LeerFilas.GetString(2),
                    Precio = LeerFilas.GetValue(3).ToString(),
                }) ;
                
            }
            LeerFilas.Close();
            Conexion.Close();

            return ListaGenerica;
        }
        //Agregar articulo nuevo
        public void Insert(string nombre,string descripcion, double precio) 
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value=nombre;
            Comando.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = descripcion;
            Comando.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = precio;
            Conexion.Open();
            int c = Comando.ExecuteNonQuery();
            Conexion.Close();
            //MessageBox.Show("insertado: "+c.ToString());
        }
        //Actualizacion de producto
        public void Update(int id,string nombre, string descripcion, double precio)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ActualizarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ProductID", SqlDbType.Int).Value = id;
            Comando.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = nombre;
            Comando.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = descripcion;
            Comando.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = precio;
            Conexion.Open();
            int c = Comando.ExecuteNonQuery();
            Conexion.Close();
            //MessageBox.Show("insertado: "+c.ToString());
        }
        //Borrado permanente de producto
        public void Delete(int id)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "EliminarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@ProductID", SqlDbType.VarChar, 50).Value = id;
            Conexion.Open();
            int c = Comando.ExecuteNonQuery();
            Conexion.Close();
            //MessageBox.Show("insertado: "+c.ToString());
        }
    }
}
