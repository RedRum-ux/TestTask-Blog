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
    public class TagMethods
    {
        private readonly IConfiguration _configuration;

        public TagMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Tag> Get()
        {
            string query = @"select * 
                            from dbo.Tag";
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
            List<Tag> tagList = new List<Tag>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Tag tag = new Tag();
                tag.Id = Convert.ToInt32(table.Rows[i][0]);
                tag.Name = table.Rows[i][1].ToString();
                tagList.Add(tag);
            }
            return tagList;

        }
        public void Post(Tag tag)
        {
            string query = @"insert into dbo.Tag (Name) 
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
                    com.Parameters.AddWithValue("@Name", tag.Name);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Update(Tag tag)
        {
            string query = @"Update dbo.Tag 
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
                    com.Parameters.AddWithValue("@Name", tag.Name);
                    com.Parameters.AddWithValue("@Id", tag.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Delete(Tag tag)
        {
            string query = @"Delete dbo.Tag 
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
                    com.Parameters.AddWithValue("@Id", tag.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
           
        }
    }
}
