using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyPetStoreExistingDB.Entities
{
    [Index(nameof(OrderId), Name = "IX_ProductOrders_OrderID")]
    [Index(nameof(ProductId), Name = "IX_ProductOrders_ProductID")]
    public partial class ProductOrder
    {
        [Key]
        [Column("ProductOrderID")]
        public int ProductOrderId { get; set; }
        public int Quantity { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("ProductOrders")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductOrders")]
        public virtual Product Product { get; set; }
    }
}
