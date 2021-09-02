using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyPetStoreExistingDB.Entities
{
    [Index(nameof(CustomerId), Name = "IX_Orders_CustomerID")]
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFilfilled { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [InverseProperty(nameof(ProductOrder.Order))]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
