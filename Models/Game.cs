using System;

namespace treasure_hunt.Models
{
    class Game
    {
        public Player ActivePlayer { get; set; }
        public Room CurrentRoom { get; set; }
        public void GameSetup()
        {
            #region All the data
            //TODO: Make 4 exits for every room. Danger room is room name (secondRoom.Exit[0] = secondRoom), to allow rooms to be moved.
            Room entry = new Room("Temple Entrance", "A large room with 3 doors leading futher into the temple", true);
            Room secondRoom = new Room("Ante Chamber", "A dark room with a narrow walkway that splits and leads to two more doors", true);
            Room caveInRoom = new Room("Caved in room", "You are facing a wall of rubble and can proceed no further", true);
            Room greatHall = new Room("Great Hall", "A large room that does not appear to have any exits other than the one that you came in through.", true);

            Room treasureRoom1 = new Room("Treasure Room", "A room with a high ceiling, and several pillars which form an aisle, leading to a treasure chest. There are also two exits from this room.", true);
            Room treasureRoom2 = new Room("The Second Treasure Room", "A room containing a treasure chest.", true);
            Room treasureRoom3 = new Room("The Third Treasure Room", "Not real room yet", true);

            Room outside = new Room("Outdoors", "Well, you're now outside of the temple, there's probably treasure in there, so...", false);
            Room treasureDias = new Room("Treasure Dias", "Before you, you see a room containing a large treasure chest", false);

            Item grail = new Item("The Holy Grail", 1);
            Item sword = new Item("Excalibur", 2);
            Item iG = new Item("The Infinity Gauntlet", 5);
            Item coin = new Item("A shiny quarter... that's weird", 0);

            treasureDias.Inventory.Add(grail);
            treasureDias.Inventory.Add(sword);
            treasureDias.Inventory.Add(iG);
            treasureDias.Inventory.Add(coin);

            treasureRoom1.Inventory.Add(coin);
            treasureRoom1.Inventory.Add(coin);
            treasureRoom1.Inventory.Add(coin);
            treasureRoom1.Inventory.Add(coin);

            treasureRoom2.Inventory.Add(coin);
            treasureRoom2.Inventory.Add(coin);
            treasureRoom2.Inventory.Add(sword);
            treasureRoom2.Inventory.Add(coin);

            treasureRoom3.Inventory.Add(coin);
            treasureRoom3.Inventory.Add(iG);
            treasureRoom3.Inventory.Add(coin);
            treasureRoom3.Inventory.Add(sword);


            outside.Exits[0] = entry;
            outside.Exits[1] = outside;
            outside.Exits[2] = outside;
            outside.Exits[3] = outside;

            entry.Exits[0] = entry;
            entry.Exits[1] = outside;
            entry.Exits[2] = secondRoom;
            entry.Exits[3] = greatHall;

            greatHall.Exits[0] = greatHall;
            greatHall.Exits[1] = greatHall;
            greatHall.Exits[2] = entry;
            greatHall.Exits[3] = greatHall;



            secondRoom.Exits[0] = treasureRoom1;
            secondRoom.Exits[1] = caveInRoom;
            secondRoom.Exits[2] = secondRoom;
            secondRoom.Exits[3] = entry;

            treasureRoom1.Exits[0] = treasureRoom1;
            treasureRoom1.Exits[1] = secondRoom;
            treasureRoom1.Exits[2] = treasureRoom2;
            treasureRoom1.Exits[3] = treasureRoom3;

            treasureRoom2.Exits[0] = treasureRoom2;
            treasureRoom2.Exits[1] = treasureRoom2;
            treasureRoom2.Exits[2] = treasureRoom2;
            treasureRoom2.Exits[3] = treasureRoom1;

            treasureRoom3.Exits[0] = treasureDias;
            treasureRoom3.Exits[1] = treasureRoom3;
            treasureRoom3.Exits[2] = treasureRoom1;
            treasureRoom3.Exits[3] = treasureRoom3;

            treasureDias.Exits[0] = treasureDias;
            treasureDias.Exits[1] = treasureRoom3;
            treasureDias.Exits[2] = treasureDias;
            treasureDias.Exits[3] = treasureDias;
            #endregion

            CurrentRoom = outside;
            System.Console.Write("Hello adventurer! What is your name? ");
            string userIput = Console.ReadLine();
            ActivePlayer = new Player(userIput);
            ActivePlayer.Encumberance = 0;

            StartGame();
        }

        public void StartGame()
        {
            System.Console.Write($"\nWelcome to the Treasure Hunt, {ActivePlayer.Name}.\n(type help for list of controls)\nYou are now in the {CurrentRoom.Name}. The Temple is to the North of you.\n");
            Navigation();
        }

        public void Navigation()
        {
            string playerChoice = Console.ReadLine().ToLower();
            switch (playerChoice)
            {
                case "go north":
                    Console.Clear();
                    System.Console.WriteLine("You walk North...");
                    if (CurrentRoom.Exits[0] != CurrentRoom)
                    {
                        CurrentRoom = CurrentRoom.Exits[0];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do now? ");
                        Navigation();
                        break;
                    }
                    Danger();
                    break;
                case "go south":
                    Console.Clear();
                    System.Console.WriteLine("You walke South... ");
                    if (CurrentRoom.Exits[1] != CurrentRoom)
                    {
                        CurrentRoom = CurrentRoom.Exits[1];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do now? ");
                        Navigation();
                        break;
                    }
                    Danger();
                    break;
                case "go east":
                    Console.Clear();
                    System.Console.WriteLine("You walk East...");
                    if (CurrentRoom.Exits[2] != CurrentRoom)
                    {
                        CurrentRoom = CurrentRoom.Exits[2];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do now? ");
                        Navigation();
                        break;
                    }
                    Danger();
                    break;
                case "go west":
                    Console.Clear();
                    System.Console.WriteLine("You walk West...");
                    if (CurrentRoom.Exits[3] != CurrentRoom)
                    {
                        CurrentRoom = CurrentRoom.Exits[3];
                        System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                        System.Console.Write("What would you like to do now? ");
                        Navigation();
                        break;
                    }
                    Danger();
                    break;
                case "look":
                    System.Console.WriteLine(CurrentRoom.Description);
                    System.Console.Write("What would you like to do? ");
                    Navigation();
                    break;
                case "take":
                    TakeTreasure();
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
            if (ActivePlayer.Encumberance >= 12)
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
            else{
                System.Console.Write("What would you like to do? ");
                Navigation();
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
            System.Console.WriteLine("\n********************************\nControls:\nGo <direction>: proceed to the next room in the chosen direction (North, South, East, West)\nLook: Get a description of the current room.\nTake: Pick up any treasure (when available)\nHelp: Displays this list\nQuit: Leave the game.\n********************************\n");
            System.Console.WriteLine("The goal of the game is to get at least 12lbs of treasure. \nBe careful though, danger lies at every step!\n");
            System.Console.Write("What would you like to do? ");
            Navigation();
        }
        public void TakeTreasure()
        {
            if (CurrentRoom.Inventory.Count != 0)
            {
                Random rnd = new Random();
                int rndTreasure = rnd.Next(0, (CurrentRoom.Inventory.Count));
                System.Console.WriteLine(rndTreasure);
                System.Console.WriteLine($"You found {CurrentRoom.Inventory[rndTreasure].Name}!");
                ActivePlayer.Inventory.Add(CurrentRoom.Inventory[0]);
                ActivePlayer.Encumberance += CurrentRoom.Inventory[rndTreasure].Weight;
                System.Console.WriteLine($"You are now carrying {ActivePlayer.Encumberance} lbs of treasure");
                CurrentRoom.Inventory.Remove(CurrentRoom.Inventory[rndTreasure]);
                Win();
            }
            else
            {
                System.Console.WriteLine("There's nothing here but cobwebs.");
                System.Console.Write("What would you like to do? ");
                Navigation();
            }
        }

        public void Danger()
        {
            Random rnd = new Random();
            int loseChance = rnd.Next(1, 100);
            if ((loseChance % 3) == 0)
            {
                System.Console.WriteLine("You have fallen into a pit and can proceed no further.");
                Lose();
            }
            else
            {
                System.Console.WriteLine("That direction is full of danger, and appears to have no exit.");
                System.Console.Write("What would you like to do? ");
                Navigation();
            }
        }

        public void Quit()
        {
            System.Console.WriteLine($"\nYou have chosen to end the treasure hunt. Farewell, {ActivePlayer.Name}");
        }
    }
}