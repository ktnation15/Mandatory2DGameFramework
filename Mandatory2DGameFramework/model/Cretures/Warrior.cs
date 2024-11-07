using System;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class Warrior : Creature
    {
        public Warrior()
        {
            // Initialiser specifikke egenskaber for Warrior-klassen
            Name = "Warrior";
            HitPoint = 150; // Eksempel på et højere antal livspoint for en Warrior
            // Du kan også tilføje specifik angreb, forsvar og strategier her
        }
    }
}
