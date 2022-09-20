namespace Helium.Build;

using System;
using System.Diagnostics;
using System.IO;

using static Program;

internal static class Serialization
{
    public static Int32 Build(String[] args)
    {
        Process p;

        switch(args)
        {
            case ["setup"]:

                p = Process.Start(Shell, $"./build/setup.{ScriptFileEnding}");
                p.WaitForExit();
                return p.ExitCode;

            case ["clean"]:

                p = Process.Start(Shell, $"./build/clean.{ScriptFileEnding}");
                p.WaitForExit();
                return p.ExitCode;

            case ["dotnet"]:

                p = Process.Start("dotnet", "pack -o ./out -p:SymbolPackageFormat=snupkg --include-symbols --include-source --no-dependencies");
                p.WaitForExit();
                return p.ExitCode;

            case ["dotnet", "castle"] or ["dotnet-castle"] or ["dotnet_castle"]:

                p = Process.Start("dotnet", "pack -o ./out src/csharp/Helium.Serialization.Castle -p:SymbolPackageFormat=snupkg --include-symbols --include-source --no-dependencies");
                p.WaitForExit();
                return p.ExitCode;

            case ["dotnet", "nbt"] or ["dotnet-nbt"] or ["dotnet_nbt"]:

                p = Process.Start("dotnet", "pack -o ./out src/csharp/Helium.Serialization.Nbt -p:SymbolPackageFormat=snupkg --include-symbols --include-source --no-dependencies");
                p.WaitForExit();
                return p.ExitCode;

            case ["c"]:

                p = Process.Start(Shell, $"./build/c-castle.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumccastle.so {String.Join(' ', Directory.GetFiles("./obj/c", "castle_*.o"))}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(Shell, $"./build/c-nbt.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcnbt.so {String.Join(' ', Directory.GetFiles("./obj/c", "build_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            case ["c", "castle"] or ["c-castle"] or ["c_castle"]:

                p = Process.Start(Shell, $"./build/c-castle.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumccastle.so {String.Join(' ', Directory.GetFiles("./obj/c", "castle_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            case ["c", "nbt"] or ["c-nbt"] or ["c_nbt"]:

                p = Process.Start(Shell, $"./build/c-nbt.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcnbt.so {String.Join(' ', Directory.GetFiles("./obj/c", "build_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            case ["cpp"]:

                p = Process.Start(Shell, $"./build/cpp-castle.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcppcastle.so {String.Join(' ', Directory.GetFiles("./obj/cpp", "castle_*.o"))}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(Shell, $"./build/cpp-nbt.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcppnbt.so {String.Join(' ', Directory.GetFiles("./obj/cpp", "build_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            case ["cpp", "castle"] or ["cpp-castle"] or ["cpp_castle"]:

                p = Process.Start(Shell, $"./build/cpp-castle.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcppcastle.so {String.Join(' ', Directory.GetFiles("./obj/cpp", "castle_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            case ["cpp", "nbt"] or ["cpp-nbt"] or ["cpp_nbt"]:

                p = Process.Start(Shell, $"./build/cpp-nbt.{ScriptFileEnding}");
                p.WaitForExit();

                if(p.ExitCode != 0)
                {
                    return p.ExitCode;
                }

                p = Process.Start(CCompiler, $"-shared -o ./out/libheliumcppnbt.so {String.Join(' ', Directory.GetFiles("./obj/cpp", "build_*.o"))}");
                p.WaitForExit();
                return p.ExitCode;

            default:

                return 1;
        }
    }
}
