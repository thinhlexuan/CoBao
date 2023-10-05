using System.Collections.Generic;

namespace CoBaoWeb.Services
{
    public class ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }
    public class ResponseDetail : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> Messages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int TotalPages;
        /// <summary>
        /// 
        /// </summary>
        public int TotalRows;
        /// <summary>
        /// 
        /// </summary>
        public int PageSize;

        /// <summary>
        /// 
        /// </summary>
        public ResponseDetail()
        {
            Messages = new List<string>();
            TotalPages = 0;
            TotalPages = 0;
            PageSize = 0;
        }
    }

    public class ResponseDetail<T> : ResponseDetail
    {
        public T Data;
    }
}
