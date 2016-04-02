# This could be automated via appveyor
$version = Read-Host "What is the version number?"
$apikey = Read-Host "Enter a nuget.org API key"

nuget pack .\SignalrTypescriptGenerator.nuspec  -Prop Configuration=Release -Version $version
nuget push ".\SignalrTypescriptGenerator.$version.nupkg" $apikey