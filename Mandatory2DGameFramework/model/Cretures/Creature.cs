using System;
using System.Collections.Generic;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.Patterns.Strategy;

public class Creature : IObservable<Creature>  // Implementerer IObservable med Creature som typeparameter
{
    private readonly List<IObserver<Creature>> _observers = new List<IObserver<Creature>>();  // Liste af observatører

    private int _hitPoint;

    // Position
    public int X { get; set; }
    public int Y { get; set; }

    public string Name { get; set; }

    public int HitPoint
    {
        get => _hitPoint;
        set
        {
            _hitPoint = value;
            NotifyObservers();  // Underret observatører hvis HitPoint ændres
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

    // Metode til at udføre et angreb
    public void PerformAttack(Creature target)
    {
        AttackStrategy?.Attack(this, target);
    }

    // Metode til at returnere skadevurderingen
    public int Hit()
    {
        return Attack?.Hit ?? 0;
    }

    // Metode til at modtage skade og anvende forsvarsreduktion
    public void ReceiveHit(int hit)
    {
        int reduction = Defence?.ReduceHitPoints ?? 0;
        HitPoint -= Math.Max(0, hit - reduction);
        if (HitPoint < 0) HitPoint = 0;
    }

    // Metode til at plyndre genstande (AttackItem eller DefenceItem)
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
            Console.WriteLine("Loot-genstand er hverken en AttackItem eller en DefenceItem.");
        }
    }

    // Metode til at sætte position
    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Implementering af IObservable<Creature>
    public IDisposable Subscribe(IObserver<Creature> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return new Unsubscriber(_observers, observer);  // Returnerer en Unsubscriber til at tillade afmelding
    }

    // Underret alle observatører om en tilstandsændring (fx HitPoint ændring)
    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(this);  // Underret observatørerne om ændringen
        }
    }

    // Unsubscriber-klasse til at afmelde fra observatørlisten
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
                _observers.Remove(_observer);  // Fjerner observatøren fra listen
            }
        }
    }

    // Overskriver ToString for at give en bedre beskrivelse af væsenet
    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint}, {nameof(Attack)}={Attack?.ToString() ?? "None"}, {nameof(Defence)}={Defence?.ToString() ?? "None"}}}";
    }
}
