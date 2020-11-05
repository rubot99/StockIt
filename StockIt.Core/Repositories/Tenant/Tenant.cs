using StockIt.Core.Repositories;

namespace StockIt.Core.Repositories.Tenant
{
    public class Tenant : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
