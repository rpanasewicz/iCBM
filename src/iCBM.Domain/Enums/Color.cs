using Misio.Domain.Types;

namespace iCBM.Domain.Enums
{
    public class Color : Enumeration
    {
        public static readonly Color Gray = new Color(1, "gray");
        public static readonly Color Red = new Color(2, "red");
        public static readonly Color Yellow = new Color(3, "yellow");
        public static readonly Color Green = new Color(4, "green");
        public static readonly Color Blue = new Color(5, "blue");
        public static readonly Color Indigo = new Color(6, "indigo");
        public static readonly Color Purple = new Color(7, "purple");
        public static readonly Color Pink = new Color(8, "pink");

        public Color(int id, string name) : base(id, name)
        {
        }
    }
}