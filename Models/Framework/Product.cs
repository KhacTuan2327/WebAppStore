namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Product")]
    public partial class Product
    {
        StoreDbContext db = new StoreDbContext();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Detail = new HashSet<Order_Detail>();
            ProductGaleries = new HashSet<ProductGalery>();
        }
        public List<string> ListTitle(string key)
        {
            return db.Products.Where(x => x.Title.Contains(key)).Select(x => x.Title).ToList();
        }
        public List<Product> SearchByKey(string key)
        {
            var result = from Product in db.Products select Product;
            if (!String.IsNullOrEmpty(key))
            {
                key = key.ToLower();
                result = result.Where(x => x.Title.ToLower().Contains(key));
            }
            return result.ToList();
        }
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? Price { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Updated_At { get; set; }

        public int Category_Id { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductGalery> ProductGaleries { get; set; }
    }
}
