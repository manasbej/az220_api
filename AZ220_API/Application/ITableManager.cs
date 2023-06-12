using System;
using AZ220_API.Model;

namespace AZ220_API.Application
{
	public interface ITableManager
    {
        Task<bool> CreateTableAsync();
        Task RetrieveTable(string partitionKey, string rowKey);
        Task<string> CreateProduct(ProductItem product);
        Task<List<ProductItem>> ReadAllProduct();
        Task<ProductItem> ReadProductBykey(string id);
        Task<ProductItem> UpdateProduct(string id, ProductItem product);
        Task<string> DeleteProduct(string id);
    }
}

