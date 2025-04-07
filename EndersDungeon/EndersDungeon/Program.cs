namespace EndersDungeon;

class Program
{
    public static Player currentPlayer = new Player();
    static void Main(string[] args)
    {
        Start();
        Encounters.FirstEncounter();
    }

    static void Start()
    {
        Console.WriteLine("Enders Dungeon");
        Console.WriteLine("Name: {0}", currentPlayer.Name);
        var name = Console.ReadLine();
        Console.Clear();

        if (string.IsNullOrEmpty(name))
            currentPlayer.Name = "Stan"; 
        else
            currentPlayer.Name = name;
        
        Console.WriteLine("You awake in a cold stone, dark room. You feel dazed and are having trouble remembering");
        Console.WriteLine("anything about your past. You know your name is {0}", currentPlayer.Name);

        Console.WriteLine("You grope around in the darkness until you find a door handle... You feel some resistance as you turn the handle, but the rusty lock breaks with little effort.");
        Console.WriteLine("You see your captor standing with his back to you, outside the door.");


    }
}