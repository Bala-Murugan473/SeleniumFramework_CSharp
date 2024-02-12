namespace SeleniumFramework.Extensions
{
    public class RetryHandler
    {
        public static object Execute(Delegate methodToRetry, params object[] args)
        {
            object x = methodToRetry.DynamicInvoke(args);
            return x;
        }
        // test
    }
}
