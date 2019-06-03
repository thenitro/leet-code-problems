using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeBasedKeyValueStore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var kv = new TimeMap();
            
            kv.Set("foo", "bar", 1); // store the key "foo" and value "bar" along with timestamp = 1   
            Console.WriteLine(kv.Get("foo", 1));  // output "bar"   
            Console.WriteLine(kv.Get("foo", 3)); // output "bar" since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 ie "bar"   
            kv.Set("foo", "bar2", 4);   
            Console.WriteLine(kv.Get("foo", 4)); // output "bar2"   
            Console.WriteLine(kv.Get("foo", 5)); //output "bar2"   
            
            var kv2 = new TimeMap();
                kv2.Set("love", "high", 10);
                kv2.Set("love", "low", 20);
                    
            Console.WriteLine(kv2.Get("love", 5));//""
            Console.WriteLine(kv2.Get("love", 10));//"high"
            Console.WriteLine(kv2.Get("love", 15));//"high"
            Console.WriteLine(kv2.Get("love", 20));//"low"
            Console.WriteLine(kv2.Get("love", 25));//"low"
        }
    }
}

public class TimeMap
{
    private Dictionary<string, SortedDictionary<int, string>> _values;
    
    /** Initialize your data structure here. */
    public TimeMap() {
        _values = new Dictionary<string, SortedDictionary<int, string>>();
    }
    
    public void Set(string key, string value, int timestamp)
    {
        var data = _values.ContainsKey(key) ? _values[key] : new SortedDictionary<int, string>();
            data[timestamp] = value;

        _values[key] = data;
    }
    
    public string Get(string key, int timestamp) {
        if (!_values.ContainsKey(key))
        {
            return string.Empty;
        }

        var data = _values[key];
        if (data.ContainsKey(timestamp))
        {
            return data[timestamp];
        }

        var tsKey = timestamp;

        var keys = data.Keys;
        var i = keys.Count - 1;
        
        while (i >= 0)
        {
            if (timestamp > keys.ElementAt(i))
            {
                tsKey = keys.ElementAt(i);
                break;
            }

            i--;
        }

        return data.ContainsKey(tsKey) ? data[tsKey] : string.Empty;
    }
}
