using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fintech.Shared.Models
{
    public class Security
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SecurityName { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public int StockesOwned { get; set; } = 0;
        [Required]
        public double StocksValue { get; set; }
        public DateTime DateTimeObtained { get; set; } = DateTime.UtcNow; //  apply an option for user to change it if he wants
        public string? Description { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        [ForeignKey("Portfolio")]
        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
