 using System.ComponentModel.DataAnnotations;

namespace Fintech.Shared.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameOfPortfolio { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
        public string UserEmail { get; set; } = string.Empty;
    }
}
