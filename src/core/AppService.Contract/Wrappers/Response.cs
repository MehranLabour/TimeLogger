namespace TimeLogger.AppService.Contract.Wrappers
{
    public class Response<T>
    {
       
        public Response(T data,string? str,bool isSuccess)
        {
            Succeeded = isSuccess;
            Message = str;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
    }
}