using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.Core.Model.config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb
{
    public class AzureDocDatabase : IAzureDocDatabase
    {
        private readonly IAzureDocClient _docClient;
        private readonly documentDbConfig _documentDbConfig;
        private Database _documentDatabase;

        public AzureDocDatabase(IAzureDocClient docClient, documentDbConfig documentDbConfig)
        {
            _docClient = docClient;
            _documentDbConfig = documentDbConfig;
        }

        #region IAzureDocDatabase Methods

        public DocumentClient Client => _docClient.Client;
        public string SelfLink => _documentDatabase.SelfLink;
        public string AltLink => _documentDatabase.AltLink;

        #endregion

        #region Initialization Methods

        public async Task<IAzureDocDatabase> InitializeDatabaseAsync()
        {
            if (_documentDatabase == null)
                _documentDatabase = await _docClient.Client.CreateDatabaseIfNotExistsAsync(new Database { Id = _documentDbConfig.Name });

            return this;
        }

        #endregion
    }
}
