using LiteNetLib.Utils;
using System;

namespace NetworkShared.Models
{
    public class GameNetDto : INetSerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MatrixString { get; set; }

        public DateTime StartTime { get; set; }

        public int Day { get; set; }

        public int Week { get; set; }

        public int Month { get; set; }

        public int TotalDays { get; set; }

        public DateTime CurrentDayStartTime { get; set; }

        public ArmyNetDto[] Armies { get; set; }

        public DwellingNetDto[] Dwellings { get; set; }

        public AvatarNetDto[] Avatars { get; set; }

        public UserNetDto[] Users { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Name = reader.GetString();
            MatrixString = reader.GetString();
            StartTime = DateTime.Parse(reader.GetString());
            Day = reader.GetInt();
            Week = reader.GetInt();
            Month = reader.GetInt();
            TotalDays = reader.GetInt();
            CurrentDayStartTime = DateTime.Parse(reader.GetString());

            var armiesLength = reader.GetUShort();
            for (int i = 0; i < armiesLength; i++)
            {
                Armies[i] = reader.Get<ArmyNetDto>();
            }

            var dwellingsLength = reader.GetUShort();
            for (int i = 0; i < dwellingsLength; i++)
            {
                Dwellings[i] = reader.Get<DwellingNetDto>();
            }

            var avatarsLength = reader.GetUShort();
            for (int i = 0; i < avatarsLength; i++)
            {
                Avatars[i] = reader.Get<AvatarNetDto>();
            }

            var usersLength = reader.GetUShort();
            for (int i = 0; i < usersLength; i++)
            {
                Users[i] = reader.Get<UserNetDto>();
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Name);
            writer.Put(MatrixString);

            // "O" > Roundtrip formatter. https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings?redirectedfrom=MSDN#Roundtrip
            writer.Put(StartTime.ToString("O"));
            writer.Put(Day);
            writer.Put(Week);
            writer.Put(Month);
            writer.Put(TotalDays);
            writer.Put(CurrentDayStartTime.ToString("O"));

            writer.Put((ushort)Armies.Length);
            for (int i = 0; i < Armies.Length; i++)
            {
                writer.Put(Armies[i]);
            }

            writer.Put((ushort)Dwellings.Length);
            for (int i = 0; i < Dwellings.Length; i++)
            {
                writer.Put(Dwellings[i]);
            }

            writer.Put((ushort)Avatars.Length);
            for (int i = 0; i < Avatars.Length; i++)
            {
                writer.Put(Avatars[i]);
            }

            writer.Put((ushort)Users.Length);
            for (int i = 0; i < Users.Length; i++)
            {
                writer.Put(Users[i]);
            }
        }
    }
}
