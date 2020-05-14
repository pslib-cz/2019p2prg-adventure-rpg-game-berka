using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public interface ILocationProvider
    {
        bool ExistsLocation(Room id);
        Location GetLocation(Room id);
        List<Connection> GetConnectionsFrom(Room id);
    }
}
