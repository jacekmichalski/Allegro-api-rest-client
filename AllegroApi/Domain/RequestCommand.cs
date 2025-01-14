﻿using System;
using RestSharp;

namespace AllegroApi.Domain
{
    public class RequestCommand : IRequestAllegro
    {
        public Uri Uri { get; set; }
        public string Authorization { get; set; }
        public Method Method { get; set; }
        public object Data { get; set; }
    }
}