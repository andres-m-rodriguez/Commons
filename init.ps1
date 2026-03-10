$name = Split-Path -Leaf (Get-Location)
dotnet new sln -n $name
Get-ChildItem -Path src -Filter *.csproj -Recurse | ForEach-Object { dotnet sln add $_.FullName }
Remove-Item $MyInvocation.MyCommand.Source
