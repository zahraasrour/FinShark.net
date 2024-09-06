using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finshark.Net.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;  
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public String Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

    }
}
