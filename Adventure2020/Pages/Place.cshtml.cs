using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure2020.Models;
using Adventure2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adventure2020
{
    public class PlaceModel : PageModel
    {
        private GameService _gs;

        public PlaceModel(GameService gs)
        {
            _gs = gs;
        }

        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }
        public GameState State { get; private set; }

        public void OnGet(Room id)
        {
            _gs.FetchData();//načtení dat
            _gs.State.Location = id; // načtení lokace (přepis lokace ve Statu v sessionu)
            _gs.EnteringNewRoom(id); //např. Work (Money += 10)
            _gs.Store();
            //načtení dat z gameservice, ukazují se v HTML
            Location = _gs.Location;
            Targets = _gs.Targets;
            State = _gs.State;
        }
    }
}