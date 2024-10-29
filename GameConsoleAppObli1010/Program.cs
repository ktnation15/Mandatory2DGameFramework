using Mandatory2DGameFramework.ConfigurationXML;
using Mandatory2DGameFramework.worlds;

class Program
{
    static void Main(string[] args)
    {
        MyLogger logger = new MyLogger();
        logger.LogInformation("Starting game...");

        ReadXML readXML = new ReadXML(@"C:\\Users\\John Mayer\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\ConfigurationXML\\GameConfig.xml");
        World world = readXML.ReadWorldConfig();

        if (world != null)
        {
            logger.LogInformation($"World created with dimensions: {world.MaxX} x {world.MaxY}");
            foreach (var creature in world.GetCreatures())
            {
                logger.LogInformation($"Creature loaded: {creature}");
            }
            foreach (var worldObject in world.GetWorldObjects())
            {
                logger.LogInformation($"World object loaded: {worldObject}");
            }
        }
        else
        {
            logger.LogError("Failed to load world configuration.");
        }

        logger.Close(); // Close the logger when done
    }
}
