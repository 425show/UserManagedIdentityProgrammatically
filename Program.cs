// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;
using Models;


var resourceGroupName = "your resource group name";
var managedIdentityName = "your managed identity name";
var subscriptionId = "your Azure Subscription Id";
var tenantId= "your Azure AD Tenant Id";
var region = "west-us";


var credentials = new DefaultAzureCredential();
var servCreds = new AzureIdentityCredentialAdapter(credentials);
var client = new ManagedServiceIdentityClient(servCreds);
client.SubscriptionId = subscriptionId;

var newUserAssignedIdentity = await client.UserAssignedIdentities.CreateOrUpdateAsync(
    resourceGroupName: resourceGroupName,
    resourceName: managedIdentityName,
    new Identity(
        location: region,
        tenantId:new Guid(tenantId)
        
    )
);

//retrieve the managed identity
var uai = await client.UserAssignedIdentities.GetAsync("identity", "my-managed-identity");

// display the client id
Console.WriteLine($"User assigned identity: {uai.ClientId}");