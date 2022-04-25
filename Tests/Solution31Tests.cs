using System;
using NUnit.Framework;
using Solutions;
using Solutions.DataStructures;

namespace Tests;

public class Solution31Tests
{
    private Solution31 solution;

    [SetUp]
    public void Setup()
    {
        solution = new Solution31();
    }

    [Test]
    public void TestAllPemutations()
    {
        var allPermutation = solution.GetAllPermutation(new[] { 1, 2, 3 });

        foreach (var permutation in allPermutation) Console.WriteLine(permutation);
    }

    [Test]
    // [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
    [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 })]
    [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
    public void TestNextPermutation(int[] nums, int[] expected)
    {
        solution.NextPermutation(nums);
        Assert.AreEqual(expected, nums);
    }


    [Test]
    public void TestSortedSet()
    {
        // KthLargest kthLargest = new KthLargest(3, new []{4, 5, 8, 2});
        // Console.WriteLine(kthLargest.Add(3));   // return 4
        // Console.WriteLine(kthLargest.Add(5));   // return 5
        // Console.WriteLine(kthLargest.Add(10));  // return 5
        // Console.WriteLine(kthLargest.Add(9));   // return 8
        // Console.WriteLine(kthLargest.Add(4));   // return 8

        // var kthLargest = new KthLargest(2, new[] { 0 });
        // Console.WriteLine(kthLargest.Add(-1)); // return -1
        // Console.WriteLine(kthLargest.Add(1)); // return 0
        // Console.WriteLine(kthLargest.Add(-2)); // return 0
        // Console.WriteLine(kthLargest.Add(-4)); // return 0
        // Console.WriteLine(kthLargest.Add(3)); // return 1    

        // KthLargest kthLargest = new KthLargest(3, new []{5, -1});
        // Console.WriteLine(kthLargest.Add(2));   // return -1
        // Console.WriteLine(kthLargest.Add(1));   // return 1
        // Console.WriteLine(kthLargest.Add(-1));  // return 1
        // Console.WriteLine(kthLargest.Add(3));   // return 2
        // Console.WriteLine(kthLargest.Add(4));   // return 3   

        var kthLargest = new KthLargest(1, new int[0]);
        Console.WriteLine(kthLargest.Add(-3)); // return -1
        Console.WriteLine(kthLargest.Add(-2)); // return 0
        Console.WriteLine(kthLargest.Add(-4)); // return 0
        Console.WriteLine(kthLargest.Add(0)); // return 0
        Console.WriteLine(kthLargest.Add(4)); // return 1
    }


    [Test]
    [TestCase(new[] { "5", "2", "C", "D", "+" }, 30)]
    [TestCase(new[] { "5", "-2", "4", "C", "D", "9", "+", "+" }, 27)]
    [TestCase(new[] { "1" }, 1)]
    public void Solution682Tests(string[] ops, int expected)
    {
        var actual = new Solution682().CalPoints(ops);
        Assert.AreEqual(expected, actual);
    }


    [Test]
    [TestCase("hello", "ll", 2)]
    [TestCase("aaaaa", "bba", -1)]
    [TestCase("aaaaa", "", 0)]
    [TestCase("aaa", "aaaa", -1)]
    public void Solution28Tests(string haystack, string needle, int expected)
    {
        var actual = new Solution28().StrStr(haystack, needle);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    // [TestCase(new []{1,1,1,2,2,3}, 2, new []{1, 2})]
    [TestCase(new[] { 3, 3, 3, 1, 2, 2 }, 2, new[] { 2, 3 })]
    // [TestCase(new []{1}, 1, new []{1})]
    public void Solution347Tests(int[] nums, int k, int[] expected)
    {
        var actual = new Solution347().TopKFrequent(nums, k);
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Solution1260Tests()
    {
        var grid = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
        var k = 1;
        var expected = new[] { new[] { 9, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 } };

        // var grid = new[] { new[] { 1, 2, 3 } };

        var actual = new Solution1260().ShiftGrid(grid, k);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Solution59Tests()
    {
        var solution = new Solution59();
        var expected1 = new[] { new[] { 1, 2, 3 }, new[] { 8, 9, 4 }, new[] { 7, 6, 5 } };
        var actual1 = solution.GenerateMatrix(3);
        Assert.AreEqual(expected1, actual1);


        var expected2 = new[] { new[] { 1 } };
        var actual2 = solution.GenerateMatrix(1);
        Assert.AreEqual(expected2, actual2);
    }
    
    [Test]
    public void Solution897Tests()
    {
        var solution = new Solution897();

        var treeNode =
            new TreeNode(5,
                new TreeNode(3,
                    new TreeNode(2,
                        new TreeNode(1)
                    ),
                    new TreeNode(4)
                ),
                new TreeNode(6,
                    null,
                    new TreeNode(8,
                        new TreeNode(7),
                        new TreeNode(9)
                    )
                )
            );
        var increasingBst = solution.IncreasingBST(treeNode);
    }
    
    [Test]
    public void Solution404Tests()
    {
        var treeNode =
            new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7)
                )
            );
        var actual = new Solution404().SumOfLeftLeaves(treeNode);
        var expected = 24;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void BSTIteratorTests()
    {
        var treeNode =
            new TreeNode(7,
                new TreeNode(3),
                new TreeNode(15,
                    new TreeNode(9),
                    new TreeNode(20)
                )
            );
        var iterator = new BSTIterator(treeNode);
        Assert.AreEqual(3, iterator.Next());
        Assert.AreEqual(7, iterator.Next());
        Assert.AreEqual(9, iterator.Next());
        Assert.AreEqual(15, iterator.Next());
        Assert.AreEqual(20, iterator.Next());
    }


    [Test]
    public void TestCodec()
    {
        var codec = new Codec();
        var longUrl = "https://leetcode.com/problems/design-tinyurl";
        var tinyUrl = codec.encode(longUrl);
        var decode = codec.decode(tinyUrl);
    }
}