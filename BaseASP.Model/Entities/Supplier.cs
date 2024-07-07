using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Suppliers")]
    public class Supplier : EntityBase
    {
        public string? SupplierName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
