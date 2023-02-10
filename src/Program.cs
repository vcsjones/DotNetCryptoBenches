using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CoreRun;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Reports;

namespace NetCryptoBench
{
    class Program
    {
        static void Main(string[] args)
        {
#if !RELEASE
            Console.WriteLine("Run this again in release mode.");
            return;
#endif
            string basePath;
            string flavor;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                basePath = "/Users/vcsjones/Projects";
                flavor = "net8.0-OSX-Release-arm64";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                basePath = "/code/personal/dotnet";
                flavor = "net8.0-Linux-Release-x64";
            }
            else
            {
                Console.WriteLine("Where's your code, Kevin?");
                return;
            }


            var config = new LocalCoreClrConfig();

            config.AddCustom80Toolchain(
                displayName: "main",
                coreRunDirectory: Path.Join(basePath, "/runtime-main/artifacts/bin/testhost/", flavor, "/shared/Microsoft.NETCore.App/8.0.0/"),
                isBaseline: true);

            config.AddCustom80Toolchain(
                displayName: "branch",
                coreRunDirectory: Path.Join(basePath, "/runtime/artifacts/bin/testhost/", flavor, "/shared/Microsoft.NETCore.App/8.0.0/"));

            config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
            config.AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
            config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
            config.AddDiagnoser(MemoryDiagnoser.Default);
            config.SummaryStyle = SummaryStyle.Default.WithMaxParameterColumnWidth(2000);
            BenchmarkSwitcher.FromTypes(new[] {
                typeof(ECDsaBench),
                typeof(ECDsaKeyGenBench),
                typeof(ECDsaImportExportBench),
                typeof(RSABench),
                typeof(RSAKeyGenBench),
                typeof(AesTransformBench),
                typeof(StaticHashBench),
                typeof(ShaBench),
                typeof(CbcOneShot),
                typeof(EcbOneShot),
                typeof(CfbOneShot),
                typeof(Asn1SetOf),
                typeof(AsnWritingStuff),
                }).Run(args, config);
        }

    }

    public class LocalCoreClrConfig : ManualConfig
    {
        // Thanks to https://github.com/GrabYourPitchforks/ConsoleApplicationBenchmark/blob/e0b0048198c856a30cacec19e3edc52c75d0677d/ConsoleAppBenchmark/Program.cs
        public void AddCustom70Toolchain(string displayName, string coreRunDirectory, bool enableTieredCompilation = true, bool isBaseline = false, Dictionary<string, string> envVars = default)
        {
            var toolchain = new CoreRunToolchain(
                coreRun: new DirectoryInfo(coreRunDirectory).GetFiles("corerun").Single(),
                targetFrameworkMoniker: "net7.0",
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
        public void AddCustom80Toolchain(string displayName, string coreRunDirectory, bool enableTieredCompilation = true, bool isBaseline = false, Dictionary<string, string> envVars = default)
        {
            var toolchain = new CoreRunToolchain(
                coreRun: new DirectoryInfo(coreRunDirectory).GetFiles("corerun").Single(),
                targetFrameworkMoniker: "net8.0",
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
