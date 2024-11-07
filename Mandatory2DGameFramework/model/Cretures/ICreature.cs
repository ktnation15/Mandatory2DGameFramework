using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.model.Creatures
{
    public interface ICreature
    {
        string Name { get; set; }
        int HitPoint { get; set; }
        AttackItem? Attack { get; set; }
        DefenceItem? Defence { get; set; }

        void PerformAttack(Creature target);
        void ReceiveHit(int hit);
        void Loot(WorldObject obj);
    }
}
