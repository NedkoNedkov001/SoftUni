﻿using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpMethodAttribute : Attribute
    {
        public Method HttpMethod { get; }

        public HttpMethodAttribute(Method httpMethod)
            => HttpMethod = httpMethod;


    }
}
