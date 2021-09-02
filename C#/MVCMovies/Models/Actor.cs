using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovies.Models {
    public class Actor {

        public int ActorID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int OscarsWon { get; set; }

    }
}
