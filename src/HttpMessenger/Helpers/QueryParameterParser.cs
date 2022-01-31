using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HttpMessenger.Helpers
{
    public static class QueryParameterParser
    {
        public static string GetQueryString(object queryParams)
        {
            string query = "?" + ParseFromProperties(queryParams);

            query = query.TrimEnd('&');
            return query;
        }

        private static string ParseFromProperties(object queryProps)
        {
            string query = string.Empty;
            
            foreach (var param in queryProps.GetType().GetProperties())
            {
                string key = param.Name.ToCamelCase();
                object value = param.GetValue(queryProps);

                query += value switch
                {
                    string s => $"{key}={HttpUtility.UrlEncode(s)}",
                    object obj when IsValueType(obj) => $"{key}={HttpUtility.UrlEncode(obj.ToString())}",
                    object obj when !IsValueType(obj) => ParseFromProperties(obj),
                    _ => $"{key}={HttpUtility.UrlEncode(value.ToString())}"
                };
                
                query += "&";
            }

            
            return query;
        }

        // Not a very good way to do this, but it works for now
        private static string ToCamelCase(this string value)
        {
            return value[..1].ToLower() + value[1..];
        }
        
        private static bool IsValueType(object obj) {
            return obj != null && obj.GetType().IsValueType;
        }
    }
}