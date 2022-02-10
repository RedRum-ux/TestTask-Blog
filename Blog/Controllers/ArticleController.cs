using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Get()
        {
            string query = @"Select * 
                            from dbo.Article ";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
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

        public IActionResult Post(Article article)
        {
            string query = @"Insert into dbo.Tag_Article (CategoryId,Description,Hero_Imag,Name,Short_Description,UserId) 
                            values (@CategoryId,@Description,@Hero_Imag,@Name,@Short_Description,@UserId) ";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
            {
                Con.Open();
                using (SqlCommand com = new SqlCommand(query, Con))
                {
                    com.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                    com.Parameters.AddWithValue("@Description", article.Description);
                    com.Parameters.AddWithValue("@Hero_Imag", article.Hero_Imag);
                    com.Parameters.AddWithValue("@Name",article.Name);
                    com.Parameters.AddWithValue("@Short_Description", article.Short_Description);
                    com.Parameters.AddWithValue("@UserId", article.UserId);
                    Reader = com.ExecuteReader();
                    table.Load(Reader);
                    Reader.Close();
                    Con.Close();
                }
            }
            return new JsonResult(table);
        }
        public IActionResult Update(Article article)
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
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
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
            return new JsonResult(table);
        }

        public IActionResult Delete(Article article)
        {
            string query = @"Delete dbo.Tag_Article
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDateSourse = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader Reader;
            using (SqlConnection Con = new SqlConnection())
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
            return new JsonResult(table);
        }
        public IActionResult Index()
        {
            return View( );
        }
    }
}
