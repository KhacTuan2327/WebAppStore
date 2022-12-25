namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductGalery")]
    public partial class ProductGalery
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }

        public int Product_Id { get; set; }

        public virtual Product Product { get; set; }
    }
}
