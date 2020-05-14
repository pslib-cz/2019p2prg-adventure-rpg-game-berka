using Adventure2020.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Connection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="from">Id of location we want to leave.</param>
        /// <param name="to">Id of location we want to enter.</param>
        /// <param name="description">Room description.</param>
        public Connection(Room from, Room to, string description)
        {
            From = from;
            To = to;
            Description = description;
        }

        public Room From { get; set; }
        public Room To { get; set; }
        public string Description { get; set; }
    }
}
