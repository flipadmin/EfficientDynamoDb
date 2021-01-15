using System.Text.Json;
using System.Threading.Tasks;
using EfficientDynamoDb.Context;
using EfficientDynamoDb.Context.Operations.TransactGetItems;
using EfficientDynamoDb.DocumentModel.ReturnDataFlags;
using EfficientDynamoDb.Internal.Core;
using EfficientDynamoDb.Internal.Extensions;
using EfficientDynamoDb.Internal.Operations.Shared;

namespace EfficientDynamoDb.Internal.Operations.TransactGetItems
{
    internal class TransactGetItemsHttpContent : DynamoDbHttpContent
    {
        private readonly TransactGetItemsRequest _request;
        private readonly string? _tableNamePrefix;

        public TransactGetItemsHttpContent(TransactGetItemsRequest request, string? tableNamePrefix) : base("DynamoDB_20120810.TransactGetItems")
        {
            _request = request;
            _tableNamePrefix = tableNamePrefix;
        }

        protected override async ValueTask WriteDataAsync(DdbWriter ddbWriter)
        {
            var writer = ddbWriter.JsonWriter;
            writer.WriteStartObject();

            if (_request.ReturnConsumedCapacity != ReturnConsumedCapacity.None)
                writer.WriteReturnConsumedCapacity(_request.ReturnConsumedCapacity);
            
            writer.WritePropertyName("TransactItems");
            
            writer.WriteStartArray();

            foreach (var transactItem in _request.TransactItems)
            {
                writer.WriteStartObject();
                
                writer.WritePropertyName("Get");
                writer.WriteStartObject();
            
                if(transactItem.ExpressionAttributeNames != null)
                    writer.WriteExpressionAttributeNames(transactItem.ExpressionAttributeNames);

                if (transactItem.ProjectionExpression?.Count > 0)
                    writer.WriteString("ProjectionExpression", string.Join(",", transactItem.ProjectionExpression));

                writer.WriteTableName(_tableNamePrefix, transactItem.TableName);
                writer.WritePrimaryKey(transactItem.Key!);
            
                writer.WriteEndObject();
                
                writer.WriteEndObject();

                if (ddbWriter.ShouldFlush)
                    await ddbWriter.FlushAsync().ConfigureAwait(false);
            }
            
            writer.WriteEndArray();
            
            writer.WriteEndObject();
        }
    }
}