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
    public class Tag_ArticleMethodscs
    {
        private readonly IConfiguration _configuration;
        public Tag_ArticleMethodscs(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Tag_Article> Get()
        {
            string query = @"Select * 
                            from dbo.Tag/Article ";
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
            List<Tag_Article> List = new List<Tag_Article>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Tag_Article obj = new Tag_Article();
                obj.Id = Convert.ToInt32(table.Rows[i][0]);
                obj.TagId = Convert.ToInt32(table.Rows[i][1].ToString());
                obj.ArticleId = Convert.ToInt32(table.Rows[i][2].ToString());
                List.Add(obj);
            }
            return List;
        }

        public void Post(Tag_Article tag_Article)
        {
            string query = @"Insert into dbo.Tag/Article (TagId,ArticleId) 
                            values (@TagId,@ArticleId) ";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
                                  @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@TagId", tag_Article.TagId);
                    com.Parameters.AddWithValue("@ArticleId", tag_Article.ArticleId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
        public void Update(Article article)
        {
            string query = @"Update dbo.Tag/Article
                            set TagId=@TagId,
                            ArticleId=@ArticleId
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
                    com.Parameters.AddWithValue("@Id", article.Id);
                    com.Parameters.AddWithValue("@TagId", article.CategoryId);
                    com.Parameters.AddWithValue("@ArticleId", article.Description);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Delete(Article article)
        {
            string query = @"Delete dbo.Tag/Article
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
                    com.Parameters.AddWithValue("@Id", article.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
    }
}
