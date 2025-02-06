using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public static class DictionaryHelper
{
    public static void AddPropertiesToDictionary(object? source, Dictionary<string, object> destination)
    {
        if (source == null) return;

        foreach (var prop in source.GetType().GetProperties())
        {
            var value = prop.GetValue(source);
            if (value != null)
            {
                destination[prop.Name] = value;
            }
        }
    }
}
