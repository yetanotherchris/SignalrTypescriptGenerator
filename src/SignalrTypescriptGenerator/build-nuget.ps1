# This could be automated via appveyor
Write-Host "Make sure you have updated the assemblyinfo file and compiled in release mode first."
$version = Read-Host "What is the version number?"
$apikey = Read-Host "Enter a nuget.org API key"

nuget pack .\SignalrTypescriptGenerator.nuspec  -Prop Configuration=Release -Version $version
nuget push ".\SignalrTypescriptGenerator.$version.nupkg" $apikey -Source https://www.nuget.org/api/v2/package