using System.Text.Json;

namespace ApplicationErrorException
{
    public class ApplicationErrorExceptions : System.Exception
    {
        public List<string> Messages { get; private set; }

        public int ErrorCode { get; private set; }

        public ApplicationErrorExceptions(string? message, int errorCode) : base(message)
        {
            this.Messages = new List<string>() { new string(message) };
            this.ErrorCode = errorCode;
        }

        public ApplicationErrorExceptions(List<string> messages, int errorCode) : base(JsonSerializer.Serialize(messages))
        {
            this.Messages = messages;
            this.ErrorCode = errorCode;
        }
    }
}