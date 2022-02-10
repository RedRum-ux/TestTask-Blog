using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using System.Data;
using System.Data.SqlClient;

namespace Blog.Methods
{
    public class ArticleMethods
    {
        public readonly IConfiguration _configuration;
        public ArticleMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Article> Get()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory));
            string query = @"Select * 
                            from dbo.Article ";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory)+
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
            List<Article> ArtList = new List<Article>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Article art = new Article();
                art.Id = Convert.ToInt32(table.Rows[i][0]);
                art.Name = table.Rows[i][1].ToString();
                art.Short_Description = table.Rows[i][2].ToString();
                art.Description = table.Rows[i][3].ToString();
                art.CategoryId = Convert.ToInt32(table.Rows[i][4].ToString());
                art.UserId = Convert.ToInt32(table.Rows[i][5]);
                art.Hero_Imag = table.Rows[i][6].ToString();
                ArtList.Add(art);
            }
            return ArtList;
        }

        public void Post(Article article)
        {
            string query = @"Insert into dbo.Tag_Article (CategoryId,Description,Hero_Imag,Name,Short_Description,UserId) 
                            values (@CategoryId,@Description,@Hero_Imag,@Name,@Short_Description,@UserId) ";
            DataTable table = new DataTable();
            string sqlDateSourse = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory) +
              @"Blog.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(sqlDateSourse))
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                    com.Parameters.AddWithValue("@Description", article.Description);
                    com.Parameters.AddWithValue("@Hero_Imag", article.Hero_Imag);
                    com.Parameters.AddWithValue("@Name", article.Name);
                    com.Parameters.AddWithValue("@Short_Description", article.Short_Description);
                    com.Parameters.AddWithValue("@UserId", article.UserId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }
        public void Update(Article article)
        {
            string query = @"Update dbo.Tag_Article
                            set CategoryId=@CategoryId,
                            Description=@Description,
                            Hero_Imag=@Hero_Imag,
                            Name=@Name,
                            Short_Description=@Short_Description,
                            UserId=@UserId
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
                    com.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                    com.Parameters.AddWithValue("@Description", article.Description);
                    com.Parameters.AddWithValue("@Hero_Imag", article.Hero_Imag);
                    com.Parameters.AddWithValue("@Name", article.Name);
                    com.Parameters.AddWithValue("@Short_Description", article.Short_Description);
                    com.Parameters.AddWithValue("@UserId", article.UserId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
        }

        public void Delete(Article article)
        {
            string query = @"Delete dbo.Tag_Article
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
