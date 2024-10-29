using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public Creature()
        {
            Name = string.Empty;
            HitPoint = 100;
            Attack = null;
            Defence = null;
        }

        /// <summary>
        /// Inflicts a hit on another creature based on the attack item's hit points.
        /// </summary>
        /// <returns>Hit points of the attack.</returns>
        public int Hit()
        {
            return Attack?.Hit ?? 0;
        }

        /// <summary>
        /// Receives a hit and reduces hit points based on the defense item's reduction.
        /// </summary>
        /// <param name="hit">Hit points received.</param>
        public void ReceiveHit(int hit)
        {
            int reduction = Defence?.ReduceHitPoints ?? 0;
            HitPoint -= Math.Max(0, hit - reduction);
            if (HitPoint < 0) HitPoint = 0; // Ensure hit points don't go below zero
        }

        /// <summary>
        /// Loots a world object to gain or improve weapons or defense items.
        /// </summary>
        /// <param name="obj">The world object to loot.</param>
        public void Loot(WorldObject obj)
        {
            if (obj is AttackItem attackItem)
            {
                Attack = attackItem;
            }
            else if (obj is DefenceItem defenceItem)
            {
                Defence = defenceItem;
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint}, {nameof(Attack)}={Attack?.ToString() ?? "None"}, {nameof(Defence)}={Defence?.ToString() ?? "None"}}}";
        }
    }
}
