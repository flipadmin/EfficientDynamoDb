using System.Runtime.CompilerServices;
using System.Text.Json;
using EfficientDynamoDb.Internal.Reader;

namespace EfficientDynamoDb.Internal.Operations.TransactWriteItems
{
    public class TransactWriteItemsParsingOptions : IParsingOptions
    {
        public static readonly TransactWriteItemsParsingOptions Instance = new TransactWriteItemsParsingOptions();

        public JsonObjectMetadata? Metadata { get; } = new JsonObjectMetadata(new DictionaryFieldsMetadata
        {
            {
                "ItemCollectionMetrics", new JsonObjectMetadata(new AnyFieldsMetadata(new JsonObjectMetadata(true, false)))
            }
        });

        public bool HasNumberCallback => false;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OnNumber(ref Utf8JsonReader reader, ref DdbReadStack state)
        {
           
        }
    }
}