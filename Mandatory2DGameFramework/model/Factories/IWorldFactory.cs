public class WorldObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool Removable { get; set; }
    public string? Type { get; set; }

    public virtual void Interact()
    {
        // Standard interaktion (kan overskrives af underklasser)
    }

    public override string ToString()
    {
        return $"{{{nameof(Type)}={Type}, {nameof(X)}={X}, {nameof(Y)}={Y}, {nameof(Removable)}={Removable}}}";
    }
}

public class Cactus : WorldObject
{
    public Cactus()
    {
        Type = "Cactus";
        X = 0;
        Y = 0;
        Removable = false;
    }

    public override void Interact()
    {
        // Specifik interaktion for Cactus
        Console.WriteLine("You encounter a Cactus! Watch out for the thorns.");
    }
}
