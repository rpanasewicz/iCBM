using Misio.Domain.Types;

namespace iCBM.Domain.Enums
{
    public class Color : Enumeration
    {
        public static readonly Color Primary = new Color(1, "primary");
        public static readonly Color Secondary = new Color(2, "secondary");
        public static readonly Color Success = new Color(3, "success");
        public static readonly Color Danger = new Color(4, "danger");
        public static readonly Color Warning = new Color(5, "warning");
        public static readonly Color Info = new Color(6, "info");
        public static readonly Color Light = new Color(7, "light");
        public static readonly Color Dark = new Color(8, "dark");

        public Color(int id, string name) : base(id, name)
        {
        }
    }
}