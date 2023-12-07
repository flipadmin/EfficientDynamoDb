using EfficientDynamoDb.Attributes;
using EfficientDynamoDb.DocumentModel;
using EfficientDynamoDb.Operations.Shared;

namespace EfficientDynamoDb.Operations.DeleteItem
{
    public class DeleteItemResponse : WriteResponse
    {
        /// <summary>
        /// A map of attribute names to <see cref="AttributeValue"/> objects, representing the item as it appeared before the <c>DeleteItem</c> operation. This map appears in the response only if <see cref="DeleteItemRequest.ReturnValues"/> was specified as ALL_OLD in the request.
        /// </summary>
        public Document? Attributes { get; set; }
    }

    public class DeleteItemEntityResponse<TEntity> : WriteEntityResponse where TEntity : class
    {
        /// <summary>
        /// A map of attribute names to <see cref="AttributeValue"/> objects, representing the item as it appeared before the <c>DeleteItem</c> operation. This map appears in the response only if <see cref="DeleteItemRequest.ReturnValues"/> was specified as ALL_OLD in the request.
        /// </summary>
        [DynamoDbProperty("Attributes")]
        public TEntity? Attributes { get; set; }
    }

    internal sealed class DeleteItemEntityProjection<TEntity> where TEntity : class
    {
        /// <summary>
        /// A map of attribute names to <see cref="AttributeValue"/> objects, representing the item as it appeared before the <c>DeleteItem</c> operation. This map appears in the response only if <see cref="DeleteItemRequest.ReturnValues"/> was specified as ALL_OLD in the request.
        /// </summary>
        [DynamoDbProperty("Attributes")]
        public TEntity? Attributes { get; set; }
    }
}