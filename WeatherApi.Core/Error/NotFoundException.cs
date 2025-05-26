using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.Error
{
    public class NotFoundException: ServiceException
    {
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound,  message)
        {

        }
    }
}
