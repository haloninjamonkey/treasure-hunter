using System;

namespace treasure_hunt.Models
{
    class Game
    {
        public Player ActivePlayer { get; set; }
        public Room CurrentRoom { get; set; }
        public void GameSetup()
        {
            Room entry = new Room("Temple Entrance", "A large room with 2 doors leading futher into the temple", false);
            Room secondRoom = new Room("Ante Chamber", "A dark room with a narrow walkway that splits and leads to two more doors", true);
            Room backWall = new Room(null, null, false);
            Room thirdRoom = new Room("Treasure Room", "A room with a high ceiling, and several pillars which form an aisle, leading to a set of stairs, upon which rests a dias with a treasure chest.", true);
            Room outside = new Room("Outdoors", "Well, you're now outside of the temple, there's probably treasure in there, so...", true);
            Item grail = new Item("The Holy Grail");
            thirdRoom.Inventory.Add(grail);
            outside.Exits.Add(entry);
            entry.Exits.Add(secondRoom);
            entry.Exits.Add(outside);
            secondRoom.Exits.Add(thirdRoom);
            secondRoom.Exits.Add(entry);
            thirdRoom.Exits.Add(backWall);
            thirdRoom.Exits.Add(secondRoom);
            CurrentRoom = outside;
            System.Console.Write("Hello adventurer! What is your name? ");
            string userIput = Console.ReadLine();
            ActivePlayer = new Player(userIput);
            StartGame();
        }

        public void StartGame()
        {
            System.Console.Write($"\nWelcome to the Treasure Hunt, {ActivePlayer.Name}.\n(type help for list of controls)\nYou are now in the {CurrentRoom.Name}. The Temple is to the (N)orth of you.\n");
            Navigation();
            //     string playerChoice = Console.ReadLine().ToLower();
            //     switch (playerChoice)
            //     {
            //         case "go north":
            //             Console.Clear();
            //             System.Console.WriteLine("You walk North...");
            //             try
            //             {
            //                 CurrentRoom = CurrentRoom.Exits[0];
            //                 System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
            //             }
            //             catch
            //             {
            //                 System.Console.WriteLine("There is no exit that direction.");
            //             }
            //             break;
            //         case "go south":
            //             Console.Clear();
            //             try
            //             {
            //                 CurrentRoom = CurrentRoom.Exits[1];
            //                 System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
            //             }
            //             catch
            //             {
            //                 System.Console.WriteLine("There is no exit in that direction");
            //             }
            //             break;
            //         case "go east":
            //             Console.Clear();
            //             System.Console.WriteLine("You walk East...");
            //             try
            //             {
            //                 CurrentRoom = CurrentRoom.Exits[2];
            //             }
            //             catch
            //             {
            //                 System.Console.WriteLine("There is no exit that direction");
            //             }
            //             break;
            //         case "go west":
            //             Console.Clear();
            //             System.Console.WriteLine("You walk West...");
            //             try
            //             {
            //                 CurrentRoom = CurrentRoom.Exits[3];
            //                 System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
            //             }
            //             catch
            //             {
            //                 System.Console.WriteLine("There is no exit in that direction");
            //             }
            //             break;
            //         case "look":
            //             System.Console.WriteLine(CurrentRoom.Description);
            //             break;
            //         case "help":
            //             Menu();
            //             break;
            //         case "quit":
            //             Quit();
            //             break;
            //         default:
            //             System.Console.WriteLine("Please make a valid choice ('help' for options)");
            //             StartGame();
            //             break;
            //     }
        }
        public void Navigation()
        {
            string playerChoice = Console.ReadLine().ToLower();
            switch (playerChoice)
            {
                case "go north":
                    Console.Clear();
                    System.Console.WriteLine("You walk North...");
                    try
                    {
                        CurrentRoom = CurrentRoom.Exits[0];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do now? ");
                        Navigation();
                    }
                    catch
                    {
                        System.Console.WriteLine("There is no exit that direction.");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    break;
                case "go south":
                    Console.Clear();
                    try
                    {
                        CurrentRoom = CurrentRoom.Exits[1];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    catch
                    {
                        System.Console.WriteLine("There is no exit in that direction");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    break;
                case "go east":
                    Console.Clear();
                    System.Console.WriteLine("You walk East...");
                    try
                    {
                        CurrentRoom = CurrentRoom.Exits[2];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    catch
                    {
                        System.Console.WriteLine("There is no exit that direction");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    break;
                case "go west":
                    Console.Clear();
                    System.Console.WriteLine("You walk West...");
                    try
                    {
                        CurrentRoom = CurrentRoom.Exits[3];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    catch
                    {
                        System.Console.WriteLine("There is no exit in that direction");
                        System.Console.Write("What would you like to do? ");
                        Navigation();
                    }
                    break;
                case "look":
                    System.Console.WriteLine(CurrentRoom.Description);
                    System.Console.Write("What would you like to do? " );
                    Navigation();
                    break;
                case "take":
                    if(CurrentRoom.Inventory.Count != 0)
                    {
                        System.Console.WriteLine($"You found {CurrentRoom.Inventory[0].Name}!");
                        ActivePlayer.Inventory.Add(CurrentRoom.Inventory[0]);
                        CurrentRoom.Inventory.Remove(CurrentRoom.Inventory[0]);
                        Win();
                        break;
                    } else {
                        System.Console.WriteLine("There's nothing here but cobwebs.");
                        System.Console.Write("What would you like to do? " );
                        Navigation();
                    }
                    break;
                case "help":
                    Menu();
                    break;
                case "quit":
                    Quit();
                    break;
                default:
                    System.Console.WriteLine("Please make a valid choice ('help' for options)");
                    System.Console.Write("What would you like to do? ");
                    Navigation();
                    break;
            }
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
            else
            {
                System.Console.WriteLine($"\nYou have chosen to end the treasure hunt. Farewell, {ActivePlayer.Name}");
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
            else
            {
                Quit();
            }

        }

        public void Menu()
        {
            System.Console.WriteLine("\n********************************\nControls:\nGo <direction>: proceed to the next room in the chosen direction (North, South, East, West)\nLook: Get a description of the current room.\nTake <ItemName>: Pick up item (when available)\nHelp: Displays this list\nQuit: Leave the game.\n********************************\n");
            System.Console.Write("What would you like to do? ");
            Navigation();
        }

        public void Quit()
        {
            System.Console.WriteLine($"\nYou have chosen to end the treasure hunt. Farewell, {ActivePlayer.Name}");
        }
    }
}