using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Framework
{
    public class Mix
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Blog> ListBlog { get; set; }
        public Product product { get; set; }
        public Category cate { get; set; }
        public int Count { get; set; }

    }
}
