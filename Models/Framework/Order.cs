namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        public int Id { get; set; }

        public int? User_Id { get; set; }

        [StringLength(100)]
        public string Fullname { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        public double? Phonenumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? TotalMoney { get; set; }

        public int? Status { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_At { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updated_At { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        public virtual User User { get; set; }
    }
}
