namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        public int Id { get; set; }

        public int Order_Id { get; set; }

        public int Product_Id { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? Price { get; set; }

        public int? Number { get; set; }

        public int? TotalMoney { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
