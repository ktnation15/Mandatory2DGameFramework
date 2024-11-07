using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;  // WorldObject here is the class you want to use
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Factories
{
    public class WorldBuilder
    {
        private World _world;

        public WorldBuilder StartNewWorld(int maxX, int maxY)
        {
            _world = new World(maxX, maxY);
            return this;
        }

        public WorldBuilder AddCreature(Creature creature)
        {
            _world.AddCreature(creature);
            return this;
        }

        public WorldBuilder AddWorldObject(Mandatory2DGameFramework.worlds.WorldObject obj)  // Fully qualified type
        {
            _world.AddWorldObject(obj);
            return this;
        }

        public World Build() => _world;
    }
}
