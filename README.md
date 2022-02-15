## Summary
This little source code shows how to create a User Assigned Managed Identity for Azure using the Azure Management SDK

## Requirements
- An Azure Subscription
- An Azure AD

## Caveats
This library ([Source Code](https://github.com/Azure/azure-sdk-for-net/tree/Microsoft.Azure.Management.ManagedServiceIdentity_1.0.0/sdk/managedserviceidentity/Microsoft.Azure.Management.ManagedServiceIdentity/src)),
is slightly older and is pending updates. Therefore, this should be used as a stop gap to allow you to work with Azure.
The older library relies on Microsoft.Rest and authentication is a bit complex. Ideally we want to be able to use the Azure.Identity library to authenticate against Azure.
The workaround is to use a shim that converts the Azure.Identity `TokenCredential` to something that the management library understands

## NuGet Packages
Open your favorite tool and install the following NuGet packages
```
dotnet add package Azure.Identity
dotnet add Microsoft.Azure.Management.ManagedServiceIdentity
```

## Authentication

```
using Azure.Identity;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;

var credentials = new DefaultAzureCredential();
var servCreds = new AzureIdentityCredentialAdapter(credentials);
var client = new ManagedServiceIdentityClient(servCreds);
client.SubscriptionId = subscriptionId;
```

## Using the management SDK
With the client instance authenticated, we can now interact with the service. An example code snippet that creates a Managed Identity is provided below

```
var newUserAssignedIdentity = await client.UserAssignedIdentities.CreateOrUpdateAsync(
    resourceGroupName: resourceGroupName,
    resourceName: managedIdentityName,
    new Identity(
        location: region,
        tenantId:new Guid(tenantId)
        
    )
);
```
