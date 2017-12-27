using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day20
{
    // there is a Vector3 in XNA/DirectX.
    // there is also a Point3D elsewhere in Windows-land.
    // unfortunately there is too much cheese that comes with either pizzas.
    // so i am spinning a quick one of my own here and blending the names.
    class Vector3D
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public static Vector3D Max => new Vector3D { X = long.MaxValue, Y = 0, Z = 0 };

        public Vector3D() { }
        public Vector3D(string[] axes)
        {
            X = long.Parse(axes[0]); // assumes valid long in string
            Y = long.Parse(axes[1]);
            Z = long.Parse(axes[2]);
        }
        public Vector3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator +(Vector3D left, Vector3D right)
        {
            return new Vector3D(right.X + left.X, right.Y + left.Y, right.Z + left.Z);
        }

        public static bool operator ==(Vector3D left, Vector3D right)
        {
            return right.X == left.X && right.Y == left.Y && right.Z == left.Z;
        }
        public static bool operator !=(Vector3D left, Vector3D right)
        {
            return !(left == right);
        }
        public override bool Equals(object vec)
        {
            return this == (Vector3D) vec;
        }
    }
}
