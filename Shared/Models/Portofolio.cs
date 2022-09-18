using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Shared.Models
{
    public class Portofolio
    {
        public int Id { get; set; }
        public string NameOfSecurity { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateTimeObtained { get; set; }
    }
}
