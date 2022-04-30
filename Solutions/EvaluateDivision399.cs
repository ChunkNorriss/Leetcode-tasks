using System.Collections.Generic;

namespace Solutions;

public class EvaluateDivision399
{
    private class RatesInfo {
        public RatesInfo(string key)
        {
            Key = key;
            Rates = new Dictionary<string, double>();
        }

        public string Key {get; set;}
        public Dictionary<string, double> Rates {get; set; }
    }
    
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var map = new Dictionary<string, RatesInfo>();
        var results = new double[queries.Count];
        
        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            AddRates(map, equation, values[i]);
        }

        for (var i = 0; i < queries.Count; i++)
        {
            var query = queries[i];
            var path = BuildPath(map, query);

            if (path == null)
            {
                results[i] = -1;
                continue;
            }

            results[i] = 1;
            RatesInfo current = null;
            while (path.Count > 0)
            {
                var next = path.Pop();

                if (current == null)
                    current = map[next];
                else
                {
                    results[i] *= current.Rates[next];
                    current = map[next];
                }
            }
 
        }

        return results;
    }

    private Stack<string> BuildPath(Dictionary<string,RatesInfo> map, IList<string> query)
    {
        var visited = new HashSet<string>();
        var path = new Stack<string>();

        var key = query[1];
        var finalKey = query[0];

        return BuildPath(map, visited, key, path, finalKey);
    }

    private static Stack<string> BuildPath(Dictionary<string, RatesInfo> map, HashSet<string> visited, string key, Stack<string> path, string finalKey)
    {
        if (visited.Contains(key))
            return null;
        if (!map.TryGetValue(key, out var rates))
            return null;
        path.Push(key);
        visited.Add(key);
        foreach (var nextKey in rates.Rates.Keys)
        {
            if (nextKey == finalKey)
            {
                path.Push(nextKey);
                return path;
            }

            var buildPath = BuildPath(map, visited, nextKey, path, finalKey);
            if (buildPath != null)
                return buildPath;
        }

        path.Pop();
        return null;
    }

    private void AddRates(Dictionary<string, RatesInfo> map, IList<string> equation, double value)
    {
        AddRate(map, equation[0], equation[1], value);
        AddRate(map, equation[1], equation[0], 1 / value);
    }

    private static void AddRate(Dictionary<string, RatesInfo> map, string key1, string key2, double value)
    {
        if (!map.TryGetValue(key1, out var info))
            map[key1] = info = new RatesInfo(key1);
        info.Rates[key2] = value;
    }
}