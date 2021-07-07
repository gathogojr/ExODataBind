using System.ComponentModel.DataAnnotations.Schema;

namespace ExODataBind.Models
{
    public class Order
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
    }
}
