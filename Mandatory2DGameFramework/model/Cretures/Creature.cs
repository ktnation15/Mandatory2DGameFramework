using System;
using System.Collections.Generic;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.Patterns.Strategy;

public class Creature : IObservable<Creature>  // Implementing IObservable with Creature as the type parameter
{
    private readonly List<IObserver<Creature>> _observers = new List<IObserver<Creature>>();  // List of observers

    private int _hitPoint;

    // Position properties
    public int X { get; set; }
    public int Y { get; set; }

    public string Name { get; set; }

    public int HitPoint
    {
        get => _hitPoint;
        set
        {
            _hitPoint = value;
            NotifyObservers();  // Notify observers if HitPoint changes
        }
    }

    public virtual AttackItem? Attack { get; set; }

    public virtual DefenceItem? Defence { get; set; }

    public virtual IAttackStrategy? AttackStrategy { get; set; }

    public Creature()
    {
        Name = string.Empty;
        HitPoint = 100;
        Attack = null;
        Defence = null;
    }

    // Method to perform an attack
    public void PerformAttack(Creature target)
    {
        AttackStrategy?.Attack(this, target);
    }

    // Method to return the hit damage value
    public int Hit()
    {
        return Attack?.Hit ?? 0;
    }

    // Method to receive damage and apply defense reduction
    public void ReceiveHit(int hit)
    {
        int reduction = Defence?.ReduceHitPoints ?? 0;
        HitPoint -= Math.Max(0, hit - reduction);
        if (HitPoint < 0) HitPoint = 0;
    }

    // Method to loot items (AttackItem or DefenceItem)
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
        else
        {
            Console.WriteLine("Loot item is neither an AttackItem nor a DefenceItem.");
        }
    }

    // Method to set position
    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Implementing IObservable<Creature>
    public IDisposable Subscribe(IObserver<Creature> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return new Unsubscriber(_observers, observer);  // Returning an Unsubscriber to allow unsubscription
    }

    // Notify all observers about the state change (e.g., HitPoint change)
    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(this);  // Notifying observers about the change
        }
    }

    // Unsubscriber class to unsubscribe from the observer list
    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Creature>> _observers;
        private readonly IObserver<Creature> _observer;

        public Unsubscriber(List<IObserver<Creature>> observers, IObserver<Creature> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);  // Removes the observer from the list
            }
        }
    }

    // Overriding ToString to provide a better creature description
    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint}, {nameof(Attack)}={Attack?.ToString() ?? "None"}, {nameof(Defence)}={Defence?.ToString() ?? "None"}}}";
    }
}
