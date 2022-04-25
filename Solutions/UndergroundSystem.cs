using System.Collections.Generic;

namespace Solutions;

public class UndergroundSystem {
    private readonly Dictionary<int, Travel> travels;
    private readonly Dictionary<string, Dictionary<string, StationStat>> links;
    
    public UndergroundSystem() {
        travels = new Dictionary<int, Travel>();
        links = new Dictionary<string, Dictionary<string, StationStat>>();
    }
    
    public void CheckIn(int id, string stationName, int t) {
        if (!travels.TryGetValue(id, out var travel))
        {
            travel = new Travel();
            travels[id] = travel;
        }

        travel.SignIn = t;
        travel.StationFrom = stationName;
    }
    
    public void CheckOut(int id, string stationName, int t)
    {
        var travel = travels[id];
        var duration = t - travel.SignIn;
        var stationFrom = travel.StationFrom;
        
        if (!links.TryGetValue(stationFrom, out var stationLinks))
        {
            stationLinks = new Dictionary<string, StationStat>();
            links[stationFrom] = stationLinks;
        }
        
        if (!stationLinks.TryGetValue(stationName, out var stat))
        {
            stat = new StationStat();
            stationLinks[stationName] = stat;
        }

        stat.TravelsCount++;
        stat.AverageTime += (duration - stat.AverageTime) / stat.TravelsCount;
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        var stationLinks = links[startStation];
        var stat = stationLinks[endStation];
        return stat.AverageTime;
    }

    private class StationStat {
        public int TravelsCount {get;set;}
        public double AverageTime {get;set;}
    }

    private class Travel {
        public string StationFrom {get;set;}
        public int SignIn {get;set;}
    }
}



/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */