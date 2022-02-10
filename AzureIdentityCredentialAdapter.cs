using Microsoft.Rest;
using Azure.Core;

namespace Models
{
    public class AzureIdentityCredentialAdapter : TokenCredentials
    {
        public AzureIdentityCredentialAdapter(string[] scopes = null) : base(new AzureIdentityTokenProvider(scopes))
        {
        }

        public AzureIdentityCredentialAdapter(TokenCredential tokenCredential, string[] scopes = null) : base(new AzureIdentityTokenProvider(tokenCredential, scopes))
        {

        }
    }
}