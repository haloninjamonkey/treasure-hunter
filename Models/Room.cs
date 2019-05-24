using System.Collections.Generic;

namespace treasure_hunt.Models
{
    class Room
    {
        public readonly string Name;
        public string Description { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<Room> Exits { get; set; } = new List<Room>();
        public bool IsLosable { get; set; }

        public Room(string name, string description, bool losable)
        {
            Name = name;
            Description = description;
            IsLosable = losable;
        }
    }
}