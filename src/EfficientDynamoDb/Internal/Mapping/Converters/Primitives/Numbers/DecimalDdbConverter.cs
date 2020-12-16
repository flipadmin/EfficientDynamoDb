using EfficientDynamoDb.DocumentModel.AttributeValues;

namespace EfficientDynamoDb.Internal.Mapping.Converters.Primitives.Numbers
{
    internal sealed class DecimalDdbConverter : DdbConverter<decimal>
    {
        public override decimal Read(AttributeValue attributeValue) => attributeValue.AsNumberAttribute().ToDecimal();
    }
}