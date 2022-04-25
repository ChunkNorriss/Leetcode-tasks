using System.Linq;
using NUnit.Framework;
using Solutions.DataStructures;

namespace Tests;

[TestFixture]
public class MyHashMapTest
{
    [Test]
    public void PutTests()
    {
        var hashMap = new MyHashMap(10);
        hashMap.Put(1, 2);
        Assert.AreEqual(2, hashMap.Get(1));
        
        hashMap.Put(1, 3);
        Assert.AreEqual(3, hashMap.Get(1));
        
        hashMap.Remove(1);
        Assert.AreEqual(-1, hashMap.Get(1));
    }

    [Test]
    public void ResizeTests()
    {
        var hashMap = new MyHashMap(1);

        hashMap.Put(1, 1);
        hashMap.Put(2, 2);
        hashMap.Put(3, 3);
        
        Assert.AreEqual(1, hashMap.Get(1));
        Assert.AreEqual(2, hashMap.Get(2));
        Assert.AreEqual(3, hashMap.Get(3));
    }


    [Test]
    public void TestCases()
    {
        var commands = new[]
        {
            "put", "put", "put", "remove", "put", "put", "remove", "put", "put", "put", "put", "put", "put", "remove", "put", "put", "put", "put",
            "remove", "put", "get", "put", "put", "put", "put", "remove", "put", "remove", "put", "put", "put", "put", "put", "get", "put", "put",
            "put", "remove", "get", "remove", "put", "put", "remove", "remove", "put", "remove", "put", "put", "remove", "put", "put", "put",
            "remove", "put", "put", "put", "put", "put", "put", "put", "put", "put", "put", "put", "put", "put", "put", "get", "put", "put", "put",
            "put", "put", "put", "put", "put", "remove", "put", "put", "put", "get", "get", "get", "get", "put", "put", "put", "get", "put", "put",
            "put", "get", "put", "put", "put", "put", "remove", "put", "put", "get"

        };
        var argumentsStr = "[14,52],[90,38],[56,14],[14],[57,0],[93,38],[51],[85,98],[76,1],[42,2],[90,55],[69,23],[8,42],[24],[78,69],[75,32],[11,40],[95,77],[80],[5,75],[22],[49,59],[1,74],[13,94],[51,98],[90],[27,9],[51],[61,69],[80,73],[50,80],[15,85],[0,97],[75],[40,34],[15,96],[15,54],[3],[13],[6],[1,13],[45,87],[60],[45],[98,31],[35],[90,12],[12,52],[25],[50,73],[91,25],[13,4],[51],[77,59],[91,92],[79,93],[2,94],[75,80],[17,6],[19,93],[96,12],[59,98],[54,26],[3,48],[94,2],[22,2],[17,60],[77],[61,12],[60,71],[23,95],[78,50],[82,58],[75,11],[8,66],[42,11],[40],[59,79],[60,44],[48,90],[79],[98],[85],[8],[83,45],[83,26],[64,3],[90],[85,31],[69,47],[79,87],[70],[59,78],[92,49],[95,6],[92,5],[11],[58,99],[20,86],[31]";

        var expectedStr =
            "null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,-1,null,null,null,null,null,null,null,null,null,null,null,null,32,null,null,null,null,94,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,59,null,null,null,null,null,null,null,null,null,null,null,null,93,31,98,66,null,null,null,12,null,null,null,-1,null,null,null,null,null,null,null,-1";


        var map = new MyHashMap();


        var argsArray = argumentsStr
            .Split("],")
            .Select(x => x.Trim('[', ']'))
            .ToArray();

        var expectedArray = expectedStr.Split(',');
        for (int i = 0; i < commands.Length; i++)
        {
            var command = commands[i];
            var s = argsArray[i];
            var args = s.Split(',');
            var key = int.Parse(args[0]);
            switch (command)
            {
                case "put":
                    var value = int.Parse(args[1]);
                    map.Put(key, value);
                    break;
                case "get":
                    var actual = map.Get(key);
                    var expected = int.Parse(expectedArray[i]);
                    Assert.AreEqual(expected, actual);
                    break;
                case "remove":
                    map.Remove(key);
                    break;
            }
        }
    }
}