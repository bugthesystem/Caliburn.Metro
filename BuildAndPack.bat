SET MsBuildPath=C:\Windows\Microsoft.NET\Framework64\v4.0.30319
SET NuGetExe=.nuget\nuget.exe
%MsBuildPath%\MsBuild.exe build.proj

.nuget\NuGet.exe pack Caliburn.Metro\Caliburn.Metro.nuspec
.nuget\NuGet.exe pack Caliburn.Metro.Autofac\Caliburn.Metro.Autofac.nuspec