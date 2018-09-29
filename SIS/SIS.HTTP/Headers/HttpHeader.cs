﻿namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}