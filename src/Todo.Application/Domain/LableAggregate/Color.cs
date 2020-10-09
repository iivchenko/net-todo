namespace Todo.Application.Domain.LableAggregate
{
    public sealed class Color
    {
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        private Color()
        {
            Red = Green = Blue = Alpha = 0;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public byte Alpha { get; }

        public override bool Equals(object obj)
        {
            return obj is Color color &&
                   Red == color.Red &&
                   Green == color.Green &&
                   Blue == color.Blue &&
                   Alpha == color.Alpha;
        }

        public override int GetHashCode()
        {
            int hashCode = -1520100960;
            hashCode = hashCode * -1521134295 + Red.GetHashCode();
            hashCode = hashCode * -1521134295 + Green.GetHashCode();
            hashCode = hashCode * -1521134295 + Blue.GetHashCode();
            hashCode = hashCode * -1521134295 + Alpha.GetHashCode();
            return hashCode;
        }
    }
}
