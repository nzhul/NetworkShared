using LiteNetLib.Utils;
using System;

namespace GameServer.NetworkShared.Packets
{
    public class ExampleSerialize : INetSerializable
    {
        public int Integer { get; set; }

        public string String { get; set; }

        public ExampleEnum Enum { get; set; }

        public DateTime DateTime { get; set; }

        public int? NullableInt { get; set; }

        public Guid? NullableGuid { get; set; }

        public ExampleEnum? NullableEnum { get; set; }

        public ExampleCollectionItem[] Array { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Integer = reader.GetInt();
            String = reader.GetString();
            Enum = (ExampleEnum)reader.GetByte();
            DateTime = DateTime.Parse(reader.GetString());

            if (reader.TryGetInt(out int nullableInt))
            {
                NullableInt = nullableInt;
            }

            if (reader.TryGetString(out string nullableGuidString))
            {
                NullableGuid = Guid.Parse(nullableGuidString);
            }

            var arrayLength = reader.GetUShort();
            Array = new ExampleCollectionItem[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Array[i] = reader.Get<ExampleCollectionItem>();
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Integer);
            writer.Put(String);
            writer.Put((byte)Enum);

            // "O" > Roundtrip formatter. https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings?redirectedfrom=MSDN#Roundtrip
            writer.Put(DateTime.ToString("O"));

            if (NullableInt.HasValue)
            {
                writer.Put(NullableInt.Value);
            }

            if (NullableGuid.HasValue)
            {
                writer.Put(NullableGuid.Value.ToString());
            }

            if (NullableEnum.HasValue)
            {
                writer.Put((byte)NullableEnum.Value);
            }

            writer.Put((ushort)Array.Length);
            for (int i = 0; i < Array.Length; i++)
            {
                writer.Put(Array[i]);
            }
        }
    }

    public class ExampleCollectionItem : INetSerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Name = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Name);
        }
    }

    public enum ExampleEnum
    {
        Value1,
        Value2
    }
}
