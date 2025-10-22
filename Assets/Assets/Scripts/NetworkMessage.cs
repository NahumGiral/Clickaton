using Unity.Collections;
using Unity.Netcode;

[System.Serializable]
public struct NetworkMessage : INetworkSerializable
{
    public FixedString128Bytes text;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref text);
    }
}
