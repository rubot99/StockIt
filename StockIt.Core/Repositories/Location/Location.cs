using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.Location
{
    public class Location : BaseTenantModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
