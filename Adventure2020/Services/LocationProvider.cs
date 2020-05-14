using Adventure2020.Models;
using Adventure2020.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<Room, ILocation> _locations;
        private List<Connection> _map;

        public LocationProvider()
        {
            _locations = new Dictionary<Room, ILocation>();
            _map = new List<Connection>();
            _locations.Add(Room.Start, new Location { Title = "Start", Description = "This is where our story starts." }); // Game starts
            _locations.Add(Room.GameOver, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did." }); // Game Over
            _locations.Add(Room.CityCenter, new Location { Title = "Hall", Description = "You stand in the center of this wide city.\nThere are no people anywhere." });
            _locations.Add(Room.Library, new Location { Title = "Library", Description = "The Library is almost destroyed but there are still some books." });
            _locations.Add(Room.Dungeon, new Location { Title = "Dungeon", Description = "You go through the dungoen and fight some monsters.\nYou should head to the taven." });
            _locations.Add(Room.SecretRoom, new Location { Title = "Secret Room", Description = "The Cthulu is ominously looking at you so you fight it.\n" });
            _locations.Add(Room.Win, new Location { Title = "End of the adventure", Description = "The city dissaperas as you defeat the Cthulu.\nYou won and this is the end of you adventure." });
            _locations.Add(Room.Tavern, new Location { Title = "Tavern", Description = "You eat some delicious food and go to sleep.\nYour HP is replenished" });
            _locations.Add(Room.Work, new Location { Title = "You go to work to earn some money.\nYou earn 10 gold." });
            _map.Add(new Connection(Room.Start, Room.CityCenter, "Go to Center"));
            _map.Add(new Connection(Room.CityCenter, Room.Library, "Visit Library" ));
            _map.Add(new Connection(Room.Library, Room.SecretRoom, "Enter the hidden room"));
            _map.Add(new Connection(Room.CityCenter, Room.Work, "Go to work"));
            _map.Add(new Connection(Room.CityCenter, Room.Dungeon, "Go to the dungeon(!!!!)"));
            _map.Add(new Connection(Room.CityCenter, Room.Tavern, "Go to the tavern" , (gs) => { if (gs.Money < 5) return false; else return true; }));
            _map.Add(new Connection(Room.Dungeon, Room.CityCenter, "Go back to the city center"));
            _map.Add(new Connection(Room.Library, Room.CityCenter, "Go back to the city center"));
            _map.Add(new Connection(Room.Work, Room.CityCenter, "Go back to the city center"));
            _map.Add(new Connection(Room.Tavern, Room.CityCenter, "Go back to the city center"));
        }

        public bool ExistsLocation(Room id)
        {
            return _locations.ContainsKey(id);
        }

        public List<Connection> GetConnectionsFrom(Room id)
        {
            if (ExistsLocation(id))
            {
                return _map.Where(m => m.From == id).ToList();
            }
            throw new InvalidLocation();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(Room id)
        {
            if (ExistsLocation(id))
            {
                return (Location)_locations[id];
            }
            throw new InvalidLocation();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
