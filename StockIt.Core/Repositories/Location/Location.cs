using System.Collections.Generic;

namespace StockIt.Core.Repositories.Location
{
    public class Location : BaseTenantModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
