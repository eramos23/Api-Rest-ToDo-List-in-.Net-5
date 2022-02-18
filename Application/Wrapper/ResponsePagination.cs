using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrapper
{
    public class ResponsePagination<T> where T : class
    {
        public ResponsePagination()
        {

        }
        public ResponsePagination(T data, int total)
        {
            Succeeded = true;
            Total = total;
            Data = data;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
