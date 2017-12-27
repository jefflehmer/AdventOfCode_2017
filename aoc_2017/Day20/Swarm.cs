using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day20
{
    class Swarm
    {
        private List<Particle> Particles { get; set; }
        private Dictionary<int, int> Closests { get; set; } // the set of closest particles after each round...with count for how many times that particle was closest

        private Particle ClosestNow
        {
            get
            {
                var closest = Particle.Max;
                foreach (var particle in Particles)
                {
                    if (particle.ManhattanDistance < closest.ManhattanDistance)
                        closest = particle;
                }
                return closest;
            }
        }

        public Particle ClosestLongTerm
        {
            get
            {
                return Particles[Closests.OrderByDescending(c => c.Value).First().Key];
            }
        }

        public Swarm()
        {
            Particles = new List<Particle>();
            Closests = new Dictionary<int, int>();
        }

        public Swarm(string[] rawParticles)
            : this()
        {
            for (int i = 0; i < rawParticles.Length; i++)
            {
                var rawParticle = rawParticles[i];
                Particles.Add(Particle.Parse(rawParticle, i));
            }
        }

        public void Next(int i)
        {
            var count = 0;
            foreach (var particle in Particles)
            {
                particle.Velocity = particle.UpdateVelocity;
                particle.Position = particle.UpdatePosition;
            }

            Closests.Add(i, count);
        }
    }
}
