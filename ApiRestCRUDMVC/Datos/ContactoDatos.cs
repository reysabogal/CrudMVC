using ApiRestCRUDMVC.Models;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace ApiRestCRUDMVC.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar()
        {
            var lista = new List<ContactoModel>();
            var conexion = new Conexion();

            using (var conectar = new SqlConnection(conexion.GetCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conectar); // se llama un USP de la base de datos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ContactoModel
                        {
                            idContacto = Convert.ToInt32(reader["IdContacto"]),
                            nombre = reader["Nombre"].ToString(),
                            telefono = reader["Telefono"].ToString(),
                            correo = reader["Correo"].ToString()
                        });
                    }
                }
                conectar.Close();
            }
            return lista;            
        }

        public ContactoModel Obtener(int idContacto)
        {
            var contacto = new ContactoModel();
            var conexion = new Conexion();

            using (var conectar = new SqlConnection(conexion.GetCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conectar); // se llama un USP de la base de datos
                cmd.Parameters.AddWithValue("IdContacto", idContacto); // se agrega un parámetro de inicio en el USP
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contacto.idContacto = Convert.ToInt32(reader["IdContacto"]);
                        contacto.nombre = reader["Nombre"].ToString();
                        contacto.telefono = reader["Telefono"].ToString();
                        contacto.correo = reader["Correo"].ToString();                        
                    }
                }
                conectar.Close();
            }
            return contacto;
        }
        
        public Boolean Guardar(ContactoModel ingContacto)
        {
            bool rpta;

            try
            {
                var conexion = new Conexion();

                using (var conectar = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conectar); // se llama un USP de la base de datos
                    cmd.Parameters.AddWithValue("Nombre", ingContacto.nombre); // se agrega un parámetro de inicio en el USP
                    cmd.Parameters.AddWithValue("Telefono", ingContacto.telefono);
                    cmd.Parameters.AddWithValue("Correo", ingContacto.correo);                    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    
                    conectar.Close();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        public Boolean Editar(ContactoModel ingContacto)
        {
            bool rpta;

            try
            {
                var conexion = new Conexion();

                using (var conectar = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conectar); // se llama un USP de la base de datos
                    cmd.Parameters.AddWithValue("IdContacto", ingContacto.idContacto);
                    cmd.Parameters.AddWithValue("Nombre", ingContacto.nombre); // se agrega un parámetro de inicio en el USP
                    cmd.Parameters.AddWithValue("Telefono", ingContacto.telefono);
                    cmd.Parameters.AddWithValue("Correo", ingContacto.correo);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    conectar.Close();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        public Boolean Eliminar(int idContacto)
        {
            bool rpta;

            try
            {
                var conexion = new Conexion();

                using (var conectar = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conectar); // se llama un USP de la base de datos
                    cmd.Parameters.AddWithValue("IdContacto", idContacto);                 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    conectar.Close();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}
