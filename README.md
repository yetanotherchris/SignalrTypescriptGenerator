[![Nuget.org](https://img.shields.io/nuget/v/SignalrTypescriptGenerator.svg?style=flat)](https://www.nuget.org/packages/SignalrTypescriptGenerator)

# SignalrTypescriptGenerator
A command line tool for generating typescript definitions for Signalr

This tool is based off this gist: https://gist.github.com/robfe/4583549. It works using the same C# logic, but skips the need for a T4 template which can be fiddly to get working on build servers.

### Nuget

    install-package SignalrTypescriptGenerator

### Usage

    .\SignalrTypescriptGenerator.exe "c:\etc\path-to-myassembly.dll"

This will print the Typescript to the console window, so you can pipe SignalrTypescriptGenerator.exe to a text file if needed:

    .\SignalrTypescriptGenerator.exe "c:\etc\path-to-myassembly.dll" > Hubs.ts
    
A post-build command line in Visual Studio might look like this:

    $(SolutionDir)\packages\SignalrTypescriptGenerator.1.0.8\tools\SignalrTypescriptGenerator.exe "$(TargetPath)" > "$(SolutionDir)src\MyProject.Web\Scripts\typings\Hubs.d.ts"


