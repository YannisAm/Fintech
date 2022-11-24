using System.ComponentModel.DataAnnotations;

namespace Fintech.Shared.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        //public int PortfolioId { get; set; }
        [Required]
        public string NameOfPortfolio { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Security>? Securities { get; set; }
    }
}
