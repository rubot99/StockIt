﻿using System.Collections.Generic;

namespace StockIt.Core.Repositories.Location
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location Get(string id, string tenant);
        List<Location> GetAll(string tenant);
        List<Location> SearchByName(string name);
    }
}
