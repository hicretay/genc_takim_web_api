using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GencTakimAPI.Models
{
    public class games
    {
        public int UserId { get; set; } 
        public bool IsPassed { get; set; }  
    }

    public class deleteUserGame
    {
        public int Id { get; set; }
    }

    public class comingGames
    {
        public bool IsPassed { get; set; }
    }

    public class addGame
    {
        
        public int SportId { get; set; }
        public int UserId { get; set; }
        public int SaloonId { get; set; }
        public String GameNote { get; set; }
        public bool GamePassed { get; set; }
        public DateTime GameTime { get; set; }     
        public int GamePlayerCount { get; set; }
        public int GameSubstituteCount { get; set; }    

    }

    public class addUserGame
    {

        public int GameId { get; set; }
        public int UserId { get; set; }
        public int UserLocation { get; set; }
        public bool IsSubstitute { get; set; }

    }
}
