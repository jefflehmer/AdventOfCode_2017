using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using aoc_2017.Day08;

namespace aoc_2017.Day20
{
    class Particle
    {
        public Vector3D Position { get; set; }
        public Vector3D Velocity { get; set; }
        public Vector3D Acceleration { get; set; }
        public int Index { get; set; }

        public long ManhattanDistance => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);

        public static Particle Max => new Particle() { Index = -1, Position = Vector3D.Max };

        public static Particle Parse(string raw, int index)
        {
            var match = Regex.Match(raw, @"p=<(?<position>.*)>, v=<(?<vector>.*)>, a=<(?<acceleration>.*$)>");
            var positions = match.Groups["position"].ToString().Split(',');
            var vectors = match.Groups["vector"].ToString().Split(',');
            var accelerations = match.Groups["acceleration"].ToString().Split(',');

            return new Particle
            {
                Position = new Vector3D(positions),
                Velocity = new Vector3D(vectors),
                Acceleration = new Vector3D(accelerations),
                Index = index
            };
        }

        public Vector3D UpdateVelocity => Velocity + Acceleration;
        public Vector3D UpdatePosition => Position + Velocity;
    }
}
