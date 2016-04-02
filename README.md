[![Nuget.org](https://img.shields.io/nuget/v/SignalrTypescriptGenerator.svg?style=flat)](https://www.nuget.org/packages/SignalrTypescriptGenerator)

# SignalrTypescriptGenerator
A command line tool for generating typescript definitions for Signalr

This tool is based off this gist: https://gist.github.com/robfe/4583549. It works using the same C# logic, but skips the need for a T4 template which can be fiddly to get working on build servers.

### Usage

    .\SignalrTypescriptGenerator.exe "c:\etc\path-to-myassembly.dll"

This will print the Typescript to the console window, so you can pipe SignalrTypescriptGenerator.exe to a text file if needed:

    .\SignalrTypescriptGenerator.exe "c:\etc\path-to-myassembly.dll" > Hubs.ts

### Nuget package

    install-package SignalrTypescriptGenerator
    
You can then reference SignalrTypescriptGenerator.exe from your packages folder as part of a pre-build step, or as a pre-compile step on your build server.
