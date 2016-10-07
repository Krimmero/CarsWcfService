using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarsWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private string connectionString =
            @"Server=tcp:studentdatabase.database.windows.net,1433;Initial Catalog=Student;Persist Security Info=False;User ID=krimmero;Password=Leisted6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Car getCar(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            Car car = new Car();
            car.Id = Convert.ToInt32(reader["Id"]).ToString());
            car.Brand = reader["brand"].ToString();
            car.Color = (Colors) Enum.Parse(typeof (Colors), reader["color"].ToString(), true);
        }
       // return car
       
         
        public Car addCar(Car car)
        {
            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "INSERT INTO cars(Model, Brand, Color, Engine)OUTPUT Inserted.Id VALUES (@Model, @Brand, @Color, @Engine)";
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Brand", car.Brand);
                    cmd.Parameters.AddWithValue("@Color", car.Color);
                    cmd.Parameters.AddWithValue("@Engine", car.Engine);
                    cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();
                    car.Id = (Int32) cmd.ExecuteScalar();

                }
                return car;
            
        }

        public List<Car> GetCars()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT Id, Model, Brand, Color, Engine FROM cars";
                SqlCommand cmd = new SqlCommand(sql, connection);
                
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                List<Car> listOfCars = new List<Car>();

                

                
            }
            return listOfCars;
        }
    }
}
    
