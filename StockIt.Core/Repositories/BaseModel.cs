using System;
using System.Text;

namespace StockIt.Core.Repositories
{
    public class BaseModel
    {
        public string Id { get; set; } = null;
        public bool Enabled { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
