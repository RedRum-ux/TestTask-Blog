using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Short_Description { get; set; }
        public string Description { get; set; }
        public string Hero_Imag { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
       
    }
}
