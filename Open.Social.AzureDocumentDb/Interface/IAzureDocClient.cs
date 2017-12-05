using Microsoft.Azure.Documents.Client;

namespace Open.Social.AzureDocumentDb.Interface
{
    public interface IAzureDocClient
    {
        DocumentClient Client { get; }
        void InitializeClient();
    }
}