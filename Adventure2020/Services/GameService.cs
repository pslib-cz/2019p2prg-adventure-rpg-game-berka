using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class GameService
    {
        private readonly ISessionStorage<GameState> _ss;
        private readonly ILocationProvider _lp;
        private const string KEY = "AMAZINGADVENTURE";
        private const Room START_ROOM = Room.Start;
        public GameState State { get; private set; }
        public Location Location { get { return _lp.GetLocation(State.Location); } }
        public List<Connection> Targets { get { return _lp.GetConnectionsFrom(State.Location); } }

        public GameService(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
            State = new GameState();
        }

        public void Start()
        {
            State = new GameState { MaxHP = 20, Location = START_ROOM, HP = 20, Level = 1 };
            Store();
        }

        public void FetchData()
        {
            State = _ss.LoadOrCreate(KEY);
        }

        public void Store()
        {
            _ss.Save(KEY, State);
        }
        public void EnteringNewRoom(Room room)
        {
            if(State.HP <= 0)
            {
                State.Location = Room.GameOver;
            }
            if(room == Room.SecretRoom)
            {
                if(State.Level < 15)
                {
                    State.Location = Room.GameOver;
                }
                else
                {
                    State.Location = Room.Win;
                }
            }
            if(room == Room.Tavern)
            {
                State.HP = State.MaxHP;
                State.Money -= 5;
            }
            if(room == Room.Work)
            {
                State.Money += 10;
                State.Level += 0.1;
            }
            if(room == Room.Dungeon)
            {
                State.HP -= 5;
                State.Level += 0.2;
            }
            if(room == Room.Library)
            {
                State.Level += 0.5;
            }
            if(State.Level % 1 == 0)
            {
                State.MaxHP = 20 + Convert.ToInt32(State.Level) * 2; 
            }
            Store();
        }
    }
}
