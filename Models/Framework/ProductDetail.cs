using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Framework
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Price { get; set; }


        public string Photo { get; set; }


        public DateTime? Updated_At { get; set; }

        public int Category_Id { get; set; }


        public string Color { get; set; }


        public string Size { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }
    }
}
