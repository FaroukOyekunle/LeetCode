namespace StudyPlan.Problem.LeetCode75.Queue
{
    public class Dota2Senate
    {
        public string PredictPartyVictory(string senate)
        {
            int n = senate.Length;

            Queue<int> radiant = new Queue<int>();
            Queue<int> dire = new Queue<int>();

            for(int i = 0; i < n; i++)
            {
                if (senate[i] == 'R')
                {
                    radiant.Enqueue(i);
                }
                    
                else
                {
                    dire.Enqueue(i);
                }
            }

            while(radiant.Count > 0 && dire.Count > 0)
            {
                int rIndex = radiant.Dequeue();
                int dIndex = dire.Dequeue();

                if(rIndex < dIndex)
                {
                    radiant.Enqueue(rIndex + n);
                }

                else
                {
                    dire.Enqueue(dIndex + n);
                }
            }

            return radiant.Count > 0 ? "Radiant" : "Dire";
        }
    }
}