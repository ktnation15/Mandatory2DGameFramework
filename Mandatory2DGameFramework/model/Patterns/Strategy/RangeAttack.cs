using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.Patterns.Strategy;

public class RangeAttack : IAttackStrategy
{
    private readonly int _baseDamage;
    private readonly int _rangeModifier;
    private static readonly Random _random = new Random();

    public RangeAttack(int baseDamage, int rangeModifier)
    {
        _baseDamage = baseDamage;
        _rangeModifier = rangeModifier;
    }

    public void Attack(Creature creature, Creature target)
    {
        // Beregn skade ved hjælp af CalculateDamage-metoden
        int damage = CalculateDamage();

        // Udfør angrebet
        target.ReceiveHit(damage);
        Console.WriteLine($"{creature.Name} performs a ranged attack on {target.Name} causing {damage} damage!");
    }

    public int CalculateDamage()
    {
        // Beregn skade med tilfældig variance baseret på afstand
        int damageVariance = _random.Next(-_rangeModifier, _rangeModifier);
        return _baseDamage + damageVariance;
    }

    public override string ToString()
    {
        return $"Range Attack: {_baseDamage} base damage with ±{_rangeModifier} range modifier";
    }
}
