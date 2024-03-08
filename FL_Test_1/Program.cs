using FL_Test_1;

var messages = new List<Message>(4)
{
    new Message { Id = Guid.NewGuid(), Text = "First message", Title = "First" },
    new Message { Id = Guid.NewGuid(), Text = "Second message", Title = "Second" },
    new Message { Id = Guid.NewGuid(), Text = "Third message", Title = "Third" },
    new Message { Id = Guid.NewGuid(), Text = "Fourth message", Title = "Fourth" }
};

Console.WriteLine("Newly created list:");
ShowList(messages);

var byteArray = MessageWriter.CreateByteArray(messages);
var list = MessageReader.CreateList(byteArray);

Console.WriteLine("List after being converted to byte array and then to list again:");
ShowList(list);

static void ShowList(List<Message> messages)
{
    messages.ForEach(Console.WriteLine);
}