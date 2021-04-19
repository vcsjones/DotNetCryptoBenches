using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class GuidBench
    {
        [Benchmark]
        [SkipLocalsInit]
        public Guid NewGuid() => Guid.NewGuid();
    }
}