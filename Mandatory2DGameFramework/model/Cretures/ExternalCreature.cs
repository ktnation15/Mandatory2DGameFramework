using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class ExternalCreature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        // Tilføj en Loot-metode, hvis den ikke allerede eksisterer
        public void Loot(WorldObject obj)
        {
            Console.WriteLine($"{Name} has looted a {obj.GetType().Name}!");
            // Her kan du implementere logik for, hvordan looting fungerer.
        }

        public void ExecuteAttack(Creature target)
        {
            Console.WriteLine($"{Name} is attacking {target.Name}!");
        }

        public void ReceiveHit(int hit)
        {
            HitPoint -= hit;
            if (HitPoint < 0) HitPoint = 0;
            Console.WriteLine($"{Name} now has {HitPoint} hit points.");
        }
    }
}
