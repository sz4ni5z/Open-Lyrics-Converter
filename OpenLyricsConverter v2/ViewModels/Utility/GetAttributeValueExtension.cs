using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    /// <summary>
    /// Extension class for attributes
    /// </summary>
    public static class GetAttributeValueExtension
    {
        /// <summary>
        /// Extension method to get an attribute from a class
        /// </summary>
        /// <typeparam name="TAttribute">Attribute</typeparam>
        /// <typeparam name="TValue">expected type of value what will return</typeparam>
        /// <param name="type"></param>
        /// <param name="valueSelector">Function to get concrate properties from an attribute</param>
        /// <returns>Attribute of specified class</returns>
        public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
        {
            //get attribute
            var att = type.GetCustomAttributes(typeof(TAttribute), true)
                          .FirstOrDefault() as TAttribute;
            //Check attribute exists
            if (att != null)
            {
                return valueSelector(att);
            }
            else
            {
                return default(TValue);
            }
        }
    }
}
