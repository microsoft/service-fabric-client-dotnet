## Using the Client Library
### Connecting to unsecured cluster
```csharp
// create client
var clusterUrl = new Uri(@"https://<cluster_fqdn>:19080");
var sfClient = ServiceFabricClientFactory.Create(clusterUrl);
```

### Connecting to cluster secured with X509 certificate
```csharp
// create client using security settings
var clusterUrl = new Uri(@"https://<cluster_fqdn>:19080");
var settings = new ClientSettings(GetSecurityCredentials);
var sfClient = ServiceFabricClientFactory.Create(clusterUrl, settings);

public static X509SecuritySettings GetSecurityCredentials()
{
    // get the X509Certificate either from Certificate store or from file.
    var clientCert = new System.Security.Cryptography.X509Certificates.X509Certificate("<Path to .pfx file>", "password");
    var remoteSecuritySettings = new RemoteX509SecuritySettings(new List<string> { "server_cert_thumbprint" });
    return new X509SecuritySettings(clientCert, remoteSecuritySettings);
}

```

### Connecting to cluster secured with Azure Active Directory
```csharp
// create client using security settings
var clusterUrl = new Uri(@"http:<luster_fqdn>19080");
var settings = new ClientSettings(GetSecurityCredentials);
var sfClient = ServiceFabricClientFactory.Create(clusterUrl, settings);

static ClaimsSecuritySettings GetSecurityCredentials()
{
    var token = GetAccessToken();
    var remoteCertSettings = new RemoteX509SecuritySettings(new List<string>() { "server_cert_thumbprint" });
    return new ClaimsSecuritySettings(token, remoteCertSettings);
}

static string GetAccessToken()
{
    // get token from azure active directory using Active Directory APIs
    var authorityFormat = @"https://login.microsoftonline.com/{0}";
    var authority = string.Format(authorityFormat, "your_tenant_id");
    var authContext = new AuthenticationContext(authority);
    var authResult = authContext.AcquireTokenAsync("resource_id", "client_Id", new UserCredential("userName")).GetAwaiter().GetResult();
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
