using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {

        List<Player> roster;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }

        public Guild(string _name, int _capacity)
        {
            this.Name = _name;
            this.Capacity = _capacity;
            roster = new List<Player>(_capacity);
        }

        public void AddPlayer(Player _player)
        {
            if (this.Count < this.Capacity)
            {
                roster.Add(_player);
            }
        }


        public bool RemovePlayer(string _name)
        {
            Player player = roster
                .FirstOrDefault(p => p.Name == _name);

            if (player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }


        public void PromotePlayer(string _name)
        {
            Player player = roster
                .FirstOrDefault(p => p.Name == _name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
            else
            {
                return;
            }
           
        }

        public void DemotePlayer(string _name)
        {
            Player player = roster
                .FirstOrDefault(p => p.Name == _name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
            else
            {
                return;
            }
        }


        public Player[] KickPlayersByClass(string _class)
        {
            Player[] kickedPlayers;

            kickedPlayers = roster.Where(x => x.Class == _class).ToArray();
            roster = roster.Where(x => x.Class != _class).ToList();         //new collection without the players from this class!!!!!!!!!!
            return kickedPlayers;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
