using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail : EntityBase
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}
