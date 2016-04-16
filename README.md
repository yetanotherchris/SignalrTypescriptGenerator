[![Nuget.org](https://img.shields.io/nuget/v/SignalrTypescriptGenerator.svg?style=flat)](https://www.nuget.org/packages/SignalrTypescriptGenerator)

# SignalrTypescriptGenerator
A command line tool for generating typescript definitions for Signalr

This tool is based off this gist: https://gist.github.com/robfe/4583549. It works using the same C# logic, but skips the need for a T4 template which can be fiddly to get working on build servers.

### Nuget

    install-package SignalrTypescriptGenerator

### Usage

    .\SignalrTypescriptGenerator.exe -a "c:\etc\path-to-myassembly.dll"

This will print the Typescript to the console window. You can write to a file, which automatically checks if the file has changed:

    .\SignalrTypescriptGenerator.exe -a "c:\etc\path-to-myassembly.dll" -o "C:\temp\.myfile.d.ts"

If you don't specify an output file, the typescript output is written to the console window. A post-build command line in Visual Studio might look like this:

    $(SolutionDir)\packages\SignalrTypescriptGenerator.1.0.10\tools\SignalrTypescriptGenerator.exe -a "$(TargetPath)" -o "$(SolutionDir)src\MyProject.Web\Scripts\typings\Hubs.d.ts"