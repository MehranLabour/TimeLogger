namespace TimeLogger.AppService.Contract.Wrappers
{
    public class Response
    {
       
        public Response(string? str,bool isSuccess)
        {
            Succeeded = isSuccess;
            Message = str; 
            Data = null;
        }
        public string? Data { get; set; }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
    }
    public class Response<T> : Response
    {
       
        public Response(T data,string? str,bool isSuccess):base(str,isSuccess)
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