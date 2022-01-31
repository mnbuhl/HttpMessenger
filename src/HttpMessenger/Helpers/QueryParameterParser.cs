using System.Collections;
using System.Linq;
using System.Web;

namespace HttpMessenger.Helpers
{
    public static class QueryParameterParser
    {
        public static string GetQueryString(object queryParams)
        {
            string query = "?" + ParseQueryStringFromParams(queryParams);

            query = query.TrimEnd('&');
            return query;
        }

        private static string ParseQueryStringFromParams(object queryParams)
        {
            string query = string.Empty;

            if (IsPrimitiveType(queryParams) || queryParams is string)
                return queryParams + "&";
            
            foreach (var param in queryParams.GetType().GetProperties())
            {
                string key = param.Name.ToCamelCase();
                object value = param.GetValue(queryParams);

                query += value switch
                {
                    string s => $"{key}={HttpUtility.UrlEncode(s)}",
                    
                    object obj when IsPrimitiveType(obj) => $"{key}={HttpUtility.UrlEncode(obj.ToString())}",
                    
                    // Also captures arrays
                    object list when list is IEnumerable enumerable => enumerable.Cast<object>()
                        .Aggregate(query, (current, val) => current + $"{key}={ParseQueryStringFromParams(val)}"),
                    
                    object obj when !IsPrimitiveType(obj) => ParseQueryStringFromParams(obj),
                    
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

        private static bool IsPrimitiveType(object obj)
        {
            return obj != null && obj.GetType().IsPrimitive;
        }
    }
}