using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day20
{
    class Swarm
    {
        public List<Particle> Particles { get; set; }
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
                var closestKey = Closests.OrderByDescending(c => c.Value).First().Key;
                return Particles.First(p => p.Index == closestKey);
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

        public void Next()
        {
            // advance all particles
            foreach (var particle in Particles)
            {
                particle.Velocity = particle.UpdateVelocity;
                particle.Position = particle.UpdatePosition;
            }

            // determine closest status
            var closest = ClosestNow;
            if (!Closests.ContainsKey(closest.Index))
            {
                Closests.Add(closest.Index, 1);
            }
            else
            {
                var closests = ++Closests[closest.Index];
                Closests[closest.Index] = closests;
            }

            // eliminate any particles that collided (like anti-matter meets matter)
            EliminateCollisions();
        }

        private void EliminateCollisions()
        {
            // collect all the particles by their distance
            var distances = new Dictionary<long, List<Particle>>();
            foreach (var particle in Particles)
            {
                var distance = particle.ManhattanDistance;
                if (distances.ContainsKey(distance))
                    distances[distance].Add(particle);
                else
                    distances.Add(distance, new List<Particle> { particle });
            }

            // only compare any distances that have more than one entry - this is much faster than doing an exhaustive O(n^2) search!
            var confirmedDupes = new List<Particle>();
            var distanceDupes = distances.Where(d => d.Value.Count > 1);
            foreach (var distanceDupe in distanceDupes)
            {
                // now only exhaustively compare the dupes with the same distance
                foreach (var dupe1 in distanceDupe.Value)
                {
                    foreach (var dupe2 in distanceDupe.Value)
                    {
                        if (dupe1.Index == dupe2.Index) continue;
                        if (dupe1.Position == dupe2.Position)
                        {
                            if (!confirmedDupes.Contains(dupe1)) confirmedDupes.Add(dupe1);
                            if (!confirmedDupes.Contains(dupe2)) confirmedDupes.Add(dupe2);
                        }
                    }
                }
            }
            foreach (var confirmedDupe in confirmedDupes)
                Particles.Remove(confirmedDupe);
        }
    }
}
