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
        public DateTime DateTimeObtained { get; set; } = DateTime.Now; //  apply an option for user to change it if he wants
        public string Description { get; set; } = string.Empty;
    }
}
