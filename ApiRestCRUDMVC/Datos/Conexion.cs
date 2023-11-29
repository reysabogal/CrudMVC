using System.Data.SqlClient;

namespace ApiRestCRUDMVC.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:AppConnection").Value;
        }

        public string GetCadenaSQL()
        {
            return cadenaSql;
        }


    }
}
