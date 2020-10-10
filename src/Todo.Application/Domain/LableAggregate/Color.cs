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

        public byte Red { get; private set; }

        public byte Green { get; private set; }

        public byte Blue { get; private set; }

        public byte Alpha { get; private set; }

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
