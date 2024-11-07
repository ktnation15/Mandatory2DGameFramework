using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures; // Sørg for at inkludere ExternalCreature
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds; // Sørg for at inkludere WorldObject

namespace Mandatory2DGameFramework.model.Patterns.Adapter
{
    public class CreatureAdapter : ICreature
    {
        private readonly ExternalCreature _externalCreature;

        public CreatureAdapter(ExternalCreature externalCreature)
        {
            _externalCreature = externalCreature;
        }

        // Implementering af ICreature properties
        public string Name
        {
            get => _externalCreature.Name;
            set => _externalCreature.Name = value;
        }

        public int HitPoint
        {
            get => _externalCreature.HitPoint;
            set => _externalCreature.HitPoint = value;
        }

        public AttackItem? Attack
        {
            get => _externalCreature.Attack;
            set => _externalCreature.Attack = value;
        }

        public DefenceItem? Defence
        {
            get => _externalCreature.Defence;
            set => _externalCreature.Defence = value;
        }

        // Implementering af metoder fra ICreature
        public void PerformAttack(Creature target)
        {
            _externalCreature.ExecuteAttack(target);  // Sørg for at denne metode findes i ExternalCreature
        }

        public void ReceiveHit(int hit)
        {
            _externalCreature.ReceiveHit(hit);  // Sørg for at denne metode findes i ExternalCreature
        }

        public void Loot(WorldObject obj)
        {
            _externalCreature.Loot(obj);  // Sørg for at denne metode findes i ExternalCreature
        }
    }
}
