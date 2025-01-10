using System;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class NewGuidBench
    {
        [Benchmark]
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        [Benchmark]
        public Guid CreateVersion7()
        {
            return Guid.CreateVersion7();
        }
    }
}