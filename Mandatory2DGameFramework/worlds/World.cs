using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        // World objects
        private List<WorldObject> _worldObjects;
        // World creatures
        private List<Creature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        /// <summary>
        /// Adds a world object to the world.
        /// </summary>
        /// <param name="worldObject">The world object to add.</param>
        public void AddWorldObject(WorldObject worldObject)
        {
            _worldObjects.Add(worldObject);
        }

        /// <summary>
        /// Adds a creature to the world.
        /// </summary>
        /// <param name="creature">The creature to add.</param>
        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
        }

        /// <summary>
        /// Returns a list of all world objects.
        /// </summary>
        /// <returns>List of world objects.</returns>
        public List<WorldObject> GetWorldObjects()
        {
            return _worldObjects;
        }

        /// <summary>
        /// Returns a list of all creatures.
        /// </summary>
        /// <returns>List of creatures.</returns>
        public List<Creature> GetCreatures()
        {
            return _creatures;
        }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
