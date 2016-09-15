[![Build status](https://ci.appveyor.com/api/projects/status/uwhg9nwo62kx2fif?svg=true)](https://ci.appveyor.com/project/cjbhaines/signalr-hubs-typescriptgenerator)

# Signalr.Hubs.TypescriptGenerator
Utility library for generating typescript definitions for Signalr Hubs. This is a fork of [https://github.com/yetanotherchris/SignalrTypescriptGenerator](https://github.com/yetanotherchris/SignalrTypescriptGenerator "SignalrTypescriptGenerator") by [https://github.com/yetanotherchris](https://github.com/yetanotherchris "yetanotherchris"). I have split the packages up into a referenced library and a console app.

Our usage at Genius Sports is to generate the Hub proxies at build time using our [https://github.com/geniussportsgroup/SignalR.ProxyGenerator](https://github.com/geniussportsgroup/SignalR.ProxyGenerator "Proxy Generator") publishing them to our internal NPM feed. We then use this tool to generate TypeScript definitions our those proxies again publishing them to our internal NPM feed. This allows our UI developers to get strongly typed Hub APIs and allows us to do proper Continous Integrtaion between the back end and front end. Move quickly and break fast.


## Installation - Nuget

- [Signalr.Hubs.TypescriptGenerator](https://www.nuget.org/packages/Signalr.Hubs.TypescriptGenerator "Signalr.Hubs.TypeScriptGenerator")
- [Signalr.Hubs.TypescriptGenerator.Console](https://www.nuget.org/packages/Signalr.Hubs.TypescriptGenerator.Console "Signalr.Hubs.TypeScriptGenerator.Console")

## Usage

### Signalr.Hubs.TypescriptGenerator
The utility library is simple to use, load any assemblies required and then create a HubTypeScriptGenerator and call Generate. It returns the TypeScript as a string. We can't pick a specific assembly to scan because we are using the SignalR DefaultHubManager which looks in all loaded assemblies.

	var generator = new HubTypeScriptGenerator();
	var typeScript = generator.Generate();


### Signalr.Hubs.TypescriptGenerator.Console
This will output the Typescript to the specified file path

    .\Signalr.Hubs.TypescriptGenerator.Console.exe -a "c:\etc\path-to-myassembly.dll" -o "C:\temp\.myfile.d.ts"