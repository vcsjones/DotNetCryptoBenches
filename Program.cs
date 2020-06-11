using BenchmarkDotNet.Running;

namespace NetCryptoBench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromTypes(new[] { typeof(ECDsaBench), typeof(RSABench), typeof(RSAKeyGenBench) }).Run(args);
        }
    }
}
