using JwtTestAdapter;
using JwtTestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace InfrastructureTests
{
    [TestClass]
    public class InfrastructureTests : TestBase
    {
#if DEBUG
        private readonly string buildMode = "Debug";
#else
        private readonly string buildMode = "Release";
#endif

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] Checking the presence of all the necessary files in the nugget package")]
        public void NugetHaveNeedFilesTestCase()
        {
            Given("Get folder with .nupkg", () =>
            {
                var currenFolder = new DirectoryInfo(System.Environment.CurrentDirectory);
                string nugetFolderPath = Path.Combine(
                    currenFolder.Parent.Parent.Parent.Parent.Parent.FullName,
                    "NugetProject",
                    "bin",
                    buildMode);
                return new DirectoryInfo(nugetFolderPath);
            })
                .And("Get file .nupkg", nugetFolder =>
                {
                    return nugetFolder.GetFiles()
                        .Where(file => file.Name.Contains(".nupkg"))
                        .OrderBy(file => file.CreationTime)
                        .Last();
                })
                .When("Extract the contents of the package", nugetFileInfo =>
                {
                    using (FileStream nupkgStream = nugetFileInfo.OpenRead())
                    {
                        using (var archive = new ZipArchive(nupkgStream, ZipArchiveMode.Read))
                        {
                            return archive.Entries.Select(entry => entry.FullName).ToArray();
                        }
                    }
                })
                .Then("Check archive .nupkg", fileNames =>
                {
                    var files = new string[]
                    {
                        "lib/netstandard2.0/ComboPatterns.dll",
                        "lib/netstandard2.0/ComboPatterns.xml",
                        "lib/netstandard2.0/ComboPatterns.Factory.dll",
                        "lib/netstandard2.0/ComboPatterns.Factory.xml",
                        "lib/netstandard2.0/ComboPatterns.Facade.dll",
                        "lib/netstandard2.0/ComboPatterns.Facade.xml",
                        "lib/netstandard2.0/ComboPatterns.Adapter.dll",
                        "lib/netstandard2.0/ComboPatterns.Adapter.xml",
                        "LICENSE-2.0.txt"
                    };

                    foreach (string file in files)
                        Assert.IsTrue(fileNames.Any(fileFullName => fileFullName == file), $"The archive does not contain a file {file}");
                });
        }

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] Check for all attribute Timeout tests")]
        public void AllHaveTimeoutTestCase()
        {
            List<string> assemblyPaths = new List<string>
            {
                @"..\..\..\..\..\Factory\ComboPatterns.FactoryTests\bin\" + buildMode + @"\netcoreapp3.0\ComboPatterns.FactoryTests.dll",
                @"..\..\..\..\..\Facade\ComboPatterns.FacadeTests\bin\" + buildMode + @"\netcoreapp3.0\ComboPatterns.FacadeTests.dll",
                @"..\..\..\..\..\Adapter\ComboPatterns.AdapterTests\bin\" + buildMode + @"\netcoreapp3.0\ComboPatterns.AdapterTests.dll",
                @"InfrastructureTests.dll",
            };

            Given("We get all the test builds", () => assemblyPaths.ConvertAll(name => Assembly.LoadFrom(name)))
                .And("We get all types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()).ToList())
                .And("Get all classes with tests", types => types.Where(type => type.GetCustomAttribute(typeof(TestClassAttribute)) != null).ToList())
                .When("Return all test methods", classes =>
                {
                    List<MemberInfo> result = new List<MemberInfo>();

                    foreach (var cl in classes)
                    {
                        foreach (var method in cl.GetMethods().Where(method => method.GetCustomAttribute(typeof(TestMethodAttribute)) != null))
                        {
                            result.Add(method);
                            LoggingHelper.Info($"test method {cl.FullName}.{method.Name}()");
                        }
                    }

                    return result;
                })
                .Then("Check timeouts", methods =>
                {
                    foreach (var method in methods)
                    {
                        if (method.GetCustomAttribute(typeof(TimeoutAttribute)) == null)
                            Assert.Fail($"method {method.DeclaringType.FullName}.{method.Name} does not have an TimeoutAttribute");
                    }
                });
        }

        [Timeout(Timeouts.Minute.One)]
        [TestMethod]
        [Description("[infrastructure] All namespaces start with GetcuReone.ComboPatterns")]
        public void AllNamespacesStartWithGetcuReoneTestCase()
        {
            string beginNamespace = "GetcuReone.ComboPatterns";
            string rootNameAssemblies = "ComboPatterns";

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {rootNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(rootNameAssemblies)))
                .And("exclude auxiliary assemblies", files =>
                {
                    var result = new List<FileInfo>();

                    foreach (FileInfo file in files)
                    {
                        if (!file.FullName.Contains("Tests.dll"))
                        {
                            LoggingHelper.Info($"file {file.FullName}");
                            result.Add(file);
                        }
                    }

                    return result;
                })
                .And("Get assembly infos", files => files.ConvertAll(file => Assembly.LoadFrom(file.FullName)))
                .When("Get types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()))
                .Then("Check types", types =>
                {
                    var invalidTypes = new List<Type>();

                    foreach (Type type in types)
                    {
                        if (type.FullName.Length <= beginNamespace.Length)
                            invalidTypes.Add(type);
                        else if (!type.FullName.Substring(0, beginNamespace.Length).Equals(beginNamespace, StringComparison.Ordinal))
                            invalidTypes.Add(type);
                    }

                    if (invalidTypes.Count != 0)
                    {
                        Assert.Fail($"Invalid types: \n{string.Join("\n", invalidTypes.ConvertAll(type => type.FullName))}");
                    }
                });
        }
    }
}
