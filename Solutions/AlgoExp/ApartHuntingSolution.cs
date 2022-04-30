using System.Collections.Generic;

namespace Solutions.AlgoExp;

public class ApartHuntingSolution
{
    private class BuildingInfo
    {
        public BuildingInfo(int id, string[] reqs)
        {
            Id = id;
            Distances = new Dictionary<string, int>();
            foreach (var req in reqs) 
                Distances[req] = int.MaxValue;
        }

        public int Id { get; set; }
        public Dictionary<string, int> Distances { get; set; }

        public int GetMaxDistance()
        {
            var max = int.MinValue;
            foreach (var distance in Distances.Values)
            {
                if (distance > max) 
                    max = distance;
            }
            return max;
        }
    }
    
    public static int ApartmentHunting(List<Dictionary<string, bool>> blocks, string[] reqs)
    {
        var bIdx = 0;
        var minMaxDistance = int.MaxValue;

        var buildingInfos = new List<BuildingInfo>(blocks.Count);
        for (var i = 0; i < blocks.Count; i++) 
            buildingInfos.Add(new BuildingInfo(i, reqs));

        foreach (var req in reqs)
        {
            var distance = 0;
            for (var i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                if (block[req])
                {
                    for (var j = distance; j > 0; j--) 
                        buildingInfos[i - j].Distances[req] = j;
                    distance = 0;
                }
                else
                    distance++;

                buildingInfos[i].Distances[req] = distance;
            }
        }

        
        foreach (var buildingInfo in buildingInfos)
        {
            var maxDistance = buildingInfo.GetMaxDistance();

            if (minMaxDistance > maxDistance)
            {
                minMaxDistance = maxDistance;
                bIdx = buildingInfo.Id;
            }
        }
        

        return bIdx;
    }
}