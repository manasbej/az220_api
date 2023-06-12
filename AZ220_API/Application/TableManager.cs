using System;
using AZ220_API.Model;
using Microsoft.Azure.Documents;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using System.Reflection.Emit;
using TableService.Api.Client.Model;
using Azure;

namespace AZ220_API.Application
{
	public class TableManager : ITableManager
    {
        private readonly string TABLE_NAME = "PRODUCT_MASTER";
        private readonly string STORAGE_CONNECTION = "PRODUCT_MASTER";
        private readonly CloudStorageAccount storageAccount;
        private readonly CloudTableClient tableClient;
        private readonly CloudTable productTable;

        
		public TableManager()
		{
            storageAccount = CloudStorageAccount.Parse(STORAGE_CONNECTION);
            tableClient = storageAccount.CreateCloudTableClient();
            productTable = tableClient.GetTableReference(TABLE_NAME);
        }

        public async Task<string> CreateProduct(ProductItem product)
        {
            await productTable.ExecuteAsync(TableOperation.Insert(product));
            return "Product created.";

        }

        public async Task<bool> CreateTableAsync()
        {
            return await productTable.CreateIfNotExistsAsync();
        }

        public async Task<string> DeleteProduct(string id)
        {
            return "";
        }

        public async Task<List<Product>> ReadAllProduct()
        {
            TableQuery<ProductItem> tableQuery = new TableQuery<ProductItem>();
            //var itemlist = productTable.ExecuteQuerySegmentedAsync(tableQuery);
            throw new NotImplementedException();
        }

        public async Task<Product> ReadProductBykey(string id)
        {

            throw new NotImplementedException();
        }

        public async Task RetrieveTable(string partitionKey, string rowKey)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(string id, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductItem> UpdateProduct(string id, ProductItem product)
        {
            throw new NotImplementedException();
        }

        async Task<List<ProductItem>> ITableManager.ReadAllProduct()
        {
            
          
            return new List<ProductItem>();
        }

        Task<ProductItem> ITableManager.ReadProductBykey(string id)
        {
            throw new NotImplementedException();
        }
    }
}

