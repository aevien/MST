﻿#if MIRROR
using MasterServerToolkit.Networking;
using Mirror;

namespace MasterServerToolkit.Bridges.MirrorNetworking
{
    public struct ValidateRoomAccessResultMessage : NetworkMessage
    {
        public string Error { get; set; }
        public ResponseStatus Status { get; set; }
    }

    public static class ValidateRoomAccessResultMessageExtension
    {
        public static void Serialize(this NetworkWriter writer, ValidateRoomAccessResultMessage value)
        {
            writer.WriteString(value.Error);
            writer.WriteUInt16((ushort)value.Status);
        }

        public static ValidateRoomAccessResultMessage Deserialize(this NetworkReader reader)
        {
            ValidateRoomAccessResultMessage value = new ValidateRoomAccessResultMessage()
            {
                Error = reader.ReadString(),
                Status = (ResponseStatus)reader.ReadUInt16()
            };

            return value;
        }
    }
}
#endif