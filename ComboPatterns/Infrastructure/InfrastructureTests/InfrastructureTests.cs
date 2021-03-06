using GetcuReone.GwtTestFramework;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using TestCommon;

namespace InfrastructureTests
{
    [TestClass]
    public class InfrastructureTests : TestBase
    {
        private string _buildConfiguration;
        private DirectoryInfo _solutionFolder;
        private string _nugetProjectName;
        private string _projectName;
        private string _targetFramework;

        [TestInitialize]
        public void Initialize()
        {
            _buildConfiguration = Environment.GetEnvironmentVariable("buildConfiguration");
            if (string.IsNullOrEmpty(_buildConfiguration))
                _buildConfiguration = "Debug";

            _solutionFolder = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent;
            _nugetProjectName = "NugetProject";
            _projectName = "ComboPatterns";
            _targetFramework = "netstandard2.0";
        }

        [TestMethod]
        [TestCategory(TC.Infra)]
        [Description("Checking the presence of all the necessary files in the nugget package.")]
        [Timeout(Timeouts.Minute.One)]
        public void NugetHaveNeedFilesTestCase()
        {
            Given("Get folder with .nupkg", () =>
            {
                var currenFolder = new DirectoryInfo(System.Environment.CurrentDirectory);
                string nugetFolderPath = Path.Combine(
                    currenFolder.Parent.Parent.Parent.Parent.Parent.FullName,
                    _nugetProjectName,
                    "bin",
                    _buildConfiguration);
                return new DirectoryInfo(nugetFolderPath);
            })
                .And("Get file .nupkg", nugetFolder =>
                {
                    var files = nugetFolder.GetFiles();

                    return files
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
                    string libPattern = $"lib/{_targetFramework}/GetcuReone." + "{0}";
                    var files = new string[]
                    {
                        string.Format(libPattern, "ComboPatterns.dll"),
                        string.Format(libPattern, "ComboPatterns.xml"),
                        string.Format(libPattern, "ComboPatterns.Factory.dll"),
                        string.Format(libPattern, "ComboPatterns.Factory.xml"),
                        string.Format(libPattern, "ComboPatterns.Facade.dll"),
                        string.Format(libPattern, "ComboPatterns.Facade.xml"),
                        string.Format(libPattern, "ComboPatterns.Adapter.dll"),
                        string.Format(libPattern, "ComboPatterns.Adapter.xml"),
                        "LICENSE-2.0.txt",
                        "README.md",
                    };

                    Assert.AreEqual(files.Length + 4, fileNames.Length, "Expected a different number of files in the package.");

                    foreach (string file in files)
                        Assert.IsTrue(fileNames.Any(fileFullName => fileFullName == file), $"The archive does not contain a file {file}");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Infra)]
        [Description("Check for all attribute Timeout tests.")]
        [Timeout(Timeouts.Minute.One)]
        public void AllHaveTimeoutTestCase()
        {
            Given("Get all file", () => InfrastructureHelper.GetAllFiles(_solutionFolder))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Include only tests assemlies",
                    files => files
                        .Where(file => file.Name.Contains("Tests.dll")
                            && !file.FullName.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && (file.Directory.Parent.Name.Contains(_buildConfiguration) || file.Directory.Name.Contains(_buildConfiguration)))
                        .ToList())
                .And("Get assembly infos", files =>
                    files.Select(file =>
                    {
                        LoggingHelper.ConsoleInfo($"test assembly {file.FullName}");
                        return Assembly.LoadFrom(file.FullName);
                    }).ToList())
                .And("Get types", assemblies => assemblies.SelectMany(assembly => assembly.GetTypes()))
                .And("Get test classes", types => types.Where(type => type.GetCustomAttribute(typeof(TestClassAttribute)) != null))
                .When("Get test methods", typeClasses =>
                {
                    var result = new List<MemberInfo>();

                    foreach (var cl in typeClasses)
                    {
                        foreach (var method in cl.GetMethods().Where(method => method.GetCustomAttribute(typeof(TestMethodAttribute)) != null))
                        {
                            result.Add(method);
                            LoggingHelper.ConsoleInfo($"test method {cl.FullName}.{method.Name}()");
                        }
                    }

                    return result;
                })
                .Then("Check timeouts", methods =>
                {
                    List<MemberInfo> invalidMethods = methods.Where(method => method.GetCustomAttribute(typeof(TimeoutAttribute)) == null).ToList();

                    if (invalidMethods.Count != 0)
                    {
                        Assert.Fail("Methods dont have TimeoutAttribute:\n" + string.Join("\n", invalidMethods.Select(method => $"{method.DeclaringType.FullName}.{method.Name}")));
                    }
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Infra)]
        [Description("All namespaces start with GetcuReone.")]
        [Timeout(Timeouts.Minute.One)]
        public void AllNamespacesStartWithGetcuReoneTestCase()
        {
            string beginNamespace = "GetcuReone";
            string partNameAssemblies = _projectName;
            string[] excludeAssemblies = new string[]
            {
            };

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(_solutionFolder))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {partNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(partNameAssemblies)))
                .And($"Include only library assemlies",
                    files => files
                        .Where(file => file.FullName.Contains("Tests")
                            && !file.Name.Contains("Tests.dll")
                            && !file.Name.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && (file.Directory.Parent.Name.Contains(_buildConfiguration) || file.Directory.Name.Contains(_buildConfiguration))
                            && excludeAssemblies.All(ass => ass != file.Name)))
                .And($"Exclude duplicate",
                    files => files
                    .DistinctByFunc((x, y) => x.Name == y.Name)
                    .ToList())
                .And("Get assembly infos",
                    files =>
                        files.Select(file =>
                        {
                            LoggingHelper.ConsoleInfo($"test assembly {file.FullName}");
                            return Assembly.LoadFrom(file.FullName);
                        }).ToList())

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
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Infra)]
        [Description("Assemblies have major version.")]
        [Timeout(Timeouts.Minute.One)]
        public void AssembliesHaveMajorVersionTestCase()
        {
            string[] includeAssemblies = new string[]
            {
            };
            string majorVersion = Environment.GetEnvironmentVariable("majorVersion");
            string excpectedAssemblyVersion = majorVersion != null
                ? $"{majorVersion}.0.0.0"
                : "4.0.0.0";

            string partNameAssemblies = _projectName;

            Given("Get all file", () => InfrastructureHelper.GetAllFiles(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent))
                .And("Get all assemblies", files => files.Where(file => file.Name.Contains(".dll")))
                .And($"Includ only {partNameAssemblies} assemblies", files => files.Where(file => file.Name.Contains(partNameAssemblies) || includeAssemblies.Any(inAss => file.FullName.Contains(inAss))))
                .And($"Include only library assemlies",
                    files => files
                        .Where(file => file.FullName.Contains("Tests")
                            && !file.Name.Contains("Tests.dll")
                            && !file.Name.Contains("TestAdapter.dll")
                            && !file.FullName.Contains("obj")
                            && (file.Directory.Parent.Name.Contains(_buildConfiguration) || file.Directory.Name.Contains(_buildConfiguration))))
                .And($"Exclude duplicate",
                    files => files
                    .DistinctByFunc((x, y) => x.Name == y.Name)
                    .ToList())
                .When("Get assembly infos",
                    files =>
                        files.Select(file =>
                        {
                            LoggingHelper.ConsoleInfo($"test assembly {file.FullName}");
                            return Assembly.LoadFrom(file.FullName);
                        }).ToList())
                .Then("Checke assembly version", assemblies =>
                {
                    var invalidAssemblies = new List<Assembly>();

                    foreach (Assembly assembly in assemblies)
                    {
                        if (!assembly.FullName.Contains($"Version={excpectedAssemblyVersion}"))
                            invalidAssemblies.Add(assembly);

                        CustomAttributeData attr = assembly.CustomAttributes.SingleOrDefault(attr => attr.AttributeType.Name.Equals(nameof(AssemblyFileVersionAttribute), StringComparison.Ordinal));

                        if (attr == null || attr.ConstructorArguments.Count == 0 || attr.ConstructorArguments[0].Value == null)
                            invalidAssemblies.Add(assembly);
                        else if (!(attr.ConstructorArguments[0].Value is string attrStr))
                            invalidAssemblies.Add(assembly);
                        else if (!attrStr.Equals(excpectedAssemblyVersion, StringComparison.Ordinal))
                            invalidAssemblies.Add(assembly);
                    }

                    if (invalidAssemblies.Count != 0)
                    {
                        Assert.Fail($"Invalid assemblies: \n{string.Join("\n", invalidAssemblies.ConvertAll(type => type.FullName))}");
                    }
                })
                .Run();
        }
    }
}
