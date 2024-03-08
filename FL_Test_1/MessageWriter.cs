using System.Text;
using System.Text.Json;

namespace FL_Test_1;

public static class MessageWriter
{
    private static readonly char _delimiter = ';';

    public static byte[] CreateByteArray(List<Message> messages)
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);
        foreach (var message in messages)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            writer.Write(bytes);

            writer.Write((byte)_delimiter);
        }

        return stream.ToArray();
    }
}
