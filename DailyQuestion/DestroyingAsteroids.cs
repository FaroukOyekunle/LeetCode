namespace DailyQuestion
{
    public class DestroyingAsteroids
    {
        public bool AsteroidsDestroyed(int initialPlanetMass, int[] asteroidMasses)
        {
            Array.Sort(asteroidMasses);

            long currentPlanetMass = initialPlanetMass;

            foreach (int currentAsteroidMass in asteroidMasses)
            {
                if (currentPlanetMass < currentAsteroidMass)
                {
                    return false;
                }

                currentPlanetMass += currentAsteroidMass;
            }

            return true;
        }
    }
}