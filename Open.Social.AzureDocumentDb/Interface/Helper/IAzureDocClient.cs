using Microsoft.Azure.Documents.Client;

namespace Open.Social.AzureDocumentDb.Interface.Helper
{
    public interface IAzureDocClient
    {
        DocumentClient Client { get; }
        void InitializeClient();
    }
}