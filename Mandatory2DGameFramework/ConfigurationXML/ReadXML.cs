using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mandatory2DGameFramework.model.Creatures; // Include your model namespaces
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds; // Ensure this is the correct namespace for WorldObject

namespace Mandatory2DGameFramework.ConfigurationXML
{
    public class ReadXML
    {
        private XDocument configDoc;

        public ReadXML(string filePath)
        {
            configDoc = XDocument.Load(filePath);
        }

        public World ReadWorldConfig()
        {
            XElement root = configDoc.Element("GameConfig");
            XElement worldElement = root.Element("World");
            if (worldElement == null) return null;

            int maxX = int.Parse(worldElement.Element("MaxX")?.Value ?? "100");
            int maxY = int.Parse(worldElement.Element("MaxY")?.Value ?? "100");
            World world = new World(maxX, maxY);

            // Read Creatures
            foreach (XElement creatureElement in worldElement.Element("Creatures")?.Elements("Creature") ?? Enumerable.Empty<XElement>())
            {
                Creature creature = new Creature
                {
                    Name = creatureElement.Element("Name")?.Value ?? "Unknown",
                    HitPoint = int.Parse(creatureElement.Element("HitPoints")?.Value ?? "0"),
                    Attack = new AttackItem
                    {
                        Name = creatureElement.Element("AttackItems")?.Element("AttackItem")?.Element("Name")?.Value ?? "None",
                        Hit = int.Parse(creatureElement.Element("AttackItems")?.Element("AttackItem")?.Element("HitPoints")?.Value ?? "0"),
                        Range = int.Parse(creatureElement.Element("AttackItems")?.Element("AttackItem")?.Element("Range")?.Value ?? "0")
                    },
                    Defence = new DefenceItem
                    {
                        Name = creatureElement.Element("DefenceItems")?.Element("DefenceItem")?.Element("Name")?.Value ?? "None",
                        ReduceHitPoints = int.Parse(creatureElement.Element("DefenceItems")?.Element("DefenceItem")?.Element("ReduceHitPoints")?.Value ?? "0")
                    }
                };

                world.AddCreature(creature);
            }

            // Read WorldObjects
            foreach (XElement worldObjectElement in worldElement.Element("WorldObjects")?.Elements("WorldObject") ?? Enumerable.Empty<XElement>())
            {
                // Explicitly specify the correct namespace for WorldObject
                Mandatory2DGameFramework.worlds.WorldObject worldObject = new Mandatory2DGameFramework.worlds.WorldObject
                {
                    X = int.Parse(worldObjectElement.Element("PositionX")?.Value ?? "0"),
                    Y = int.Parse(worldObjectElement.Element("PositionY")?.Value ?? "0"),
                    Removable = bool.Parse(worldObjectElement.Element("Removable")?.Value ?? "false"),
                    Type = worldObjectElement.Element("Type")?.Value ?? "Unknown" // Add Type property to identify the type of WorldObject
                };

                world.AddWorldObject(worldObject); // Add the WorldObject to the World
            }

            return world;
        }
    }
}
