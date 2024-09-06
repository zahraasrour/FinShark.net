using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Finshark.Net.Models
{
    public class Stock
    {

        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        //when we input a decimal amount we should check if its monitory amount
        //2 decmial places and 18 digits only 
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public String Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
