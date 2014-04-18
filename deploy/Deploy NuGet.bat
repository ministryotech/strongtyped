call ../../set-nuget-key.bat

del *.nupkg

nuget pack ../Ministry.StrongTyped/Ministry.StrongTyped.csproj -Prop Configuration=Release
nuget push *.nupkg

pause