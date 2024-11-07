using Mandatory2DGameFramework.model.Creatures;  // Ensure this is included
using System;
using System.Threading;

namespace Mandatory2DGameFramework.model.Factories
{
    public abstract class CreatureFactory
    {
        public abstract Creature CreateCreature();
    }

    public class WarriorFactory : CreatureFactory
    {
        public override Creature CreateCreature() => new Warrior();  // Ensure Warrior class is defined
    }
}
