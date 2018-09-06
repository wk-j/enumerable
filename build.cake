#addin "wk.StartProcess";

using PS = StartProcess.Processor;

Task("Run").Does(() => {
    PS.StartProcess("dotnet run --project src/EnumerableCast/EnumerableCast.csproj -c Release");
});

var target = Argument("Target", "Default");
RunTarget(target);