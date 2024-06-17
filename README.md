## Service Fabric Client Library for .NET and PowerShell module
REST based Client library and PowerShell module for managing Service Fabric clusters and applications.

This repo builds the following nuget packages and powershell modules:
 - Nuget package: Microsoft.ServiceFabric.Client.Http ([nuget.org link](https://www.nuget.org/packages/Microsoft.ServiceFabric.Client.Http/))
 - Powershell Module: Microsoft.ServiceFabric.Powershell.Http ([PowerShell Gallery link](https://www.powershellgallery.com/packages/Microsoft.ServiceFabric.Powershell.Http))

For more Service Fabric open source projects, visit the Service Fabric [home repo](https://github.com/Microsoft/service-fabric).

## Getting Started

### Prerequesites
Each project is a normal C# Visual Studio 2022 project. At minimum, you need [MSBuild 17](https://learn.microsoft.com/en-us/visualstudio/msbuild/whats-new-msbuild-17-0?view=vs-2022), [PowerShell](https://msdn.microsoft.com/powershell/mt173057.aspx), [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) and [.NET Framework 4.6](https://www.microsoft.com/en-US/download/details.aspx?id=48130) to build and generate NuGet packages.

We recommend installing [Visual Studio 2022](https://www.visualstudio.com/vs/) which will set you up with all the .NET build tools and allow you to open the solution files. Community Edition is free and can be used to build everything here.

### Build
To build everything and generate NuGet packages, run the **build.ps1** script. NuGet packages and PowerShell module will be dropped in a *drop* directory at the repo root.

Each project can also be built individually directly through Visual Studio or by running the solution file through MSBuild.

For branches, please see [Branching Information](CONTRIBUTING.md#BranchingInformation)

## Releases and Support
Official releases from Microsoft of the NuGet packages in this repo are released directly to NuGet.org.

**Only officially released NuGet packages from Microsoft are supported.** If you have a feature or bug fix that you would like to use in your application, please issue a pull request so we can get it into an official release.

## Contributing code
If you would like to become an active contributor to this project please
follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines.html).

For details on contributing to Service Fabric projects, please refer to [Contributing.md](https://github.com/Microsoft/service-fabric/blob/master/CONTRIBUTING.md) at the Service Fabric home repo for details on contributing code.

## Documentation
Service Fabric has conceptual and reference documentation available at [https://docs.microsoft.com/azure/service-fabric](https://docs.microsoft.com/azure/service-fabric).

#### [Client Library Usage](docs/ClientLibraryUsage.md)
#### [Microsoft.ServiceFabric.Powershell.Http Powershell Module usage](docs/SFPowershellUsage.md)
