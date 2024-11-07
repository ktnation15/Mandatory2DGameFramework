using Mandatory2DGameFramework.ConfigurationXML;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;
using System;

class Program
{
    static void Main(string[] args)
    {
        MyLogger logger = new MyLogger();
        logger.LogInformation("Starting game...");

        // Læs XML-konfigurationen og opret verden
        ReadXML readXML = new ReadXML(@"C:\\Users\\John Mayer\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\ConfigurationXML\\GameConfig.xml");
        World world = readXML.ReadWorldConfig();

        if (world != null)
        {
            logger.LogInformation($"World created with dimensions: {world.MaxX} x {world.MaxY}");

            // Hent skabninger og objekter fra verden
            var creatures = world.GetCreatures();
            foreach (var creature in creatures)
            {
                logger.LogInformation($"Creature loaded: {creature}");
            }

            var worldObjects = world.GetWorldObjects();
            foreach (var worldObject in worldObjects)
            {
                logger.LogInformation($"World object loaded: {worldObject}");
            }

            // Start kamp mellem de første to skabninger
            if (creatures.Count >= 2)
            {
                Battle(creatures[0], creatures[1], logger); // Start kamp mellem de første to skabninger
            }
            else
            {
                logger.LogWarning("Not enough creatures to start a battle.");
            }
        }
        else
        {
            logger.LogError("Failed to load world configuration.");
        }

        logger.Close(); // Luk loggeren når programmet er færdigt
    }

    // Kampmetode mellem to skabninger
    static void Battle(Creature creature1, Creature creature2, MyLogger logger)
    {
        logger.LogInformation($"Battle started between {creature1.Name} and {creature2.Name}!");

        // Kamp-loop: Skabninger angriber hinanden i tur og orden
        while (creature1.HitPoint > 0 && creature2.HitPoint > 0)
        {
            // Skabning 1 angriber skabning 2
            int damageToCreature2 = creature1.Hit();
            creature2.ReceiveHit(damageToCreature2);
            logger.LogInformation($"{creature1.Name} attacks {creature2.Name} for {damageToCreature2} damage. {creature2.Name} HP: {creature2.HitPoint}");

            // Hvis skabning 2 er død, afslut kampen
            if (creature2.HitPoint <= 0)
            {
                logger.LogInformation($"{creature2.Name} has been defeated!");
                break;
            }

            // Skabning 2 angriber skabning 1
            int damageToCreature1 = creature2.Hit();
            creature1.ReceiveHit(damageToCreature1);
            logger.LogInformation($"{creature2.Name} attacks {creature1.Name} for {damageToCreature1} damage. {creature1.Name} HP: {creature1.HitPoint}");

            // Hvis skabning 1 er død, afslut kampen
            if (creature1.HitPoint <= 0)
            {
                logger.LogInformation($"{creature1.Name} has been defeated!");
                break;
            }

            // Hvis kampen fortsætter, log hvad der sker
            logger.LogInformation("Round over. Continuing...");
        }

        logger.LogInformation("Battle ended.");
    }
}
