using System.Net;

namespace HomeWork.Application.Models.Responses
{
    public class Response<T>
    {
        public T? Data { get; init; }
        public int StatusCode { get; init; }
        public List<string>? Descriptions { get; init; }

        public Response()
        {

        }

        public Response(T data)
        {
            Data = data;
            StatusCode = 200;
        }

        public Response(HttpStatusCode code)
        {
            StatusCode = (int)code;
        }
    }
}
