using System;

namespace treasure_hunt.Models
{
    class Game
    {
        public Player Explorer { get; set; }
        public Room CurrentRoom { get; set; }
        public void GameSetup()
        {
            Room entry = new Room("Temple Entrance", "A large room with 2 doors leading futher into the temple", false);
            Room secondRoom = new Room("Ante Chamber", "A dark room with a narrow walkway that splits and leads to two more doors", true);
            Room thirdRoom = new Room("Treasure Room", "A room with a high ceiling, and several pillars which form an aisle, leading to a set of stairs, upon which rests a dias with a treasure chest.", true);
            Room outside = new Room("Outdoors", "Well, you're now outside of the temple, so...", true);
            //comment

            outside.Exits.Add(entry);
            CurrentRoom = outside;
            StartGame();
            Lose();
        }

        public void StartGame()
        {
            System.Console.Write("Hello adventurer! What is your name? ");
            string userIput = Console.ReadLine();
            Explorer = new Player(userIput);
            System.Console.WriteLine($"Welcome to the Treasure Hunt, {Explorer.Name}.\nYou are now in the {CurrentRoom.Name}. The Temple is to the (N)orth of you.\nWhich direction would you like to (Go)?");
        }

        private void Win()
        {
            System.Console.WriteLine("You found the treasure! It belongs in a museum.");
            System.Console.Write("Play again? (Y/n) ");
            string again = Console.ReadLine().ToLower();
            if (again == "y")
            {
                GameSetup();
            }
            else {
                System.Console.WriteLine($"Farewell, {Explorer.Name}");
            }
        }
        private void Lose()
        {
            System.Console.WriteLine("You did not find the treasure.");
            System.Console.Write("Play again? (Y/n) ");
            string again = Console.ReadLine().ToLower();
            if (again == "y")
            {
                GameSetup();
            }
            else {
                System.Console.WriteLine($"Farewell, {Explorer.Name}");
            }

        }
    }
}