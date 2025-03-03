namespace StudyPlan.Problem.LeetCode75.Stack
{
    public class AsteroidCollision
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            foreach(int asteroid in asteroids)
            {
                bool exploded = false;

                while(stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
                {
                    int top = stack.Peek();
                    if(top < -asteroid)
                    {
                        stack.Pop();
                        continue;
                    }

                    else if(top == -asteroid)
                    {
                        stack.Pop();
                    }

                    exploded = true;
                    break;
                }

                if(!exploded)
                {
                    stack.Push(asteroid);
                }
            }

            int[] result = stack.ToArray();
            Array.Reverse(result);
            
            return result;
        }
    }
}