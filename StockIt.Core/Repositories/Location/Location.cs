using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.Location
{
    public class Location : BaseTenantModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
