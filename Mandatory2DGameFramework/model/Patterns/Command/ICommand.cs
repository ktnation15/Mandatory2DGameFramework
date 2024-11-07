using Mandatory2DGameFramework.model.Creatures;
using System;

namespace Mandatory2DGameFramework.model.Patterns.Command
{
    // ICommand interface
    public interface ICommand
    {
        void Execute();
    }

    // MoveCommand class that implements ICommand
    public class MoveCommand : ICommand
    {
        private Creature _creatureInstance;
        private int _x, _y;

        public MoveCommand(Creature creature, int x, int y)
        {
            _creatureInstance = creature;
            _x = x;
            _y = y;
        }

        // Execute method that moves the creature to the specified coordinates
        public void Execute() => _creatureInstance.SetPosition(_x, _y);
    }
}
