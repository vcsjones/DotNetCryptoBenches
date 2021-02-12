using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CoreRun;

namespace NetCryptoBench
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new LocalCoreClrConfig();
            //config.AddCustom60Toolchain("master", @"/code/personal/dotnet/runtime-master/artifacts/bin/testhost/net6.0-Linux-Release-x64/shared/Microsoft.NETCore.App/6.0.0/", isBaseline: true);
            config.AddCustom60Toolchain("branch", @"/code/personal/dotnet/runtime/artifacts/bin/testhost/net6.0-Linux-Release-x64/shared/Microsoft.NETCore.App/6.0.0/");
            config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
            config.AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
            config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
            config.AddDiagnoser(MemoryDiagnoser.Default);
            BenchmarkSwitcher.FromTypes(new[] {
                typeof(ECDsaBench),
                typeof(ECDsaKeyGenBench),
                typeof(ECDsaImportExportBench),
                typeof(RSABench),
                typeof(RSAKeyGenBench),
                typeof(AesTransformBench),
                typeof(StaticHashBench),
                typeof(Pbkdf2Bench),
                }).Run();
        }

    }

    public class LocalCoreClrConfig : ManualConfig
    {
        // Thanks to https://github.com/GrabYourPitchforks/ConsoleApplicationBenchmark/blob/e0b0048198c856a30cacec19e3edc52c75d0677d/ConsoleAppBenchmark/Program.cs
        public void AddCustom50Toolchain(string displayName, string coreRunDirectory, bool enableTieredCompilation = true, bool isBaseline = false, Dictionary<string, string> envVars = default)
        {
            var toolchain = new CoreRunToolchain(
                coreRun: new DirectoryInfo(coreRunDirectory).GetFiles("corerun").Single(),
                targetFrameworkMoniker: "netcoreapp5.0",
                displayName: displayName);

            var job = Job.Default.WithToolchain(toolchain);

            if (isBaseline)
            {
                job = job.AsBaseline();
            }

            if (!enableTieredCompilation)
            {
                envVars ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                envVars["COMPLUS_TieredCompilation"] = "0";
            }

            if (envVars != null)
            {
                foreach (var (key, value) in envVars)
                {
                    job = job.WithEnvironmentVariable(key, value);
                }
            }

            AddJob(job);
        }

        // Thanks to https://github.com/GrabYourPitchforks/ConsoleApplicationBenchmark/blob/e0b0048198c856a30cacec19e3edc52c75d0677d/ConsoleAppBenchmark/Program.cs
        public void AddCustom60Toolchain(string displayName, string coreRunDirectory, bool enableTieredCompilation = true, bool isBaseline = false, Dictionary<string, string> envVars = default)
        {
            var toolchain = new CoreRunToolchain(
                coreRun: new DirectoryInfo(coreRunDirectory).GetFiles("corerun").Single(),
                targetFrameworkMoniker: "net6.0",
                displayName: displayName);

            var job = Job.Default.WithToolchain(toolchain);

            if (isBaseline)
            {
                job = job.AsBaseline();
            }

            if (!enableTieredCompilation)
            {
                envVars ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                envVars["COMPLUS_TieredCompilation"] = "0";
            }

            if (envVars != null)
            {
                foreach (var (key, value) in envVars)
                {
                    job = job.WithEnvironmentVariable(key, value);
                }
            }

            AddJob(job);
        }
    }
}
