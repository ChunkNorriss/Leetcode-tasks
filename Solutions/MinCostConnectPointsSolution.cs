using System;

namespace Solutions;

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */
 
 
public class MinCostConnectPointsSolution {
    public int MinCostConnectPoints(int[][] points)
    {
        if (points.Length < 2)
            return 0;

        var connections = new int[points.Length];
        for (var i = 0; i < connections.Length; i++) 
            connections[i] = -1;
        
        var totalDistance = 0;

        for (var i = 0; i < points.Length-1; i++)
        {
            var point = points[i];
            var minDistance = int.MaxValue;
            for (var j = 0; j < points.Length; j++)
            {
                if (i == j || connections[j] == i)
                    continue;
                var distance = GetDistance(point, points[j]);
                if (distance >= minDistance)
                    continue;
                
                connections[i] = j;
                minDistance = distance;
            }

            totalDistance += minDistance;
        }

        return totalDistance;
    }

    private int GetDistance(int[] point1, int[] point2)
    {
        return Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);
    }
}