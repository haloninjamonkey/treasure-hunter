namespace treasure_hunt.Models
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public Item(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}