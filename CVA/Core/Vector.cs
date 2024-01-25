namespace CVA.Core
{
    public struct Vector
    {
        public double x;
        public double y;

        public static readonly Vector Zero = new Vector(0, 0);
        public static readonly Vector One = new Vector(1, 1);
        public static readonly Vector NegativeOne = new Vector(-1, -1);
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Vector))
            {
                return false;
            }
            else
            {
                return this == (Vector)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.x * b.x, a.y * b.y);
        }
        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.x / b.x, a.y / b.y);
        }

        public static Vector operator +(Vector a, double b)
        {
            return new Vector(a.x + b, a.y + b);
        }
        public static Vector operator -(Vector a, double b)
        {
            return new Vector(a.x - b, a.y - b);
        }
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.x * b, a.y * b);
        }
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.x / b, a.y / b);
        }

        public static Vector operator +(Vector a)
        {
            return a;
        }
        public static Vector operator -(Vector a)
        {
            return new Vector(a.x * -1, a.y * -1);
        }
    }
}