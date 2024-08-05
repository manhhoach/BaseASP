using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Orders")]
    public class Order : EntityBase
    {
        public long UserId { get; set; }

    }
}
