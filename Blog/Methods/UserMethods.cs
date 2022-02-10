using Blog.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Methods
{
    public class UserMethods
    {
        private readonly IConfiguration _configuration;

        public UserMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<User> Get()
        {
            string query = @"select * 
                            from dbo.User";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                            @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
            List<User> List = new List<User>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                User obj = new User();
                obj.Id = Convert.ToInt32(table.Rows[i][0]);
                obj.Name = table.Rows[i][1].ToString();
                List.Add(obj);
            }
            return List;
        }
        public void Post(User user)
        {
            string query = @"insert into dbo.User (Name) 
                            values (@Name)";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                              @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Name", user.Name);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Update(User user)
        {
            string query = @"Update dbo.User 
                            set Name=@Name
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                              @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Name", user.Name);
                    com.Parameters.AddWithValue("@Id", user.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Delete(User user)
        {
            string query = @"Delete dbo.User 
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                              @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Id", user.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
    }
}
