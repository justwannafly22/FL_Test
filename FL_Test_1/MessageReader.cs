using System.Text;
using System.Text.Json;

namespace FL_Test_1;

public static class MessageReader
{
    private static readonly char _delimiter = ';';

    public static List<Message> CreateList(byte[] byteArray)
    {
        var messages = new List<Message>();

        using var stream = new MemoryStream(byteArray);
        using var reader = new BinaryReader(stream);
        while (stream.Position < stream.Length)
        {
            var dataBytes = new List<byte>();
            byte currentByte;

            while ((currentByte = reader.ReadByte()) != (byte)_delimiter)
            {
                dataBytes.Add(currentByte);
            }

            string data = Encoding.UTF8.GetString(dataBytes.ToArray());
            var message = JsonSerializer.Deserialize<Message>(data);

            messages.Add(message!);
        }

        return messages;
    }
}
