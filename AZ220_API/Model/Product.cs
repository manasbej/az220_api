using System;
using Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AZ220_API.Model
{
    public class ProductItem : TableEntity
    {
		public string? Id { get; set; }
		public string? Name { get; set; }
		public double Price { get; set; }
		public int Stock { get; set; }

    }
    

public class ProductEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        

        public string Name { get; set; }
        public double Price { get; set; }
        public string ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset ITableEntity.Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        

        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            PartitionKey = properties[nameof(PartitionKey)].StringValue;
            RowKey = properties[nameof(RowKey)].StringValue;
            Timestamp = properties[nameof(Timestamp)].DateTimeOffsetValue;
            ETag = properties[nameof(ETag)].StringValue;
            Name = properties["Name"].StringValue;
            Price = properties["Price"].DoubleValue.Value; // Assuming the Price is stored as a Double
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var properties = new Dictionary<string, EntityProperty>
            {
                { nameof(PartitionKey), new EntityProperty(PartitionKey) },
                { nameof(RowKey), new EntityProperty(RowKey) },
                { nameof(Timestamp), new EntityProperty(Timestamp) },
                { nameof(ETag), new EntityProperty(ETag.ToString()) },
                { "Name", new EntityProperty(Name) },
                { "Price", new EntityProperty(Price) }
            };

            return properties;
        }
    }




}

