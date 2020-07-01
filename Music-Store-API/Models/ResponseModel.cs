﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store_API.Models
{
    public class ResponseModel<T> where T : class
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Result { get; set; }
    }
}
