using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using HttpClientMessenger.Exceptions;

namespace HttpClientMessenger.Helpers
{
    public static class QueryParameterParser
    {
        public static string GetQueryString(object queryParams)
        {
            string query = "?" + ParseQueryStringFromParams(queryParams);
            
            query = query.TrimEnd('&');
            return query;
        }

        // Sorry to whoever has to read this
        private static string ParseQueryStringFromParams(object queryParams)
        {
            string query = string.Empty;

            if (IsPrimitiveOrValueType(queryParams) || queryParams is string)
                return Encode($"{queryParams}");
            
            foreach (var param in queryParams.GetType().GetProperties())
            {
                string key = param.Name.ToCamelCase();
                object value = param.GetValue(queryParams);

                query += value switch
                {
                    string s => $"{key}={Encode(s)}",
                    
                    object obj when IsPrimitiveOrValueType(obj) => $"{key}={Encode(HandleCultureOnBuiltInTypes(obj))}",
                    
                    // Also captures arrays
                    object list when list is IEnumerable enumerable => enumerable.Cast<object>()
                        .Aggregate(query, (current, val) 
                            => current + $"{key}={ParseQueryStringFromParams(HandleEnumerableOfObjects(val))}"),
                    
                    object obj when !IsPrimitiveOrValueType(obj) => ParseQueryStringFromParams(obj),
                    
                    _ => $"{key}={Encode($"{value}")}"
                };
            }

            return query;
        }

        private static string HandleCultureOnBuiltInTypes(object val)
        {
            const string specifier = "G";
            var culture = CultureInfo.CreateSpecificCulture("en-CA"); ;
            return val switch
            {
                float f => f.ToString(specifier, culture),
                decimal d => d.ToString(specifier, culture),
                double d => d.ToString(specifier, culture),
                DateTime dt => dt.ToString("O"),
                _ => val.ToString()
            };
        }

        private static object HandleEnumerableOfObjects(object val)
        {
            if (IsPrimitiveOrValueType(val) || val is string)
                return val;

            throw new EnumerableOfObjectsException("Enumerable of objects is not supported.", val.GetType().Name);
        }

        // Not a very good way to do this, but it works for now
        private static string ToCamelCase(this string value)
        {
            return value[..1].ToLower() + value[1..];
        }

        private static bool IsPrimitiveOrValueType(object obj)
        {
            return obj != null && obj.GetType().IsPrimitive || obj is ValueType;
        }

        private static string Encode(string val)
        {
            return HttpUtility.UrlEncode(val, Encoding.UTF8) + "&";
        }
    }
}