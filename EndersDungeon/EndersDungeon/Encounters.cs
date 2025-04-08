namespace EndersDungeon
{
    internal class Encounters
    {
        static Random rand = new Random();
        // Encounter Generic

        // Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("\nYou throw open the door, and grab a rusty metal sword, while charging toward your captor.");
            Console.WriteLine("He turns...\n");
            Console.ReadKey();

            Combat(false, "Human Rogue", 1, 4);
        }

        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there you see a hulking beast...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        // Encounter tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    BasicFightEncounter();
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = rand.Next(1, 5);
                h = rand.Next(1, 8);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0) 
            {
                Console.WriteLine("\n", n);
                Console.WriteLine("Power: {0} / Health: {1}", p, h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|  (R)un    (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine(" Potions: {0}  Health: {1}", Program.currentPlayer.potions, Program.currentPlayer.health);
                
                string input = "";
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please Enter a Command:");
                    input = Console.ReadLine();
                }

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // Attack
                    var damage = p - Program.currentPlayer.armorValue;

                    if (damage < 0)
                        damage = 0;
                   
                    var attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("With haste you surge forth, attacking. As you pass, the {0} strikes you back as you pass.", name);
                    Console.WriteLine("You lose {0} health and deal, {1} damage", damage, attack);

                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend
                    var damage = (p/4) - Program.currentPlayer.armorValue;

                    if (damage < 0)
                        damage = 0;

                    var attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("As {0} prepares to strike, you ready your weapon in a defensive stance", name);
                    Console.WriteLine("You lose {0} health and deal, {1} damage", damage, attack);

                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if(rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from {0}, they catch you on the back and sending you sprawling to the ground", n);

                        var damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("You lose {0} health and are unable to escape", damage);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You manage to escape from {0} with your life", n);
                        Console.ReadKey();
                        // Go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal
                    if (Program.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("As you fumble around in your pack, you realise you have no potions left.");

                        var damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("{0} takes the oportunity to strike you while your guard is down. You take {1} damage", n, damage);
                    }
                    else
                    {
                        var healAmount = 5;
                        Console.WriteLine("You reach into your bag, and find a glowing purple flash, you chug the contents restoring {0} health.", healAmount);
                        Program.currentPlayer.health += healAmount;

                        Console.WriteLine("As you were occupied the {0} advances and takes a cheap shot!", n);
                        var damage = (p / 2) - Program.currentPlayer.armorValue;

                        if(damage < 0)
                            damage = 0;

                        Console.WriteLine("You take {0} damage", damage);
                    }
                    Console.ReadKey();
                }
                if(Program.currentPlayer.health <= 0)
                {
                    Console.WriteLine("As the {0} strikes at {1} they deal a decisive blow and strike you down.", n, Program.currentPlayer.Name);
                    Console.WriteLine("=====================");
                    Console.WriteLine("|      GAME OVER    |");
                    Console.WriteLine("=====================");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.ReadKey();
            }

            var c = rand.Next(10, 50);
            Console.WriteLine("As you stand victorious over {0} it's body disolves into {1} gold coins!", n, c);
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch(rand.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
            }

            return "Human Rogue";
        }
    }
}
