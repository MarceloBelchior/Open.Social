using System;
using Microsoft.Azure.Documents.Client;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.Core.Model.config;

namespace Open.Social.AzureDocumentDb
{
    public class AzureDocClient : IAzureDocClient
    {
        private DocumentClient _client;
        private readonly DocumentDbConfig _documentDbConfig;

        public AzureDocClient(DocumentDbConfig documentDbConfig)
        {
            _documentDbConfig = documentDbConfig;
        }

        public DocumentClient Client => _client;

        #region Initialization Methods

        public void InitializeClient()
        {
            if (_client != null) return;
            _client = new DocumentClient(new Uri(_documentDbConfig.Endpoint), _documentDbConfig.Key);
        }

        #endregion
    }
}
