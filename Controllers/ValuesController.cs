using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using WebApplication2.Models;
using ZooWeb.Models;

namespace WebApplication2.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //[HttpGet("/GetAllUsers")]
        //public async Task<List<Users>> GetAllUsers()
        //{
        //    try
        //    {
        //        List<Users> users = new List<Users>();
        //        string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
        //        string query = "select * from USERS";
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            sqlConnection.Open();
        //            SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //            SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
        //            if (sqlDataReader.HasRows)
        //            {
        //                while (sqlDataReader.Read())
        //                    {
        //                    Users user = new Users();
        //                    user.Id = sqlDataReader.GetInt32(0);
        //                    user.Login = sqlDataReader.GetString(1);
        //                    user.Password = sqlDataReader.GetString(2);
        //                    users.Add(user);
        //                }
        //            }
        //        }
        //        return users;
        //    }
        //    catch (Exception ex) { return null; }
        //}


        [HttpGet("/CreateUser")]
        public async Task<bool> CreateUser(string login, string password)
        {
            try
            {
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "INSERT INTO USERS VALUES ('" + login + "','" + password + "')";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    await cmd.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //[HttpGet("/GetData")]
        //public async Task<string> GetData() 
        //{
        //    try
        //    {
        //        return "Hellooo";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        [HttpGet("/Login")]
        public async Task<bool> Login(string login, string password)
        {
            try
            {
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = $"Select login, password from users where login like '{login}' and password like '{password}'";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    var user = cmd.ExecuteScalar();
                    if (user!= null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //[HttpGet("/GetAllUsers")]
        //public async Task<List<Users>> GetAllUsers()
        //{
        //    try
        //    {
        //        List<Users> users = new List<Users>();
        //        string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
        //        string query = "select * from USERS";
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            sqlConnection.Open();
        //            SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //            SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
        //            if (sqlDataReader.HasRows)
        //            {
        //                while (sqlDataReader.Read())
        //                {
        //                    Users user = new Users();
        //                    user.Id = sqlDataReader.GetInt32(0);
        //                    user.Login = sqlDataReader.GetString(1);
        //                    user.Password = sqlDataReader.GetString(2);
        //                    users.Add(user);
        //                }
        //            }
        //        }
        //        return users;
        //    }
        //    catch (Exception ex) { return null; }
        //}


        [HttpGet("/GetAllUsers")]
        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                List<Users> users = new List<Users>();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "select * from USERS";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Users user = new Users();
                            user.id = sqlDataReader.GetInt32(0);
                            user.name = sqlDataReader.GetString(1);
                            user.phone = sqlDataReader.GetString(2);
                            user.roleId = sqlDataReader.GetInt32(3);
                            
                            users.Add(user);
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("/GetAllorders")]
        public async Task<List<orders>> GetAllorders()
        {
            try
            {
                List<orders> orders = new List<orders>();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "select * from orders";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            orders user = new orders();
                            user.id = sqlDataReader.GetInt32(0);
                            user.pokupatelId = sqlDataReader.GetInt32(1);
                            user.tovarId = sqlDataReader.GetInt32(2);
                            user.prodavetsId = sqlDataReader.GetInt32(3);

                            orders.Add(user);
                        }
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("/GetAllRoles")]
        public async Task<List<Roles>> GetAllRoles()
        {
            try
            {
                List<Roles> Roles = new List<Roles>();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "select * from Roles";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Roles user = new Roles();
                            user.id = sqlDataReader.GetInt32(0);
                            user.name = sqlDataReader.GetString(1);

                            Roles.Add(user);
                        }
                    }
                }
                return Roles;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("/GetAllWares")]
        public async Task<List<Wares>> GetAllWares()
        {
            try
            {
                List<Wares> Wares = new List<Wares>();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "select * from Wares";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Wares Ware = new Wares();
                            Ware.id = sqlDataReader.GetInt32(0);
                            Ware.name = sqlDataReader.GetString(1);

                            Wares.Add(Ware);
                        }
                    }
                }
                return Wares;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet("/GetAllSalesman")]
        public async Task<List<Salesman>> GetAllSalesman()
        {
            try
            {
                List<Salesman> Salesman = new List<Salesman>();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = "select * from Salesman";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Salesman Saler = new Salesman();
                            Saler.id = sqlDataReader.GetInt32(0);
                            Saler.name = sqlDataReader.GetString(1);
                            Saler.role = sqlDataReader.GetString(2);
                            Salesman.Add(Saler);
                        }
                    }
                }
                return Salesman;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet("/GetUsersByPhoneNumber")]
        public async Task<string> GetUsersByPhoneNumber(string phone)
        {
            try
            {
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = $"select name from USERS where phone like {phone}";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    var user = cmd.ExecuteScalar().ToString();
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("/GetProductById")]
        public async Task<Wares> GetProductById(int id)
        {
            try
            {
                Wares Ware = new Wares();
                string connectionString = @"Data Source=207-4; Initial Catalog=newZoo;Integrated Security=True;TrustServerCertificate=Yes";
                string query = $"select * from Wares where id = {id}";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.Read())
                    {
                        Ware.id = sqlDataReader.GetInt32(0);
                        Ware.name = sqlDataReader.GetString(1);
                        Ware.imgUrl = sqlDataReader.GetString(3);
                    }
                }
                return Ware;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
