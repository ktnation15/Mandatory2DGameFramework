using Mandatory2DGameFramework.model.Creatures;
using System;

namespace Mandatory2DGameFramework.model.Patterns.Command
{
    // MoveCreatureCommand.cs
    public class MoveCreatureCommand : ICommand
    {
        private Creature _creature;
        private int _deltaX;
        private int _deltaY;

        // Constructor to initialize MoveCreatureCommand with a Creature and displacement in x and y directions
        public MoveCreatureCommand(Creature creature, int deltaX, int deltaY)
        {
            _creature = creature;
            _deltaX = deltaX;
            _deltaY = deltaY;
        }

        // Execute method that moves the Creature based on the specified displacements
        public void Execute()
        {
            _creature.X += _deltaX;  // Update the X position of the Creature
            _creature.Y += _deltaY;  // Update the Y position of the Creature
        }
    }
}
