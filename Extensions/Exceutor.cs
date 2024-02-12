namespace SeleniumFramework.Extensions
{
    public static class Executor
    {
        public static void Execute<T>(Func<T> func, int numberOfRetries)
        {
            int tries = 0;
            string msg = "";
            while (tries <= numberOfRetries)
            {
                try
                {
                    func();
                }
                catch (Exception e)
                {
                    msg = e.Message;
                    tries++;
                }
            }
            throw new Exception(msg);
        }
    }
}
