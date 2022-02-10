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
    public class CategoryMethods
    {
        private readonly IConfiguration _configuration;

        public CategoryMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Category> Get()
        {
            string query = @"select * 
                            from dbo.Category";
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
            List<Category> List = new List<Category>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Category obj = new Category();
                obj.Id = Convert.ToInt32(table.Rows[i][0]);
                obj.Name = table.Rows[i][1].ToString();
                List.Add(obj);
            }
            return List;
        }
        public void Post(Category category)
        {
            string query = @"insert into dbo.Category (Name)
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
                    com.Parameters.AddWithValue("@Name", category.Name);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Update(Category category)
        {
            string query = @"Update dbo.Category 
                            set Name=@Name
                            where Id = @Id";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                          @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Name", category.Name);
                    com.Parameters.AddWithValue("@Id", category.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
        public void Delete(Category category)
        {
            string query = @"Delete dbo.Category 
                            where Id = @Id";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                                  @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Id", category.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
    }
}
