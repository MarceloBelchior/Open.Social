﻿using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.Interface
{
    public interface IAzureDocDatabase
    {
        DocumentClient Client { get; }
        string SelfLink { get; }
        string AltLink { get; }

        Task<IAzureDocDatabase> InitializeDatabaseAsync();
    }
}