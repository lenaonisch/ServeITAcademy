using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TravelAgencyHelper.Helpers
{
    public class ControllerHelper<TEntity> where TEntity : class, new()
    {
        #region
        private static object Parse(string valueAsString, Type type)
        {

            if (type.Name == "String")
                return valueAsString;

            object classInstance = null;// = Activator.CreateInstance(type, null);
            var t = type.GetMethods().Where(method => method.Name == "Parse").Where(param => param.GetParameters()[0].ParameterType.Name == "String").FirstOrDefault();
            if (t != null)
            { 
                t.Invoke(classInstance, new object[] { valueAsString });
            }
            return classInstance;
        }
        #endregion

        public static TEntity GetFromQueryString(string queryString)
        {
            var obj = new TEntity();
            var properties = typeof(TEntity).GetProperties();
            var parsed = HttpUtility.ParseQueryString(queryString);
            foreach (var property in properties)
            {
                var valueAsString = parsed[property.Name];
                if (valueAsString != null)
                {
                    var value = Parse(valueAsString, property.PropertyType);

                    if (value == null)
                        continue;

                    property.SetValue(obj, value, null);
                }
            }
            return obj;
        }


    }
}
