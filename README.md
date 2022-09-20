# helium-build

build tool for all helium projects

instructions for self-building:
- run `dotnet publish -c Release -r [win|linux]-[x|arm]64` (you'll have to know whether you're using windows or linux, and whether your machine is a xarch machine or an aarch machine)
- go to `src/Helium.Build/bin/Release/net7.0/[your runtime identifier here]/native
- take the executable out, rename it whatever you want, put it in your `PATH`
