using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Shared.Models
{
    public class Security
    {
        public int Id { get; set; }
        public string SecurityName { get; set; } = string.Empty;
        public float Price { get; set; }
        public int StockesOwned { get; set; } = 0;
        public float StocksValue { get; set; }
        public DateTime DateTimeObtained { get; set; } = DateTime.UtcNow; //  apply an option for user to change it if he wants
        public string Description { get; set; } = string.Empty;
    }
}
