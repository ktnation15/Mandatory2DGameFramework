using Mandatory2DGameFramework.model.Creatures;
using System;

namespace Mandatory2DGameFramework.model.Patterns.Strategy
{
    public interface IAttackStrategy
    {
        void Attack(Creature creature, Creature target);
    }

    public class MeleeAttack : IAttackStrategy
    {
        public void Attack(Creature creature, Creature target)
        {
            // Standard nærkampsskade, hvis ingen angrebsvåben er udstyret
            int damage = creature.Attack?.Hit ?? 10;
            target.ReceiveHit(damage);
            Console.WriteLine($"{creature.Name} performs a melee attack on {target.Name} causing {damage} damage!");
        }
    }

    public class RangeAttack : IAttackStrategy
    {
        private static Random _random = new Random();  // Brug en statisk Random for bedre præstation

        public void Attack(Creature creature, Creature target)
        {
            // Antag, at der er en distance-modifikator for fjernangreb
            int baseDamage = creature.Attack?.Hit ?? 5;  // Standard fjernskade, hvis ingen angrebsvåben er udstyret
            int rangeModifier = 2; // Et eksempel på en distance-modifikator

            // Eksempel på varierende fjernskade baseret på en tilfældig modifikator
            int damage = baseDamage + _random.Next(-rangeModifier, rangeModifier + 1);
            target.ReceiveHit(damage);

            Console.WriteLine($"{creature.Name} performs a ranged attack on {target.Name} causing {damage} damage!");
        }
    }
}
