using System.Collections.Generic;

namespace treasure_hunt.Models
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }
    class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        public Player(string name)
        {
            Name = name;
        }
    }

}