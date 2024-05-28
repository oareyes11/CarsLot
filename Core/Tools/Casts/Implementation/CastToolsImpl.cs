using System.Reflection;
using Core.Tools.Casts.Interfaces;

namespace Core.Tools.Casts.Implementation
{
    public class CastToolsImpl<T>: ICastTools<T>
    {

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(T model)
        {
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>> { };

            PropertyInfo[] properties = model!.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(property.Name, property.GetValue(model)!.ToString()!));
            }

            return keyValuePairs;
        }
    }
}