namespace DailyQuestion
{
    public class TakingMaximumEnergyFromtheMysticDungeon
    {
        public int MaximumEnergy(int[] energy, int k)
        {
            int nMagician = energy.Length;
            int[] absorbingEnergy = new int[nMagician];
            int maximumEnergy = int.MinValue;

            for (int i = nMagician - 1; i >= 0; i--)
            {
                if(i + k < nMagician)
                {
                    absorbingEnergy[i] = energy[i] + absorbingEnergy[i + k];
                }

                else
                {
                    absorbingEnergy[i] = energy[i];
                }

                maximumEnergy = Math.Max(maximumEnergy, absorbingEnergy[i]);
            }

            return maximumEnergy;
        }
    }
}