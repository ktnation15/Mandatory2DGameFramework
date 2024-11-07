using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.Patterns.Strategy;

public class DefenseDecorator : Creature
{
    private readonly Creature _creature;
    private readonly int _extraDefense;

    // Konstruktør for at tage imod en Creature og et ekstra forsvar
    public DefenseDecorator(Creature creature, int extraDefense)
    {
        _creature = creature;
        _extraDefense = extraDefense;
    }

    // Overrider Attack-egenskaben for at tilføje ekstra skade, hvis nødvendigt
    public override AttackItem? Attack
    {
        get => _creature.Attack;
        set => _creature.Attack = value;
    }

    // Overrider Defence-egenskaben for at tilføje ekstra forsvar
    public override DefenceItem? Defence
    {
        get
        {
            if (_creature.Defence != null)
            {
                var originalDefence = _creature.Defence;
                // Tilføj ekstra forsvar til det eksisterende forsvar
                var modifiedDefence = new DefenceItem
                {
                    ReduceHitPoints = originalDefence.ReduceHitPoints + _extraDefense
                };
                return modifiedDefence;
            }
            return new DefenceItem { ReduceHitPoints = _extraDefense };
        }
    }

    // Overrider Name-egenskaben
    public new string Name
    {
        get => _creature.Name;
        set => _creature.Name = value;
    }

    // Overrider HitPoint for at anvende ekstra forsvar
    public new int HitPoint
    {
        get => _creature.HitPoint;
        set => _creature.HitPoint = value;
    }

    // Overrider AttackStrategy-egenskaben
    public override IAttackStrategy? AttackStrategy
    {
        get => _creature.AttackStrategy;
        set => _creature.AttackStrategy = value;
    }

    public override string ToString()
    {
        return $"Decorator for {Name}: {HitPoint} HP, {Defence?.ReduceHitPoints} defense";
    }
}
