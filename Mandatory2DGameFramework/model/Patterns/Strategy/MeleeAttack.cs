using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.Patterns.Strategy;
using Mandatory2DGameFramework.Patterns.Strategy;

namespace Mandatory2DGameFramework.Patterns.Strategy
{
    public class MeleeAttack : IAttackStrategy
    {
        private readonly int _baseDamage;

        public MeleeAttack(int baseDamage)
        {
            _baseDamage = baseDamage;
        }

        public void Attack(Creature creature, Creature target)
        {
            // Beregn skade
            int damage = CalculateDamage();

            // Udfør angrebet
            target.ReceiveHit(damage);
            Console.WriteLine($"{creature.Name} performs a melee attack on {target.Name} causing {damage} damage!");
        }

        public int CalculateDamage()
        {
            // Beregn skade (kan udvides til at inkludere modifikatorer)
            return _baseDamage;
        }

        public override string ToString()
        {
            return $"Melee Attack: {_baseDamage} base damage";
        }
    }

}
