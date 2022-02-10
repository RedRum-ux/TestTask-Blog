using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class Tag_Article
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ArticleId { get; set; }
    }
}
