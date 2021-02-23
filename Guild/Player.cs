using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {


        public string Name { get; set; }
        public string Class { get; set; }

        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";


        public Player(string _name, string _class)
        {
            this.Name = _name;
            this.Class = _class;
        }


        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Player {this.Name}: {this.Class}");
            myStringToReturn.AppendLine($"Rank: {this.Rank}");
            myStringToReturn.AppendLine($"Description: {this.Description}");
            return myStringToReturn.ToString().TrimEnd();
        }




    }
}
