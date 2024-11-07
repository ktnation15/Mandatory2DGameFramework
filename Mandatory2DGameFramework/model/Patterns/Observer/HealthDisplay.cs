using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.Patterns.Observer;
using System;

namespace Mandatory2DGameFramework.Patterns.Observer
{
    /// <summary>
    /// Represents the health display of a creature, observing and showing updates
    /// to the creature's health (hit points).
    /// Implements the IObserver pattern to update the health display when changes occur.
    /// </summary>
    public class HealthDisplay : IObserver<Creature>
    {
        private readonly Creature _creature;

        /// <summary>
        /// Constructor to initialize with a Creature object.
        /// </summary>
        /// <param name="creature">The creature whose health is to be displayed.</param>
        public HealthDisplay(Creature creature)
        {
            _creature = creature;
        }

        /// <summary>
        /// Updates the health display with the current hit points of the creature.
        /// This method is called when the creature's health changes.
        /// </summary>
        /// <param name="creature">The creature whose health has changed.</param>
        public void OnNext(Creature creature)
        {
            Console.WriteLine($"Creature: {creature.Name}, Hit Points: {creature.HitPoint}");
        }

        /// <summary>
        /// Updates the health display with a specific number of hit points.
        /// This version is used when manually updating the hit points.
        /// </summary>
        /// <param name="hitPoint">The hit points to display.</param>
        public void Update(int hitPoint)
        {
            Console.WriteLine($"Creature: {_creature.Name}, Hit Points: {hitPoint}");
        }

        /// <summary>
        /// Starts observing the creature's health (hit points).
        /// The health display will update automatically when the creature's health changes.
        /// </summary>
        public void StartObserving()
        {
            _creature.Subscribe(this);  // Subscribes to health changes
        }

        /// <summary>
        /// Stops observing the creature's health.
        /// No further updates to the health display will occur after this method is called.
        /// </summary>
        public void StopObserving()
        {
            _creature.Subscribe(this).Dispose();  // Stops observing by disposing the subscription
        }

        /// <summary>
        /// This method handles the completion of an observation session (not implemented here).
        /// </summary>
        public void OnCompleted()
        {
            // Optional: Implement behavior when the observation ends, if needed
        }

        /// <summary>
        /// This method handles any errors that occur during observation (not implemented here).
        /// </summary>
        /// <param name="error">The exception that caused the error.</param>
        public void OnError(Exception error)
        {
            // Optional: Implement error handling behavior
            Console.WriteLine($"Error: {error.Message}");
        }
    }
}
