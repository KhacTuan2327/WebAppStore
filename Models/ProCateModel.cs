using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;       

namespace Models
{
    public class ProCateModel
    {
        private StoreDbContext context = null;
        public ProCateModel()
        {
            context = new StoreDbContext();
        }

        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("sp_category_listall").ToList();
            return list;
        }
    }
}
