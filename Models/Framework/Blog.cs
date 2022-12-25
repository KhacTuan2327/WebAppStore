namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_At { get; set; }

        public int? Admin_Id { get; set; }

        [StringLength(2000)]
        public string Detail { get; set; }

        public virtual User User { get; set; }
    }
}
