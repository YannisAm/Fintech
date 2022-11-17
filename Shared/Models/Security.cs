using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Shared.Models
{
    public class Security
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SecurityName { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        [Required]
        public int StockesOwned { get; set; } = 0;
        [Required]
        public float StocksValue { get; set; }
        public DateTime DateTimeObtained { get; set; } = DateTime.UtcNow; //  apply an option for user to change it if he wants
        public string? Description { get; set; } = string.Empty;

        
        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
