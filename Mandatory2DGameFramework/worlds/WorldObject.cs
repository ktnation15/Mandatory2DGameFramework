namespace Mandatory2DGameFramework.worlds
{
    public class WorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Removable { get; set; }
        public string? Type { get; set; } // Add Type property to identify the type of WorldObject

        public override string ToString()
        {
            return $"{{{nameof(Type)}={Type}, {nameof(X)}={X}, {nameof(Y)}={Y}, {nameof(Removable)}={Removable}}}";
        }
    }
}
