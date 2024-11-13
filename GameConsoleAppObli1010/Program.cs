using Mandatory2DGameFramework.ConfigurationXML;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Brug Singleton Instance i stedet for at oprette en ny MyLogger
        MyLogger.Instance.LogInformation("Starting game...");

        // Læs XML-konfigurationen og opret verden
        ReadXML readXML = new ReadXML(@"C:\\Users\\John Mayer\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\ConfigurationXML\\GameConfig.xml");
        World world = readXML.ReadWorldConfig();

        if (world != null)
        {
            MyLogger.Instance.LogInformation($"World created with dimensions: {world.MaxX} x {world.MaxY}");

            // Hent creatures og objekter fra verden
            var creatures = world.GetCreatures();
            foreach (var creature in creatures)
            {
                MyLogger.Instance.LogInformation($"Creature loaded: {creature}");
            }

            var worldObjects = world.GetWorldObjects();
            foreach (var worldObject in worldObjects)
            {
                MyLogger.Instance.LogInformation($"World object loaded: {worldObject}");
            }

            // Start kamp mellem de første to creatures
            if (creatures.Count >= 2)
            {
                Battle(creatures[0], creatures[1]); // Start kamp mellem de første to skabninger
            }
            else
            {
                MyLogger.Instance.LogWarning("Not enough creatures to start a battle.");
            }
        }
        else
        {
            MyLogger.Instance.LogError("Failed to load world configuration.");
        }

        MyLogger.Instance.Close(); // Luk loggeren når programmet er færdigt
    }

    // Kampmetode mellem to skabninger
    static void Battle(Creature creature1, Creature creature2)
    {
        MyLogger.Instance.LogInformation($"Battle started between {creature1.Name} and {creature2.Name}!");

        // Kamp-loop: Skabninger angriber hinanden i tur og orden
        while (creature1.HitPoint > 0 && creature2.HitPoint > 0)
        {
            // Skabning 1 angriber skabning 2
            int damageToCreature2 = creature1.Hit();
            creature2.ReceiveHit(damageToCreature2);
            MyLogger.Instance.LogInformation($"{creature1.Name} attacks {creature2.Name} for {damageToCreature2} damage. {creature2.Name} HP: {creature2.HitPoint}");

            // Hvis skabning 2 er død, afslut kampen
            if (creature2.HitPoint <= 0)
            {
                MyLogger.Instance.LogInformation($"{creature2.Name} has been defeated!");
                break;
            }

            // Skabning 2 angriber skabning 1
            int damageToCreature1 = creature2.Hit();
            creature1.ReceiveHit(damageToCreature1);
            MyLogger.Instance.LogInformation($"{creature2.Name} attacks {creature1.Name} for {damageToCreature1} damage. {creature1.Name} HP: {creature1.HitPoint}");

            // Hvis skabning 1 er død, afslut kampen
            if (creature1.HitPoint <= 0)
            {
                MyLogger.Instance.LogInformation($"{creature1.Name} has been defeated!");
                break;
            }

            // Hvis kampen fortsætter, log hvad der sker
            MyLogger.Instance.LogInformation("Round over. Continuing...");
        }

        MyLogger.Instance.LogInformation("Battle ended.");
    }
}
