using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace learninganularapi.Models
{
    public class DataAccess
    {
        private IConfiguration Configuration;
        public DataAccess(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        
        public UserMaster CreateUser(UserMaster user)
        {
            try
            {
                UserMaster userResponse = new UserMaster();
                DataTable dt = new DataTable();
                string connString = this.Configuration.GetConnectionString("DefaulConnection");
                SqlConnection connection = new SqlConnection(connString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "usrCreateUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ProfilePic", user.ProfilePic);
                cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                connection.Close();
                userResponse = ExtensionMethods.ConvertToListOf<UserMaster>(dt).FirstOrDefault();
                return userResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public List<UserMaster> GetAllUsers()
        {
            List<UserMaster> userList = new List<UserMaster>();
            DataTable dt = new DataTable();
            string connString = this.Configuration.GetConnectionString("DefaulConnection");
            SqlConnection connection = new SqlConnection(connString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "userGetAllUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connection.Close();
            userList =ExtensionMethods.ConvertToListOf<UserMaster>(dt);
            return userList;
        }
    }
}
