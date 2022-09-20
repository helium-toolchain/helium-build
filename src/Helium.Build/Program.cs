namespace Helium.Build;

using System;
using System.IO;

using Spectre.Console;

internal class Program
{
    public static String CCompiler => OperatingSystem.IsWindows() ? "clang" : "gcc";

    public static String Shell => OperatingSystem.IsWindows() ? "powershell" : "bash";

    public static String ScriptFileEnding => OperatingSystem.IsWindows() ? "ps1" : "sh";

    public static Int32 Main(String[] args)
    {
        if(!File.Exists("./.helium-build"))
        {
            AnsiConsole.MarkupLine("[red][[Error:]][/] There was no .helium-build file in the current directory. " +
                "Please supply a build file.");
        }

        return File.ReadAllText("./.helium-build").Split(' ') switch
        {
            ["serialization", ..] => Serialization.Build(args),
            _ => 1
        };
    }
}
