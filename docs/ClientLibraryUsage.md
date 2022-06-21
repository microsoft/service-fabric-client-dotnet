## Microsoft.ServiceFabric.Client.Http

## Client Library nuget package version and Service Fabric Runtime Compatibility
### Stable releases
Nuget Package Version | Compatible Service Fabric Runtime version
-|-
4.7.* | >= 9.0
4.6.* | >= 8.2
4.5.* | >= 8.1
4.4.* | >= 8.0
4.2.* | >= 7.2
4.1.* | >= 7.1
4.0.* | >= 7.0
3.0.* | >= 6.5

### Preview releases
Nuget Package Version | Compatible Service Fabric Runtime version
-|-
3.0.0-preview* | >= 6.5
3.0.0-preview* | >= 6.5
2.0.0-preview* | >= 6.4
1.0.0-preview59 - 1.0.0-preview61 | >=6.3
1.0.0-preview58 | >=6.2


## Using the Client Library
### Connecting to unsecured cluster
```csharp
// create client
var sfClient = new ServiceFabricClientBuilder()
                .UseEndpoints(new Uri(@"http://<cluster_fqdn>:19080"))
                .BuildAsync().GetAwaiter().GetResult();
```

### Connecting to cluster secured with X509 certificate
Certificate information must be provided when connecting to a secured cluster from within the cluster or outside the cluster.
```csharp
// create client using ServiceFabricClientBuilder.UseX509Security
var sfClient = new ServiceFabricClientBuilder()
                .UseEndpoints(new Uri(@"http://<cluster_fqdn>:19080"))
                .UseX509Security(GetSecurityCredentials)
                .BuildAsync().GetAwaiter().GetResult();

Func<CancellationToken, Task<SecuritySettings>> GetSecurityCredentials = (ct) =>
{
    // get the X509Certificate2 either from Certificate store or from file.
    var clientCert = new System.Security.Cryptography.X509Certificates.X509Certificate2("<Path to .pfx file>", "password");
    var remoteSecuritySettings = new RemoteX509SecuritySettings(new List<string> { "server_cert_thumbprint" });
    return Task.FromResult<SecuritySettings>(new X509SecuritySettings(clientCert, remoteSecuritySettings));
};
```

#### Handling multiple issuer thumbprints
You can specify a comma delimited list as the issuerCertThumbprint for a RemoteX509SecuritySettings object to check against multiple issuers.

### Connecting to cluster secured with Azure Active Directory
There are different ways to connect to the cluster secured with Azure Active Directory depending on if you have the AAD metadata(authority, resource, clientId) to get the token from Azure Active Directory. If you have the AAD metadata, use the option 1 below, if you don't have the AAD metadata, use the option 2 below.
#### 1. You have the AAD metadata to get the token from Azure Active Directory.
If you have the AAD metadata(authority, resource, client id) to get the token from Azure Active Directory, you can use it directly to get the token as shown below.
```csharp
// create client using ServiceFabricClientBuilder.UseAzureActiveDirectorySecurity
var sfClient = new ServiceFabricClientBuilder()
                .UseEndpoints(new Uri(@"http://<cluster_fqdn>:19080"))
                .UseAzureActiveDirectorySecurity(GetSecurityCredentials)
                .BuildAsync().GetAwaiter().GetResult();

Func<CancellationToken, Task<SecuritySettings>> GetSecurityCredentials = (ct) =>
{
    var token = GetAccessTokenAsync(ct).GetAwaiter().GetResult();    
    var remoteSecuritySettings = new RemoteX509SecuritySettings(new List<string> { "server_cert_thumbprint" });
    return Task.FromResult<SecuritySettings>(new AzureActiveDirectorySecuritySettings(token, remoteSecuritySettings));
};

public static async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
{
    // get token from azure active directory using Active Directory APIs
    var authority = @"https://login.microsoftonline.com/" + "tenant_Id";
    var authContext = new AuthenticationContext(authority);
    var authResult = await authContext.AcquireTokenAsync("resource_Id", "client_Id", new UserCredential());
    return authResult.AccessToken;
}
```
#### 2. You don't have the AAD metadata to get the token from Azure Active Directory.
If you don't have the AAD metadata(authority, resource, client id) to get the token from Azure Active Directory, you can provide a delegate which will be invoked with AAD metadata fetched from the cluster. This approach is shown in the code below:

```csharp
// create client using ServiceFabricClientBuilder.UseAzureActiveDirectorySecurity
var sfClient = new ServiceFabricClientBuilder()
                .UseEndpoints(new Uri(@"http://<cluster_fqdn>:19080"))
                .UseAzureActiveDirectorySecurity(GetSecurityCredentials)
                .BuildAsync().GetAwaiter().GetResult();

Func<CancellationToken, Task<SecuritySettings>> GetSecurityCredentials = (ct) =>
{
    var remoteSecuritySettings = new RemoteX509SecuritySettings(new List<string> { "server_cert_thumbprint" });
    return Task.FromResult<SecuritySettings>(new AzureActiveDirectorySecuritySettings(GetAccessTokenAsync, remoteSecuritySettings));
};

public static async Task<string> GetAccessTokenAsync(AadMetadata aad, CancellationToken cancellationToken)
{
    // get token from azure active directory using Active Directory APIs
    var authContext = new AuthenticationContext(aad.Authority);
    var authResult = await authContext.AcquireTokenAsync(aad.Cluster, aad.Client, new UserCredential());
    return authResult.AccessToken;
}

```


APIs in this client library are categorized into following categories (available ```interface  IServiceFabricClient```) (can be accessed using the ```sfClient``` instance created with aboove code snippet):
* Applications
* ApplicationTypes
* BackupRestore
* ChaosClient
* CodePackages
* Cluster
* ComposeDeployments
* Faults
* ImageStore
* Infrastructure
* Partitions
* Nodes
* Replicas
* Properties
* Repairs
* Services
* ServicePackages
* ServiceTypes
* EventsStore

### Performing operations
Once you have connected to cluster as mentioned, you can perform various management operations as shown below:

```csharp
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
