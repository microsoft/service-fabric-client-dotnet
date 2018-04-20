## Service Fabric Client Library for .NET
Client library for managing Service Fabric clusters and applications.

This repo builds the following packages:
 - Microsoft.ServiceFabric.Client.http

For more Service Fabric open source projects, visit the Service Fabric [home repo](https://github.com/Microsoft/service-fabric).

## Getting Started

### Prerequesites
Each project is a normal C# Visual Studio 2017 project. At minimum, you need [MSBuild 15](https://docs.microsoft.com/en-us/visualstudio/msbuild/what-s-new-in-msbuild-15-0), [PowerShell](https://msdn.microsoft.com/powershell/mt173057.aspx), [.NET Core SDK](https://www.microsoft.com/net/download/windows) and [.NET Framework 4.6](https://www.microsoft.com/en-US/download/details.aspx?id=48130) to build and generate NuGet packages.

We recommend installing [Visual Studio 2017](https://www.visualstudio.com/vs/) which will set you up with all the .NET build tools and allow you to open the solution files. Community Edition is free and can be used to build everything here.

### Build
To build everything and generate NuGet packages, run the **build.ps1** script. NuGet packages will be dropped in a *drop* directory at the repo root.

Each project can also be built individually directly through Visual Studio or by running the solution file through MSBuild.

Binaries in the build are delay signed, these are fully signed in the official builds released by Microsoft. To use the binaries or to run unit tests from the build of this repository, strong name validation needs to be skipped for these assemblies. This can be done by running **SkipStrongName.ps1** script available in the root of the repository.

## Releases and Support
Official releases from Microsoft of the NuGet packages in this repo are released directly to NuGet.org.

**Only officially released NuGet packages from Microsoft are supported for use in production.** If you have a feature or bug fix that you would like to use in your application, please issue a pull request so we can get t into an official release.

## Documentation
Service Fabric has conceptual and reference documentation available at [https://docs.microsoft.com/azure/service-fabric](https://docs.microsoft.com/azure/service-fabric).

### Using the Client Library
#### Connecting to unsecured cluster
```
// create client
var clusterUrl = new Uri(@"http:<luster_fqdn>19080");
var sfClient = ServiceFabricClientFactory.Create(clusterUrl);
```

#### Connecting to cluster secured with X509 certificate
```
// create client using security settings
var clusterUrl = new Uri(@"http:<luster_fqdn>19080");
var settings = new ClientSettings(GetSecurityCredentials);
var sfClient = ServiceFabricClientFactory.Create(clusterUrl, settings);

public static X509SecuritySettings GetSecurityCredentials()
{
  var clientCert = new System.Security.Cryptography.X509Certificates.X509Certificate("<Path to .pfx file>", "password");
  var remoteSecuritySettings = new RemoteX509SecuritySettings(new List<string> { "server_cert_thumbprint" });
  return new X509SecuritySettings(clientCert, remoteSecuritySettings);
}

```

#### Performing operations
Once you have connected to cluster as mentioned, you can perform various management operations as shown below:

```
// get cluster manifest and health
var manifest = await sfClient.Cluster.GetClusterManifestAsync();
var health = await sfClient.Cluster.GetClusterHealthAsync();

// upload, provision and create application
await sfClient.Applications.UploadApplicationPackageAsync("Path_To_Application_Package", applicationPackagePathInImageStore:"TestApp");

await sfClient.ApplicationTypes.ProvisionApplicationTypeAsync(new ProvisionApplicationTypeDescription("TestApp"));

var appParams = new Dictionary<string, string>();
appParams.Add("Parameter1", "1");
var appDesc = new ApplicationDescription(new ApplicationName("fabric:/ApplicationFromLib"), "ApplicationType", "1.0.0", appParams);
await sfClient.Applications.CreateApplicationAsync(appDesc);

// get partition information
var partition = await sfClient.Partitions.GetPartitionInfoAsync(new Guid("8b8c58e6-f18a-477c-8b8d-87123f754b72"));

```
