using System;
using System.Runtime.CompilerServices;
using EfficientDynamoDb.DocumentModel.AttributeValues;

namespace EfficientDynamoDb.Internal.Mapping.Converters.Primitives.Enums
{
    internal sealed class IntEnumDdbConverter<TEnum> : DdbConverter<TEnum> where TEnum : struct, Enum
    {
        public override TEnum Read(AttributeValue attributeValue)
        {
            var value = attributeValue.AsNumberAttribute().ToInt();

            return Unsafe.As<int, TEnum>(ref value);
        }
    }
}