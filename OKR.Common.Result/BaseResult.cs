namespace OKR.Common.Results
{
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json.Serialization;

    public class BaseResult<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("errors")]
        public ICollection<string> Errors { get; set; }

        [JsonPropertyName("content")]
        public T Content { get; set; }

        public BaseResult() { }

        public BaseResult(T response)
        {
            this.Success = true;
            this.Content = response;
        }

        public BaseResult(string error, int errorCode)
        {
            this.Success = false;
            this.ErrorCode = errorCode;
            this.Errors = new List<string> { { error } };
        }

        public BaseResult(string error, int errorCode, HttpStatusCode code)
        {
            this.Success = false;
            this.ErrorCode = errorCode;
            this.Errors = new List<string> { { $"{error} code: {code}" } };
        }

        public BaseResult(bool succ, T content)
        {
            this.Success = succ;
            this.Content = content;
        }

        public BaseResult(List<string> errors, int errorCode)
        {
            this.Success = false;
            this.ErrorCode = errorCode;
            this.Errors = errors;
        }
    }
}
