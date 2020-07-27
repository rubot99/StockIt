using System;
using System.Text;

namespace StockIt.Core.Models
{
    public class BaseModel
    {
        public string Id { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public string Tenant { get; set; }
    }
}
