namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Update_At { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
