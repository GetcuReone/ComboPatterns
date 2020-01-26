using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.IO.Compression;
using System.Linq;

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
                        "LICENSE-2.0.txt"
                    };

                    foreach (string file in files)
                        Assert.IsTrue(fileNames.Any(fileFullName => fileFullName == file), $"The archive does not contain a file {file}");
                });
        }
    }
}
