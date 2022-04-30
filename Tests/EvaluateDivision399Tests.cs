using System.Collections.Generic;
using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class EvaluateDivision399Tests
{
    [Test]
    public void Test1()
    {
        var equations = new List<IList<string>>()
        {
            new [] {"x1","x2"},
            new [] {"x2","x3"},
            new [] {"x3","x4"},
            new [] {"x4","x5"},
        };
        var doubles = new []{3.0,4.0,5.0,6.0};
        var queries = new List<IList<string>>()
        {
            new [] {"x1","x5"},
            new [] {"x5","x2"},
            new [] {"x2","x4"},
            new [] {"x2","x2"},
            new [] {"x2","x9"},
            new [] {"x9","x9"},
        };


        var solution = new EvaluateDivision399();
        var equation = solution.CalcEquation(equations, doubles, queries);
    }
}