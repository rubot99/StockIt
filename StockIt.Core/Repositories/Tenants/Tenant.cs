namespace StockIt.Core.Repositories.Tenants
{
    public class Tenant : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
