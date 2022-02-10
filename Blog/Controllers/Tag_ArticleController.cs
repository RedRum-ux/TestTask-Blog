using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;

namespace Blog.Controllers
{
    public class Tag_ArticleController : Controller
    {
        private readonly IConfiguration _configuration;

        public Tag_ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JsonResult Get(Tag_Article tag_Article)
        {
            string query = @"Select * 
                            from dbo.Tag_Article ";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
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
            return new JsonResult(table);
        }

        public JsonResult Post(Tag_Article tag_Article)
        {
            string query = @"insert into dbo.Tag_Article (TagId,ArticleId) 
                            values (@TagId,@ArticleId)";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@ArticleId", tag_Article.ArticleId);
                    com.Parameters.AddWithValue("@TagId", tag_Article.TagId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
            return new JsonResult(table);
        }
     
        public JsonResult Update(Tag_Article tag_Article)
        {
            string query = @"Update  dbo.Tag_Article 
                            set TagId=@TagId,
                            ArticleId=@ArticleId
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Id", tag_Article.Id);
                    com.Parameters.AddWithValue("@ArticleId", tag_Article.ArticleId);
                    com.Parameters.AddWithValue("@TagId", tag_Article.TagId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
            return new JsonResult(table);
        }
        public JsonResult Delete(Tag_Article tag_Article)
        {
            string query = @"Delete  dbo.Tag_Article 
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@Id", tag_Article.Id);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
            return new JsonResult(table);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
