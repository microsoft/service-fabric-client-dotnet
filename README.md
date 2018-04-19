
# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.


## Using the Client Library
### Connecting to unsecured cluster
```
// create client
var clusterUrl = new Uri(@"http:<luster_fqdn>19080");
var sfClient = ServiceFabricClientFactory.Create(clusterUrl);
```

### Connecting to cluster secured with X509 certificate
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

### Performing operations
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
