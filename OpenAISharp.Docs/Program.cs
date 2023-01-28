// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using XmlDocMarkdown.Core;


string GetProjectDllPath(string projectName)
    => Path.Combine(GetSolutionDirectory(), projectName, "bin", "Debug", "netstandard2.1", $"{projectName}.dll");
string GetSolutionDirectory()
    => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", ".."));

string solutionName = "OpenAISharp";
var projects = new List<string>
{
    GetProjectDllPath($"{solutionName}.Client"),
    GetProjectDllPath($"{solutionName}.Completion"),
    GetProjectDllPath($"{solutionName}.Edit"),
    GetProjectDllPath($"{solutionName}.Embedding"),
    GetProjectDllPath($"{solutionName}.File"),
    GetProjectDllPath($"{solutionName}.FineTune"),
    GetProjectDllPath($"{solutionName}.Image"),
    GetProjectDllPath($"{solutionName}.Model"),
    GetProjectDllPath($"{solutionName}.Moderation"),
    GetProjectDllPath($"{solutionName}.Utilities"),
};

var outputPath = Path.Combine(GetSolutionDirectory(), "Docs");
var results = new List<XmlDocMarkdownResult>();
foreach (var path in projects)
    results.Add(XmlDocMarkdownGenerator.Generate(path, outputPath, new XmlDocMarkdownSettings { VisibilityLevel = XmlDocVisibilityLevel.Public, ShouldClean = true }));

Console.WriteLine(JsonSerializer.Serialize(results));
Console.WriteLine($"{solutionName} documentation generated.");