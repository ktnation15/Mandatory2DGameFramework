using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class CreatureDecorator : ICreature
    {
        protected ICreature _creature;

        public CreatureDecorator(ICreature creature)
        {
            _creature = creature;
        }

        public string Name
        {
            get => _creature.Name;
            set => _creature.Name = value;
        }

        public int HitPoint
        {
            get => _creature.HitPoint;
            set => _creature.HitPoint = value;
        }

        public AttackItem? Attack
        {
            get => _creature.Attack;
            set => _creature.Attack = value;
        }

        public DefenceItem? Defence
        {
            get => _creature.Defence;
            set => _creature.Defence = value;
        }

        public virtual void PerformAttack(Creature target)
        {
            _creature.PerformAttack(target);
        }

        public void ReceiveHit(int hit)
        {
            _creature.ReceiveHit(hit);
        }

        public void Loot(WorldObject obj)
        {
            _creature.Loot(obj);
        }
    }
}
