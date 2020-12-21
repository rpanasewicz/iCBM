using Misio.Domain.Types;

namespace iCBM.Domain.Enums
{
    public class Color : Enumeration
    {
        public static readonly Color Red = new Color(1, "red");
        public static readonly Color Pink = new Color(2, "pink");
        public static readonly Color Purple = new Color(3, "purple");
        public static readonly Color DeepPurple = new Color(4, "deep-purple");
        public static readonly Color Indigo = new Color(5, "indigo");
        public static readonly Color Blue = new Color(6, "blue");
        public static readonly Color LightBlue = new Color(7, "light-blue");
        public static readonly Color Cyan = new Color(8, "cyan");
        public static readonly Color Teal = new Color(9, "teal");
        public static readonly Color Green = new Color(10, "green");
        public static readonly Color LightGreen = new Color(11, "light-green");
        public static readonly Color Lime = new Color(12, "lime");
        public static readonly Color Yellow = new Color(13, "yellow");
        public static readonly Color Amber = new Color(14, "amber");
        public static readonly Color Orange = new Color(15, "orange");
        public static readonly Color DeepOrange = new Color(16, "deep-orange");
        public static readonly Color Brown = new Color(17, "brown");
        public static readonly Color BlueGrey = new Color(18, "blue-grey");
        public static readonly Color Grey = new Color(19, "grey");

        public Color(int id, string name) : base(id, name)
        {
        }
    }
}