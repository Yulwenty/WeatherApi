using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.Error
{
    public class ServiceException:Exception
    {
        public int StatusCode { get; set; }
        public ServiceException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
