﻿using Microsoft.Azure.Documents.Client;
using Open.Social.AzureDocumentDb.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.Interface
{
    public interface IAzureDocCollection
    {
        Task<bool> CreateAsync(object objectToSave);
        Task<bool> UpdateAsync(object objectToSave, string id);
        Task<bool> DeleteAsync(string id);

        Task<StoredProcedureResponse<T2>> ExecuteStoredProcByName<T2>(string spName, params dynamic[] parameters);
        Task<StoredProcedureResponse<T2>> ExecuteStoredProcByName<T2>(string spName, dynamic parameter);
        Task<StoredProcedureResponse<T2>> ExecuteStoredProcByName<T2>(string spName);
    }

    public interface IAzureDocCollection<T> : IAzureDocCollection where T : CollectionItemEntity
    {
        IList<T> RunQuery();
        IAzureDocCollection<T> GetById(Guid id);

        T2 SetupBaseQuery<T2>() where T2 : class;
    }

    public interface IDocumentEntity<T>
    {
        T Init();
    }

    public interface IDocumentCollection<T> : IAzureDocCollection<T> where T : CollectionItemEntity
    {
        Task InitializeAsync();
    }

    //public interface IProductCollection : IDocumentCollection<ProductEntity>
    //{
    //    IProductCollection OrderByName();
    //}

    //public interface ICartCollection : IDocumentCollection<CartEntity>
    //{
    //}
}